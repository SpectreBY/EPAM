using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2Lib
{
    public class Polynomial
    {
        private double[,] polynomialCoefs;

        public Polynomial(double[,] polynomialCoefs)
        {
            this.polynomialCoefs = polynomialCoefs;
        }

        public double[,] PolynomialCoefs
        {
            get { return polynomialCoefs; }
        }

        private double[,] FillDegrees(double[] coefs)
        {
            int degree = coefs.Length - 1;
            double[,] array = new double[coefs.Length, 2];

            for(int i = 0; i < coefs.Length; i++)
            {
                array[i, 0] = coefs[i];
                array[i, 1] = degree;
                degree--;
            }
            return array;
        }

        public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
        {
            Polynomial polynomial3;
            int maxlength;
            double[,] polynomial3coefs;

            if (polynomial1.PolynomialCoefs.Length >= polynomial2.PolynomialCoefs.Length)
                maxlength = polynomial1.PolynomialCoefs.GetLength(0);
            else
                maxlength = polynomial2.PolynomialCoefs.GetLength(0);

            polynomial3coefs = new double[maxlength, 2];

            for (int i = 0, degree = maxlength - 1; i < maxlength; i++, degree--)
            {
                if (i >= polynomial1.PolynomialCoefs.GetLength(0))
                {
                    polynomial3coefs[i, 0] = polynomial2.PolynomialCoefs[i, 0];
                }
                if (i >= polynomial2.PolynomialCoefs.GetLength(0))
                {
                    polynomial3coefs[i, 0] = polynomial1.PolynomialCoefs[i, 0];
                }
                if (i < polynomial1.PolynomialCoefs.GetLength(0) && i < polynomial2.PolynomialCoefs.GetLength(0))
                {
                    polynomial3coefs[i, 0] = polynomial1.PolynomialCoefs[i, 0] + polynomial2.PolynomialCoefs[i, 0];
                }
                polynomial3coefs[i, 1] = degree;
            }

            polynomial3 = new Polynomial(polynomial3coefs);
            return polynomial3;
        }

        public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2)
        {
            Polynomial polynomial3;
            int maxlength;
            double[,] polynomial3coefs;

            if (polynomial1.PolynomialCoefs.Length >= polynomial2.PolynomialCoefs.Length)
                maxlength = polynomial1.PolynomialCoefs.GetLength(0);
            else
                maxlength = polynomial2.PolynomialCoefs.GetLength(0);

            polynomial3coefs = new double[maxlength, 2];

            for (int i = 0, degree = maxlength - 1; i < maxlength; i++, degree--)
            {
                if (i >= polynomial1.PolynomialCoefs.GetLength(0))
                {
                    polynomial3coefs[i, 0] = polynomial2.PolynomialCoefs[i, 0];
                }
                if (i >= polynomial2.PolynomialCoefs.GetLength(0))
                {
                    polynomial3coefs[i, 0] = polynomial1.PolynomialCoefs[i, 0];
                }
                if (i < polynomial1.PolynomialCoefs.GetLength(0) && i < polynomial2.PolynomialCoefs.GetLength(0))
                {
                    polynomial3coefs[i, 0] = polynomial1.PolynomialCoefs[i, 0] - polynomial2.PolynomialCoefs[i, 0];
                }
                polynomial3coefs[i, 1] = degree;
            }

            polynomial3 = new Polynomial(polynomial3coefs);
            return polynomial3;
        }

        public static Polynomial operator *(Polynomial polynomial1, Polynomial polynomial2)
        {
            Polynomial polynomial3;
            double[,] polynomial3coefs = new double[polynomial1.PolynomialCoefs.GetLength(0) * polynomial2.PolynomialCoefs.GetLength(0), 2];
            int counter = 0;
            for (int i = 0; i < polynomial1.PolynomialCoefs.GetLength(0); i++)
            {
                for (int j = 0; j < polynomial2.PolynomialCoefs.GetLength(0); j++)
                {
                    polynomial3coefs[counter, 0] = polynomial1.PolynomialCoefs[i, 0] * polynomial2.PolynomialCoefs[j, 0];
                    polynomial3coefs[counter, 1] = polynomial1.PolynomialCoefs[i, 1] + polynomial2.PolynomialCoefs[j, 1];
                    counter++;
                }
            }

            polynomial3 = new Polynomial(polynomial3coefs);
            return polynomial3;
        }


        public bool Equals(Polynomial polynomial)
        {
            for(int i = 0; i < polynomial.PolynomialCoefs.GetLength(0); i++)
            {
                if (polynomial.PolynomialCoefs[i, 0] != polynomialCoefs[i, 0])
                    return false;
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (polynomialCoefs[0, 0] < 0)
                builder.Append(string.Format(@"-{0}x^{1}", -polynomialCoefs[0, 0], polynomialCoefs[0, 1]));
            else
                builder.Append(string.Format(@"{0}x^{1}", polynomialCoefs[0, 0], polynomialCoefs[0, 1]));

            for (int i = 1; i < polynomialCoefs.GetLength(0) - 1; i++)
            {
                if (polynomialCoefs[i, 1] == 1)
                {
                    if (polynomialCoefs[i, 0] < 0)
                        builder.Append(string.Format(" - {0}x", -polynomialCoefs[i, 0]));
                    else
                        builder.Append(string.Format(" + {0}x", polynomialCoefs[i, 0]));
                }
                else
                {
                    if (polynomialCoefs[i, 0] < 0)
                        builder.Append(string.Format(" - {0}x^{1}", -polynomialCoefs[i, 0], polynomialCoefs[i, 1]));
                    else
                        builder.Append(string.Format(" + {0}x^{1}", polynomialCoefs[i, 0], polynomialCoefs[i, 1]));
                }
            }

            if (polynomialCoefs[polynomialCoefs.GetLength(0) - 1, 0] < 0)
                builder.Append(string.Format(@" - {0}", -polynomialCoefs[polynomialCoefs.GetLength(0) - 1, 0]));
            else
                builder.Append(string.Format(@" + {0}", polynomialCoefs[polynomialCoefs.GetLength(0) - 1, 0]));
            return builder.ToString();
        }
    }
}
