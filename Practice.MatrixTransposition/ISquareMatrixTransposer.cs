using System;

namespace Practice.MatrixTransposition
{
    public interface ISquareMatrixTransposer<T>
    {
        void Transpose(T[] matrix);
    }
    
}
