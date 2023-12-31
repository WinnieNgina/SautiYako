﻿using Microsoft.AspNetCore.Identity;

namespace SautiYako.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecretKey { get; set; } = Guid.NewGuid().ToString();
        public ICollection<SpeechToText> SpeechToTextRequests { get; set; }
        public ICollection<TextToSpeech> TextToSpeechRequests { get; set;}
    }
}
