using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MatrixTransposition
{
    public class ShellMatrixTransposer<T> : ISquareMatrixTransposer<T>
    {


        long IntegerRoot(long input)
        {
            double root = Math.Sqrt(input);

            long rootBits = BitConverter.DoubleToInt64Bits(root);
            long lowerBound = (long)BitConverter.Int64BitsToDouble(rootBits - 1);
            long upperBound = (long)BitConverter.Int64BitsToDouble(rootBits + 1);

            for (long candidate = lowerBound; candidate <= upperBound; candidate++) {
                if (candidate * candidate == input) {
                    return candidate;
                }
            }
            throw new ArgumentException("length");
        }

        private void Swap(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }

        public void Transpose(T[] matrix)
        {
            uint sideLength = (uint)IntegerRoot(matrix.Length);
            for(uint offset = 0; offset < sideLength; offset++) {
                for(uint idx = offset; idx < sideLength; idx++) {
                    uint src =offset*sideLength+idx;
                    uint dst = sideLength * idx+offset;
                    Swap(ref matrix[src], ref matrix[dst]);
                }
            }
        }
    }
}
c