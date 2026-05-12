
namespace Jaberish.Models;

public class Field
{
    public string Nome { get; set; }

    public Tipos Tipo { get; set; } = Tipos.String;
    public int? Max { get; set; }
    public int? Min { get; set; }

    public List<string>? Options;
}

public enum Tipos
{
    String,
    Integer,
    Decimal,
    Boolean,
    DateTime,
    Enum
}

