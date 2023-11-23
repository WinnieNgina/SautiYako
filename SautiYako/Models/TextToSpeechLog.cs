namespace SautiYako.Models
{
    public class TextToSpeechLog
    {
        public string Id { get; set; }
        public string TextToSpeechRequestId {get; set; }
        public string AudioFilePath { get; set; }
        public DateTime TimeStamp { get; set; }
        public TextToSpeech TextToSpeech { get; set; }
    }
}
