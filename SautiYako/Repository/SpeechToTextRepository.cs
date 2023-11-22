namespace SautiYako.Repository
{
    public class SpeechToTextRepository
    {
        public async Task<string> TranscribeAudio(string filePath)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/audio/transcriptions");
            request.Headers.Add("Authorization", "Bearer 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");
            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(File.OpenRead(filePath)), "file", Path.GetFileName(filePath));
            content.Add(new StringContent("whisper-1"), "model");

            request.Content = content;

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
