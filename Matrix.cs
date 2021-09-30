using System;
using System.Collections.Generic;
using System.Text;

namespace _0Assignment4
{
    class Matrix
    {
        /* Variable */
        private readonly double[,] _mvalues;

        /* Parameter for getting Matrix[row, col] value 
         * or assigning a value to Matrix[row, col] */
        public double this[int row, int col]
        {
            get {
                if(row >= 0 && row < _mvalues.GetLength(0) && col >= 0 && col < _mvalues.GetLength(0))
                {
                    return _mvalues[row, col];
                }
                else
                {
                    throw new Exception("Indices should be >= 0 and < to matrix size");
                }
            }                
            set {
                if (row >= 0 && row < _mvalues.GetLength(0) && col >= 0 && col < _mvalues.GetLength(0))
                {
                    _mvalues[row, col] = value;
                }
                else
                {
                    throw new Exception("Indices should be >= 0 and < to matrix size");
                }                 
            }
        }

        /* Parameter for getting siz of a vector via Vector.VectorSize */
        public int MatrixSize
        {
            get { return _mvalues.GetLength(0); }
        }

        /* Constructors */
        // Default
        public Matrix()
        {
            _mvalues = new double[3, 3] 
            { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }
        public Matrix(double[,] values)
        {
            _mvalues = values;
        }
        // Takes a size of type int as an argument
        // If size > 1, set all values to zero
        // Else, throw exception
        public Matrix(int size)
        {
            if (size > 1)
            {
                _mvalues = new double[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        _mvalues[i, j] = 0;
                    }
                }
            }
            else
            {
                throw new Exception("Matrix construction failed: Size should be > 1");
            }
        }

        /* Methods */
        // Overloading * operator to handle 'Matrix * Matrix' of same size
        public static Matrix operator *(Matrix lhs, Matrix rhs)
        {
            double[,] left = lhs._mvalues;
            double[,] right = rhs._mvalues;
            int n = left.GetLength(0);
            double[,] newMatrix = new double[n,n];            
            if (n == right.GetLength(0))
            {
                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < n; j++)
                    {
                        for(int k = 0; k < n; k++)
                        {
                            newMatrix[i, j] += left[i, k] * right[k, j];
                        }
                    }
                }
            }
            else
            {
                throw new Exception("'*' Operation failed: Matrices should be the same size");
            }
            return new Matrix(newMatrix);
        }
        // Overloading * operator to handle 'Matrix * Vector' of same size
        public static Vector operator *(Matrix lhs, Vector rhs)
        {
            double[,] left = lhs._mvalues;
            Vector right = rhs;
            int n = left.GetLength(0);
            double[] newVector = new double[n];
            if (n == right.VectorSize)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        newVector[i] += left[i, k] * right[k];
                    }
                }
            }
            else
            {
                throw new Exception("'*' Operation failed: Matrices should be the same size");
            }
            return new Vector(newVector);
        }
        // Overriding ToString() method
        /* { x11, x12, ..., x1n }
         * { x21, x22, ..., x2n }
         * { .................. }
         * { xn1, xn2, ..., xnn } */
        public override string ToString()
        {
            string matStr = "\n";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _mvalues.GetLength(0); i++)
            {
                // For every row, create a list to store its values
                List<string> lList = new List<string>(); 
                for (int j = 0; j < _mvalues.GetLength(0); j++)
                {
                    string l = _mvalues[i, j].ToString();// Convert values to string
                    lList.Insert(j, l);
                }
                // Concatenate the values and separate them by ", "
                var ln = sb.Append(string.Join(", ", lList)); 
                matStr += "{ " + ln.ToString() + " }\n";
                sb.Clear(); // Clear StringBuilder
            }
            return matStr;
        }
    }
}
