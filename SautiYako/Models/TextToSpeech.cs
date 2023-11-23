using Microsoft.Identity.Client;

namespace SautiYako.Models
{
    public class TextToSpeech
    {
        public string Id { get; set; }
        public string TextToRead { get; set; }
        public DateTime TimeStamp { get; set; }
        public string VoiceSettings { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        // New navigation property for the one-to-many relationship
        public ICollection<TextToSpeechLog> TextToSpeechLogs { get; set; }

    }
}
