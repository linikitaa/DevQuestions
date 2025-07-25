using DevQuestion.Contarcts;
using Microsoft.AspNetCore.Mvc;

namespace DevQuestions.Presenters;

[ApiController]
[Route("[controller]")]
public class QuestionsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateQuestionDto request, CancellationToken cancellationToken)
    {
        return Ok("Questions created");
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetQuestionDto request, CancellationToken cancellationToken)
    {
        return Ok("Questions retrieved");
    }
    
    [HttpGet("{questionId:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid questionId, CancellationToken cancellationToken)
    {
        return Ok("Questions retrieved");
    }
    
    [HttpPut("{questionId:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid questionId, UpdateQuestionDto request, CancellationToken cancellationToken)
    {
        return Ok("Questions updated");
    }
    
    [HttpDelete("{questionId:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid questionId, CancellationToken cancellationToken)
    {
        return Ok("Questions deleted");
    }
    
    [HttpPut("{questionId:guid}/solution")]
    public async Task<IActionResult> SelectSolution([FromRoute] Guid questionId, [FromQuery] Guid answerId, CancellationToken cancellationToken)
    {
        return Ok("Solution selected");
    }
    
    [HttpPost("{questionId:guid}/answers")]
    public async Task<IActionResult> AddAnswer([FromRoute] Guid questionId, AddAnswerDto request, CancellationToken cancellationToken)
    {
        return Ok("Answer added");
    }
}
