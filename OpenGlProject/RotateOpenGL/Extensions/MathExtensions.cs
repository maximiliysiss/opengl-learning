using MathNet.Numerics.LinearAlgebra;
using System;

namespace RotateOpenGL.Extensions
{
    public static class MathExtensions
    {
        public static Vector<double> ToVector(this double[,] data, int index)
        {
            var tmpData = new double[data.GetLength(1)];
            for (int i = 0; i < data.GetLength(1); i++)
                tmpData[i] = data[index, i];
            return Vector<double>.Build.DenseOfArray(tmpData);
        }
    }
}
