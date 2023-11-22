using Microsoft.AspNetCore.Mvc;
using SautiYako.Repository;

namespace SautiYako.Controllers
{
    [Route("api/transcription")]
    [ApiController]
    public class TranscriptionController : ControllerBase
    {
        private readonly SpeechToTextRepository _repository;

        public TranscriptionController(SpeechToTextRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File not selected");

            var extension = Path.GetExtension(file.FileName);
            if (extension != ".mp3")
            {
                return BadRequest("Invalid file extension. Only .mp3 files are allowed.");
            }

            try
            {
                // Save the uploaded file to a temporary location with the original extension
                var filePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + extension);
                // Console.WriteLine(filePath);

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }

                // Call the repository for transcription
                var result = await _repository.TranscribeAudio(filePath);

                // Return the transcription result
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
