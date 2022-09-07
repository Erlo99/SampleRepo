using Domain.Http.GoodsReceivedNotes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsReceivedNoteController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var goodReceivedNote = await Mediator.Send(new GetGoodsReceivedNoteByIdQueryRequest() {Id = id});
            return Ok(goodReceivedNote);
        }

        [HttpPost]
        public async Task<IActionResult> PostById([FromBody] CreateGoodsReceivedNoteRequest request)
        {
            var goodReceivedNote = await Mediator.Send(request);
            return Created($"api/GoodsReceivedNote/{goodReceivedNote.Id}",goodReceivedNote);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] UpdateGoodsReceivedNoteStatusRequest request)
        {
            var goodReceivedNote = await Mediator.Send(request);
            return Ok(goodReceivedNote);
        }
    }
}
