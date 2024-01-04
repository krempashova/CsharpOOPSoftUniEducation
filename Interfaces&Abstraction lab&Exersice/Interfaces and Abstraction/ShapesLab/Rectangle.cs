using Shapes;

public class Rectangle : IDrawable
{

    private int width;
    private int height;
    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
        
    }

    public int Width { get; set; }
    public int Height { get; set; }
    public void Draw()
    {
        for (int row = 0; row < Height; row++)
        {
            for (int col = 0; col < Width; col++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }
}
