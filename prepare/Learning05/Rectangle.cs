public class Rectangle : Shape
{
    private double _width;
    private double _length;

    public Rectangle(double width, double length, string color)
    {
        _width = width;
        _length = length;
        SetColor(color);
    }

    public override double GetArea()
    {
        return _width * _length;
    }
}