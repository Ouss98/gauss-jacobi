using System;
using System.Collections.Generic;
using System.Text;

namespace _0Assignment4
{
    /* Class containing a method to solve linear equations */
    class LinSolve
    {
        int maxIter = 100; // Max number of iterations

        /* Solve a system of linear equations using Gauss-Jacob method */
        public Vector Solve(Matrix A, Vector b)
        {
            int size = b.VectorSize; // A and b have the same size

            // Initialization
            Matrix invD = new Matrix(size);
            Matrix T;
            Vector c;

            Vector xk = new Vector(size);
            List<Vector> xkList = new List<Vector>(); // List of vectors to compare xk+1 and xk
            xkList.Add(xk); // 0-th element is xk = {0, 0, ..., 0}

            bool stopCond; // Stopping condition
            int iter = 0; // Iteration count

            for (int i = 0; i < size; i++)
            {
                invD[i, i] = 1.0 / A[i, i]; // Set the diagonal of invD to 1 / A[i,i] 
                A[i, i] = 0; // Set the diagonal of A to 0

                for (int j = 0; j < size; j++)
                {
                    A[i, j] = -A[i, j]; // (- Upper) + (- Lower) without diagonal
                }
            }
            // Calculate T and c
            T = invD * A;
            c = invD * b;
            // Gauss-Jacob method with tolerance of 10^-7
            do
            {
                xkList.Insert(iter+1, T * xkList[iter] + c); // Compute the solution xk+1 and store it into the xkList
                stopCond = xk.Norm(xkList[iter+1] - xkList[iter]) / xk.Norm(xkList[iter]) > 0.0000001; // Tolerance
                iter++;
                
            } while (stopCond && iter < maxIter);

            return xkList[iter];
        }
    }
}
