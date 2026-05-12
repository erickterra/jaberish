using Jaberish.Models;

namespace Jaberish.Services
{
    public interface IGeneratorService
    {
        public List<Dictionary<string, object>> Generate(string estrutura, int quantidade);
    }
}
