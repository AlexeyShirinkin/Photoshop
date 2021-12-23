namespace Photoshop.Core.Utilities;

public static class MatrixExtensions
{
    public static IEnumerable<TResult> Enumerate<TInput, TResult>(
        this TInput[,] matrix, Func<TInput, int, int, TResult> selector)
    {
        var width = matrix.GetLength(0);
        var height = matrix.GetLength(1);
        for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
                yield return selector(matrix[i, j], i, j);
    }
}