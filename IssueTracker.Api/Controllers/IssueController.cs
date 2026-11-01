using MediatR;
using Microsoft.AspNetCore.Mvc;
using IssueTracker.Application.Features.Issues.Commands;
using IssueTracker.Application.Features.Issues.Queries;

namespace IssueTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IssueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIssue([FromBody] CreateIssueCommand command)
        {
            var issueId = await _mediator.Send(command);
            return Ok(new { IssueId = issueId, Message = "Issue created successfully." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIssue(int id, [FromBody] UpdateIssueCommand command)
        {
            try
            {
                command.Id = id; // Ensure the command has the correct ID
                await _mediator.Send(command);
                return Ok(new { Message = "Issue updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Error updating issue: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssue(int id)
        {
            var command = new DeleteIssueCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIssueById(int id)
        {
            var query = new GetIssueByIdQuery { Id = id };
            var issue = await _mediator.Send(query);
            if (issue == null)
            {
                return NotFound(new { Message = "Issue not found." });
            }
            return Ok(issue);
        }

        [HttpPut("{id}/Label")]
        public async Task<IActionResult> AddLabelToIssue(int id, [FromBody] AddLabelToIssueCommand command)
        {
            try
            {
                command.IssueId = id; // Ensure the command has the correct Issue ID
                await _mediator.Send(command);
                return Ok(new { Message = "Label added to issue successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Error adding label to issue: {ex.Message}" });
            }
        }
    }
}
