namespace Photoshop.Core.PixelConverters;

public class BlurPixelConverter : MatrixConverterBase
{
    private static readonly double[,] Matrix = new double[5, 5]
                                               {
                                                   {
                                                       0.000789, 0.006581, 0.013347, 0.006581,
                                                       0.000789
                                                   },
                                                   {
                                                       0.006581, 0.054901, 0.111345, 0.054901,
                                                       0.006581
                                                   },
                                                   {
                                                       0.013347, 0.111345, 0.22581, 0111345,
                                                       0.013347
                                                   },
                                                   {
                                                       0.006581, 0.054901, 0.111345, 0.054901,
                                                       0.006581
                                                   },
                                                   {
                                                       0.000789, 0.006581, 0.013347, 0.006581,
                                                       0.000789
                                                   }
                                               };

    public BlurPixelConverter() : base(new[,]
                                       {
                                           { -1, 0, 0 },
                                           { 0, 1, 0 },
                                           { 0, 0, 1 }
                                       }, 1)
    {
    }
}