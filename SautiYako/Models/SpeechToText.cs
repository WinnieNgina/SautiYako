namespace SautiYako.Models
{
    public class SpeechToText
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string TranscribedText { get; set; }
        public User User { get; set; }
    }
}
