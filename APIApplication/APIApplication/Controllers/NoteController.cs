using APIApplication.Entities;
using APIApplication.Models.Request;
using APIApplication.Models.Respone;
using APIApplication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace APIApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController(INoteService noteService) : ControllerBase
    {

        [HttpGet]
        [Authorize(Roles = "Admin,Editor,User")]
        public async Task<ActionResult> GetAll()
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var notes = await noteService.GetAll(userId);
            return Ok(notes);
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Editor,User")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            return Ok(await noteService.GetById(id, userId));
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Editor,User")]
        public async Task<ActionResult> Create([FromBody] NoteRequest request)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
        
            var result = await noteService.Create(request, userId);

            if (result > 0)
                return BadRequest("Error create note");

            return Ok(200);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Editor,User")]
        public async Task<ActionResult> Update([FromBody] NoteRequest request, Guid id)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var result  = await noteService.Update(userId, id, request);
            if (result is not true)
                return NotFound("Note not found or access denied.");
            
            return Ok(200);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Editor,User")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var result = await noteService.Delete(id, userId);
            if (result is not true)
                return NotFound("Note not found or access denied.");

            return Ok(200);
        }
    }
}

