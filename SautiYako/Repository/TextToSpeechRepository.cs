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
            request.Headers.Add("Cookie", "__cf_bm=5nysEBbbMaeK2f.mk7_sFYxuKyukGvtpj7HH1hFEYJo-1700497952-0-AQF/nKKZ11QxfPIGPgfxckfAqy5GJlQmy4PGERFsQiF+Darr7/0IFv13IJ4IS120HM0aFLF8FoBo44sjdBOMttQ=; _cfuvid=19fN8MMNA9gbZkGZDUp2tLObiLPcV7smKm9v2PoWRxY-1700497952130-0-604800000");
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

