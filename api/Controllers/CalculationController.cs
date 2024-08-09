using api.Data;
using api.Filters;
using api.Interfaces;
using api.Request;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CalculationController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly ICalculationRepository _calculationRepo;
    private readonly IMathOperationService _mathOperationService;

    public CalculationController(ApplicationDBContext context, ICalculationRepository calculationRepo, 
        IMathOperationService mathOperationService)
    {
        _context = context;
        _calculationRepo = calculationRepo;
        _mathOperationService = mathOperationService;
    }

    [HttpGet]
    public IActionResult Sum([FromQuery] ValuesIncoming values)
    {
        return Ok(_mathOperationService.Sum(values));
    }

    [HttpGet]
    public IActionResult Subtraction([FromQuery] ValuesIncoming values)
    {
        return Ok(_mathOperationService.Subtract(values));
    }

    [HttpGet]
    public IActionResult Multiplication([FromQuery] ValuesIncoming values)
    {
        return Ok(_mathOperationService.Multiply(values));
    }

    [HttpGet]
    [ServiceFilter(typeof(ExceptionFilter))]
    public IActionResult Division([FromQuery] ValuesIncoming values)
    {
        return Ok(_mathOperationService.Divide(values));
    }

    [HttpGet]
    [ServiceFilter(typeof(ExceptionFilter))]
    public IActionResult Exponentiation([FromQuery] ValuesIncoming values)
    {
        return Ok(_mathOperationService.Pow(values));
    }

    [HttpGet]
    [ServiceFilter(typeof(ExceptionFilter))]
    public IActionResult Root([FromQuery] ValuesIncoming values)
    {
        return Ok(_mathOperationService.Root(values));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(){
        if (!ModelState.IsValid){
            return BadRequest(ModelState);
        }

        var calculations = await _calculationRepo.GetAllAsync();

        return Ok(calculations);
    }
}
