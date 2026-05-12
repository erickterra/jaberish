
using Jaberish.Infra;
using Jaberish.Models;
using Jaberish.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
namespace Jaberish.Controllers;

[ApiController]
[Route("api")]
public class GeneratorController : ControllerBase
{

    private readonly IGeneratorService generatorService;

    public GeneratorController(IGeneratorService generatorService)
    {
        this.generatorService = generatorService;
    }

    [HttpPost("generate")]
    public List<Dictionary<string, object>> Generate([FromBody] string? estrutura, int quantidade)
    {
        if (quantidade <= 0 )
        {
            quantidade = 1;
        }

        if (estrutura.IsNullOrEmpty())
        {
            estrutura = "Teste String 10 100";
        }

        return generatorService.Generate(estrutura!, quantidade);
        
    }
}
