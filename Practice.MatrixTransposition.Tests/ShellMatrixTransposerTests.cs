using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice.MatrixTransposition;
using System.Linq;

namespace Practice.MatrixTransposition.Tests
{
    [TestClass]
    public class ShellMatrixTransposerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EnsureFailureOnNonSquareMatrix()
        {
            ISquareMatrixTransposer<double> transposer = new ShellMatrixTransposer<double>();
            double[] matrix = new double[5];
            transposer.Transpose(matrix);
        }

        [TestMethod]
        public void EnsureCorrect()
        {
            ISquareMatrixTransposer<int> transposer = new ShellMatrixTransposer<int>();
            int[] matrix = new int[9] {
                0,3,6,
                1,4,7,
                2,5,8
            };
            int[] expected = new int[9] {
                0,1,2,3,4,5,6,7,8
            };
            transposer.Transpose(matrix);
            foreach(int v in matrix) {
                Console.WriteLine(v);
            }
            Assert.IsTrue(Enumerable.SequenceEqual(expected, matrix));
        }
    }
}
