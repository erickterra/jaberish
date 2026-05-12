namespace Jaberish.Infra
{
    public static class Utils
    {
        public static string RandomString(int min = 1, int max = 10)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var random = new Random();

            int tamanho = random.Next(min, (max + 1));

            return new string(
                Enumerable.Repeat(chars, tamanho)
                    .Select(x => x[Random.Shared.Next(x.Length)])
                    .ToArray()
            );
        }
    }
}
