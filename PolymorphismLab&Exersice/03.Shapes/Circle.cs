namespace Shapes
{
    public class Circle:Shape
    {
        private double radius;
        public Circle(double radius)
        {
            Raduis = radius;   
        }
       
        public double Raduis { get;private  set; }

        public override double CalculateArea()
        =>Math.PI* Math.Pow(Raduis,2);

        public override double CalculatePerimeter()
        => Math.PI * 2 * Raduis;
        public override string Draw()
        {
            return base.Draw();
        }
    }
}
