namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private File file;
        private Music music;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(Music  music)
        {
            //this.file = file;
            this.music = music;
        }

        public int CalculateCurrentPercent()
        {
            //return (this.file.BytesSent * 100) / this.file.Length;
            return (this.music.BytesSent * 100) / this.music.Length;
        }
    }
}
