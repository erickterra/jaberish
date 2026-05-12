using Jaberish.Infra;
using Jaberish.Models;

namespace Jaberish.Services
{
    public class GeneratorService : IGeneratorService
    {
        public List<Dictionary<string, object>> Generate(string estrutura, int quantidade)
        {
            var fields =
            estrutura.Split(';', StringSplitOptions.RemoveEmptyEntries)
       .Select(x =>
       {
           var partes = x.Split(' ', StringSplitOptions.RemoveEmptyEntries);
           var field = new Field
           {
               Nome = partes[0].Trim(),
               Tipo = Enum.Parse<Tipos>(partes[1].Trim(), true),
           };

           if (field.Tipo == Tipos.Enum)
           {
               field.Options = partes[2].Trim().Replace("(", "").Replace(")", "").Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
           }
           else
           {
               if (partes.Length > 3)
               {
                   if (int.TryParse(partes[2].Trim(), out int i))
                   {
                       field.Min = i;
                   }

                   if (int.TryParse(partes[3].Trim(), out int j))
                   {
                       field.Max = j;
                   }

                   return field;
               }

               if (partes.Length > 2)
               {
                   if (int.TryParse(partes[2].Trim(), out int i))
                   {
                       field.Max = i;
                   }
               }
           }

           return field;
       })
       .ToList();

            var random = new Random();
            var retorno = new List<Dictionary<string, object>>();

            for (int i = 0; i < quantidade; i++)
            {
                var resultado = new Dictionary<string, object>();
                foreach (Field field in fields)
                {
                    switch (field.Tipo)
                    {
                        case Tipos.String:
                            resultado[field.Nome] = Utils.RandomString(field.Min ?? 1, (field.Max ?? 10) + 1);
                            break;

                        case Tipos.Nome:
                        case Tipos.Name:
                            int amt = random.Next(field.Min ?? 1, (field.Max ?? 1) + 1);
                            string nome = "";
                            for (int j = 0; j < amt; j++)
                            {
                                if (j > 0)
                                {
                                    nome += " ";
                                }
                                nome += Utils.NomeAleatorio();
                            }
                            resultado[field.Nome] = nome;
                            break;

                        case Tipos.Sobrenome:
                        case Tipos.Surname:
                            int amt2 = random.Next(field.Min ?? 1, (field.Max ?? 1) + 1);
                            string sobrenome = "";
                            for (int j = 0; j < amt2; j++)
                            {
                                if (j > 0)
                                {
                                    sobrenome += " ";
                                }
                                sobrenome += Utils.SobreomeAleatorio();
                            }
                            resultado[field.Nome] = sobrenome;
                            break;

                        case Tipos.Integer:
                            resultado[field.Nome] = random.Next(field.Min ?? 0, (field.Max ?? 100) + 1);
                            break;

                        case Tipos.Decimal:
                            decimal baseNum = random.Next(field.Min ?? 0, field.Max ?? 100);
                            resultado[field.Nome] = baseNum + Math.Round((decimal)random.NextDouble(), 2);

                            break;

                        case Tipos.Boolean:
                            resultado[field.Nome] = random.Next(0, 2) == 1;
                            break;

                        case Tipos.DateTime:
                            resultado[field.Nome] =
                           DateTime.Now.AddDays(random.Next(-365, 365));
                            break;

                        case Tipos.Enum:
                            if (field.Options?.Count > 0)
                            {
                                resultado[field.Nome] = field.Options?[random.Next(0, field.Options.Count)] ?? "";
                            }
                            else
                            {
                                resultado[field.Nome] = "";
                            }

                            break;

                        default:
                            resultado[field.Nome] = "";
                            break;
                    }
                }

                retorno.Add(resultado);
            }

            return retorno;
        }
    }
}
