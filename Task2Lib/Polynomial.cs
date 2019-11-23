using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2Lib
{
    public class Polynomial
    {
        private double[] polynomialCoefs;

        public Polynomial(double[] polynomialCoefs)
        {
            this.polynomialCoefs = polynomialCoefs;
        }

        public double[] PolynomialCoefs
        {
            get { return polynomialCoefs; }
        }

        public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
        {
            Polynomial polynomial3;
            int maxlength;
            double[] polynomial3coefs;

            if (polynomial1.PolynomialCoefs.Length >= polynomial2.PolynomialCoefs.Length)
                maxlength = polynomial1.PolynomialCoefs.Length;
            else
                maxlength = polynomial2.PolynomialCoefs.Length;

            polynomial3coefs = new double[maxlength];

            for (int i = 0; i < maxlength; i++)
            {
                if (i >= polynomial1.PolynomialCoefs.Length)
                    polynomial3coefs[i] = polynomial2.PolynomialCoefs[i];
                if (i >= polynomial2.PolynomialCoefs.Length)
                    polynomial3coefs[i] = polynomial1.PolynomialCoefs[i];
                if (i < polynomial1.PolynomialCoefs.Length && i < polynomial2.PolynomialCoefs.Length)
                    polynomial3coefs[i] = polynomial1.PolynomialCoefs[i] + polynomial2.PolynomialCoefs[i];
            }

            polynomial3 = new Polynomial(polynomial3coefs);
            return polynomial3;
        }

        public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2)
        {
            Polynomial polynomial3;
            int maxlength;
            double[] polynomial3coefs;

            if (polynomial1.PolynomialCoefs.Length >= polynomial2.PolynomialCoefs.Length)
                maxlength = polynomial1.PolynomialCoefs.Length;
            else
                maxlength = polynomial2.PolynomialCoefs.Length;

            polynomial3coefs = new double[maxlength];

            for (int i = 0; i < maxlength; i++)
            {
                if (i >= polynomial1.PolynomialCoefs.Length)
                    polynomial3coefs[i] = polynomial2.PolynomialCoefs[i];
                if (i >= polynomial2.PolynomialCoefs.Length)
                    polynomial3coefs[i] = polynomial1.PolynomialCoefs[i];
                if (i < polynomial1.PolynomialCoefs.Length && i < polynomial2.PolynomialCoefs.Length)
                    polynomial3coefs[i] = polynomial1.PolynomialCoefs[i] - polynomial2.PolynomialCoefs[i];
            }

            polynomial3 = new Polynomial(polynomial3coefs);
            return polynomial3;
        }

        public bool Equals(Polynomial polynomial)
        {
            foreach (double item in polynomial.PolynomialCoefs)
            {
                if (!PolynomialCoefs.Contains(item))
                    return false;
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            int degree = 2;

            if (polynomialCoefs.First() < 0)
                builder.Append(string.Format(@"-{0}x", -polynomialCoefs.First()));
            else
                builder.Append(string.Format(@"{0}x", polynomialCoefs.First()));

            for (int i = 1; i < polynomialCoefs.Length - 1; i++)
            {
                if (polynomialCoefs[i] < 0)
                    builder.Append(string.Format(" - {0}x^{1}", -polynomialCoefs[i], degree));
                else
                    builder.Append(string.Format(" + {0}x^{1}", polynomialCoefs[i], degree));
                degree++;
            }

            if (polynomialCoefs.Last() < 0)
                builder.Append(string.Format(@" - {0}x^{1}", -polynomialCoefs.Last(), degree));
            else
                builder.Append(string.Format(@" + {0}x^{1}", polynomialCoefs.Last(), degree));

            return builder.ToString();
        }
    }
}
