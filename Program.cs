using System;

/* AM6007 Assignment 4 - Oussama CHAHBOUNE - 120225721 */

namespace _0Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------- Solving a system of linear equations using Gauss-Jacob method ----------------\n");
            LinSolve ls = new LinSolve();
            try
            {
                double[,] m_arr = new double[4, 4] { { 9, -2, 3, 2 }, { 2, 8, -2, 3 }, { -3, 2, 11, -4 }, { -2, 3, 2, 10 } };
                Matrix m = new Matrix(m_arr);
                double[] b_arr = new double[] { 54.5, -14, 12.5, -21 };
                Vector b = new Vector(b_arr);
                Console.WriteLine("The matrix m is {0}\n", m);
                Console.WriteLine("The vector b is {0}\n", b);

                Vector ans = ls.Solve(m, b);
                Console.WriteLine("The solution to m * x = b is {0}", ans);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encountered: {0}", e.Message);
            }

        }
    }
}
