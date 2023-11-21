using Microsoft.AspNetCore.Mvc;
using SautiYako.Repository;

namespace SautiYako.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextToSpeechController : ControllerBase
    {
        private readonly TextToSpeechRepository _textToSpeechRepository;
        public TextToSpeechController(TextToSpeechRepository textToSpeechRepository)
        {
            _textToSpeechRepository = textToSpeechRepository;
        }
        [HttpGet("{text}")]
        public async Task<IActionResult> GetTextToSpeech(string text)
        {
            var fileName = await _textToSpeechRepository.Transcribe(text);
            if (fileName != null)
            {
                return Ok(fileName);
            }
            return BadRequest(ModelState);
        }
    }
}
