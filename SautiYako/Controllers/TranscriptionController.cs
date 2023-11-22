using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SautiYako.Repository;
using System;
using System.IO;
using System.Threading.Tasks;

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

            try
            {
                // Save the uploaded file to a temporary location
                var filePath = Path.GetTempFileName();
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
