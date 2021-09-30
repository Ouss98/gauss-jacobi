using System;
using System.Collections.Generic;
using System.Text;

namespace _0Assignment4
{
    public class Vector
    {
        /* Variable */
        private readonly double[] _vector; 

        /* Parameter for getting Vector[index] value 
         * or assigning a value to Vector[index] */
        public double this[int index]
        {
            get {
                if (index >= 0 && index < _vector.Length)
                {
                    return _vector[index];
                }
                else
                {
                    throw new Exception("Index should be >= 0 and < to vector size");
                }
            }
            set {
                if (index >= 0 && index < _vector.Length)
                {
                    _vector[index] = value;
                }
                else
                {
                    throw new Exception("Index should be >= 0 and < to vector size");
                }
            }
        }

        /* Parameter for getting siz of a vector via Vector.VectorSize */
        public int VectorSize
        {
            get { return _vector.Length; }
        }

        /* Constructors */
        // Default
        public Vector()
        {
            _vector = new double[3] { 0, 0, 0 };
        }
        // Takes an array of doubles as an argument
        public Vector(double[] vector)
        {
            _vector = vector;
        }
        // Takes a size of type int as an argument
        // If size > 1, set all values to zero
        // Else, throw exception
        public Vector(int size)
        {
            if (size > 1)
            {
                _vector = new double[size];
                for(int i = 0; i < size; i++)
                {
                    _vector[i] = 0;
                }
            }
            else
            {
                throw new Exception("Vector construction failed: Size should be > 1");
            }
        }

        /* Methods */
        // Overloading + operator to handle 'Vector + Vector'
        public static Vector operator +(Vector x, Vector y)
        {
            double[] v0 = x._vector;
            double[] v1 = y._vector;
            double[] newVector = new double[v0.Length];
            if (v0.Length == v1.Length)
            {
                for (int i = 0; i < v0.Length; i++)
                {
                    newVector[i] = v0[i] + v1[i];
                }
            }
            else
            {
                throw new Exception("'+' Operation failed: Vectors should be the same size");
            }
            return new Vector(newVector);
        }

        // Overloading - operator to handle 'Vector - Vector'
        public static Vector operator -(Vector x, Vector y)
        {
            double[] v0 = x._vector;
            double[] v1 = y._vector;
            double[] newVector = new double[v0.Length];
            if (v0.Length == v1.Length)
            {
                for (int i = 0; i < v0.Length; i++)
                {
                    newVector[i] = v0[i] - v1[i];
                }
            }
            else
            {
                throw new Exception("'-' Operation failed: Vectors should be the same size");
            }
            return new Vector(newVector);
        }

        // Overloading * operator to handle 'Vector * Vector'
        public static double operator *(Vector x, Vector y)
        {
            double[] v0 = x._vector;
            double[] v1 = y._vector;
            double scalar = 0;
            for (int i = 0; i < v0.Length; i++)
            {
                scalar += v0[i] * v1[i];
            }
            return scalar;
        }
        // Overloading * operator to handle 'double * Vector'
        public static Vector operator *(double x, Vector y)
        {
            double[] v1 = y._vector;
            double[] newVector = new double[v1.Length];
            for (int i = 0; i < v1.Length; i++)
            {
                newVector[i] = x * v1[i];
            }
            return new Vector(newVector);
        }

        // Overriding ToString() method
        /* { x1, x2, ..., xn } */
        public override string ToString()
        {
            string vectStr;
            StringBuilder sb = new StringBuilder();
            List<string> resList = new List<string>(); // List used to store the string values
            for (int i = 0; i < _vector.Length; i++)
            {
                string l = string.Format("{0:F3}", _vector[i]); // Format values to 0.000 and to strings
                resList.Insert(i, l); // Adds vector value as string to resList
            }
            vectStr = "{ " + sb.Append(string.Join(", ", resList)).ToString() + " }"; // { v[1], ... , v[n] }
            return vectStr;
        }

        // Norm of a vector (Euclidean norm)
        public double Norm(Vector v)
        {
            double norm = 0;
            for(int i = 0; i < v.VectorSize; i++)
            {
                norm += v[i] * v[i];
            }
            // Abs to keep value positive even when two vectors 
            // are subbstrated before applying the norm
            norm = Math.Sqrt(norm);
            return norm;
        }
    }
}
