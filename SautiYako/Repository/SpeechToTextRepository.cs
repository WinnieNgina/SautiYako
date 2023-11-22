namespace SautiYako.Repository
{
    public class SpeechToTextRepository
    {
        public async Task<string> TranscribeAudio(string filePath)
        {
           
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file '{filePath}' does not exist.");
            }
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/audio/transcriptions");
            request.Headers.Add("Authorization", "Bearer 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");
            var content = new MultipartFormDataContent
            {
                {new StreamContent(File.OpenRead(filePath)), "file", Path.GetFileName(filePath) },
                {new StringContent("whisper-1"), "model" }
            };

            request.Content = content;

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
