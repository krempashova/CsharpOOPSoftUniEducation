namespace P01.Stream_Progress
{
    public class File:IBytes
    {
        private string name;

        public int Length { get; set; }

        public int BytesSent { get; set; }

        public int CalculateCurrentPercent()
        {
            return (this.BytesSent * 100) / this.Length;
        }
    }
}
