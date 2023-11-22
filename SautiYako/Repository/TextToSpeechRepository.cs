namespace SautiYako.Repository
{
    public class TextToSpeechRepository
    {
        public async Task<String> Transcribe(string text)
        {
            Guid guid = Guid.NewGuid();
            string FileName = guid.ToString() + ".mp3";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/audio/speech");
            request.Headers.Add("Authorization", "Bearer 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");
            var content = new StringContent($"{{\"model\": \"tts-1\", \"input\": \"{text}\", \"voice\": \"alloy\"}}", null, "application/json");
            request.Content = content;

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var audioData = await response.Content.ReadAsByteArrayAsync();

            // Save the audio data to an MP3 file
            SaveToMp3File(audioData, FileName);
            return FileName;
        }

        public static void SaveToMp3File(byte[] audioData, string filePath)
        {
            File.WriteAllBytes(filePath, audioData);
        }
    }

}

