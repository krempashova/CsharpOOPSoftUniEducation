namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;
        public Rectangle(int height,int width)
        {
            Height=height;
            Width=width;

        }
        public int Height { get; private  set; }
        public int Width { get; private set; }

        public override double CalculateArea()
       => Width * Height;

        public override double CalculatePerimeter()
        => 2 * Height + 2 * Width;
        public override string Draw()
        {
            return base.Draw();
        }
    }
}
