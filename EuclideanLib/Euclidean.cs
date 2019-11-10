using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclideanLib
{
    public static class Euclidean
    {
        public static int Solve(int a, int b)
        {
            int A = a;
            int B = b;
            int C = 0;
            int h = 1;
            int result = 0;
            while(true)
            {
                C = A - B * h;
                if(C >= B)
                {
                    h++;
                }
                else if(C == 0)
                {
                    result = B;
                    break;
                }
                else
                {
                    h = 1;
                    A = B;
                    B = C;
                }
            }
            return result;
        }
    }
}
