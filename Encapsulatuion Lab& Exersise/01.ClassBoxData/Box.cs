using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
		private double  length ;
		public Box(double length, double width, double height)
		{
            Length=length;
			Width=width; 
			Height = height;

        }

		public double Length 
		{
			get { return length ; }
			 private set 
			{ 
				if(value<=0) 
				{
					throw new ArgumentException(String.Format(ExeptionMessages.BoxofParametarsCannotbeZeroOrNegative,nameof(this.Length)));
				}
				length = value ;
			}
		}
		private double  width ;

		public double  Width 
		{
			get { return width ; }
			set 
			{ 
				if(value<=0)

				{
                    throw new ArgumentException(String.Format(ExeptionMessages.BoxofParametarsCannotbeZeroOrNegative, nameof(this.Width)));
                }
				width = value;
			}
		}
        private double height ;

		public double Height  
		{
			get { return height; }
			set
            {
                if (value <= 0)

                {
                    throw new ArgumentException(String.Format(ExeptionMessages.BoxofParametarsCannotbeZeroOrNegative, nameof(this.Height)));
                }
                height = value;
            }
		}


		public double SurfaceArea() => (2 * Length * Width) + LateralSurfaceArea();
		public double LateralSurfaceArea() => (2 * Length * Height) + (2 * Width * Height);
		public double Volume() => Length * Width * Height;
        public override string ToString()
        {
			StringBuilder sb = new StringBuilder();
			sb
				.AppendLine($"Surface Area - {SurfaceArea():f2}")
                .AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}")
            .AppendLine($"Volume - {Volume():f2}");


			return sb.ToString().TrimEnd();
        }
    }
}
