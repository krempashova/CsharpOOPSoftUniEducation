namespace P01.Stream_Progress
{
    public class Music:IBytes
    {
        private string artist;
        private string album;

        public Music(string artist, string album, int length, int bytesSent)
        {
            this.artist = artist;
            this.album = album;
            
        }

        public int Length { get; set; }

        public int BytesSent { get; set; }
       

        public int CalculateCurrentPercent()
        {
            return (this.BytesSent * 100) / this.Length;
        }
    }
}
