namespace Photoshop.Visualization;

public static class RotateMenuItemFactory
{
    public static RotateMenuItem[] Create() =>
        new[]
        {
            new RotateMenuItem("Поворот на 90 вправо", RotateFlipType.Rotate90FlipNone),
            new RotateMenuItem("Поворот на 90 влево", RotateFlipType.Rotate270FlipNone),
            new RotateMenuItem("Отразить по горизонтали", RotateFlipType.RotateNoneFlipX),
            new RotateMenuItem("Отразить по вертикали", RotateFlipType.RotateNoneFlipY),
        };
}