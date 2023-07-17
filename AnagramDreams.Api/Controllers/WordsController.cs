using AnagramDreams.Api.Dtos;
using AnagramDreams.DataAccess.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnagramDreams.Api.Controllers
{
    // A controller is responsible for handling the API endpoints
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WordsController : ControllerBase
    {
        private readonly IWordService wordService;
        private readonly IMapper mapper;

        public WordsController(
            IMapper mapper,
            IWordService wordService)
        {
            this.mapper = mapper;
            this.wordService = wordService; // inject the controller repo
        }

        [HttpGet("{word}")]
        public async Task<IActionResult> GetAnagrams(string word)
        {
            try
            {
                var result = await wordService.GetAnagrams(word);
                var response = result.Select(w => mapper.Map<WordResp>(w));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("isAnagram")]
        public async Task<bool> IsAnagram([FromBody] WordReq words)
        {
            return await wordService.IsAnagram(words.Input, words.Word);
        }
    }
}
