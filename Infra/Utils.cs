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

        public static string NomeAleatorio()
        {
            var random = new Random();

            int i = random.Next(0, Nomes.Length);

            return Nomes[i];
        }

        public static string SobreomeAleatorio()
        {
            var random = new Random();

            int i = random.Next(0, Sobrenomes.Length);

            return Sobrenomes[i];
        }

        public static string[] Nomes =
        [
            "Arthur", "André", "Augusto", "Amanda", "Ana", "Alice",
            "Bruno", "Bernardo", "Breno", "Bianca", "Beatriz", "Bruna",
            "Carlos", "Caio", "Cesar", "Camila", "Clara", "Carolina",
            "Daniel", "Diego", "Davi", "Daniela", "Debora", "Diana",
            "Eduardo", "Enzo", "Elias", "Eduarda", "Elaine", "Ester",
            "Felipe", "Fabio", "Fernando", "Fernanda", "Fabiana", "Flavia",
            "Gabriel", "Gustavo", "Guilherme", "Gabriela", "Giovana", "Gisele",
            "Henrique", "Heitor", "Hugo", "Helena", "Heloisa", "Hadassa",
            "Igor", "Ian", "Ítalo", "Isabela", "Ingrid", "Ivone",
            "João", "José", "Jorge", "Julia", "Juliana", "Jade",
            "Kaique", "Kevin", "Kauã", "Karen", "Karina", "Kelly",
            "Lucas", "Leonardo", "Luiz", "Larissa", "Leticia", "Luana",
            "Matheus", "Marcos", "Miguel", "Mariana", "Maria", "Melissa",
            "Nicolas", "Nathan", "Nelson", "Natalia", "Nicole", "Nubia",
            "Otavio", "Oscar", "Oliver", "Olivia", "Ornella", "Odete",
            "Pedro", "Paulo", "Patrick", "Patricia", "Paula", "Priscila",
            "Quirino", "Quentin", "Queiroz", "Quezia", "Quiteria", "Quiana",
            "Rafael", "Rodrigo", "Ricardo", "Renata", "Rafaela", "Rosana",
            "Samuel", "Sergio", "Silvio", "Sabrina", "Simone", "Sandra",
            "Thiago", "Thomas", "Tiago", "Tatiane", "Tais", "Tamara",
            "Ulisses", "Ubirajara", "Uriel", "Ursula", "Ubiraci", "Uriana",
            "Vinicius", "Victor", "Vagner", "Vanessa", "Valeria", "Vitoria",
            "William", "Wesley", "Wallace", "Wanda", "Wendy", "Wilma",
            "Xavier", "Xande", "Xisto", "Ximena", "Xuxa", "Xenia",
            "Yago", "Yuri", "Yan", "Yasmin", "Yara", "Yolanda",
            "Zeca", "Zion", "Zildo", "Zilda", "Zoe", "Zuleica"
        ];

        public static string[] Sobrenomes =
        [
            "Almeida", "Alves", "Amaral",
            "Barbosa", "Barros", "Batista",
            "Cardoso", "Carvalho", "Castro",
            "Dias", "Duarte", "Domingues",
            "Esteves", "Evangelista", "Espindola",
            "Ferreira", "Fernandes", "Figueiredo",
            "Gomes", "Gonçalves", "Garcia",
            "Henriques", "Hoffmann", "Hidalgo",
            "Ibrahim", "Ivo", "Izidoro",
            "Jesus", "Jardim", "Junqueira",
            "Klein", "Kuster", "Kawasaki",
            "Lima", "Lopes", "Leite",
            "Machado", "Martins", "Moraes",
            "Nascimento", "Nogueira", "Neves",
            "Oliveira", "Ortega", "Osorio",
            "Pereira", "Pinto", "Peixoto",
            "Queiroz", "Quaresma", "Quintana",
            "Rodrigues", "Ramos", "Rocha",
            "Silva", "Santos", "Souza",
            "Teixeira", "Tavares", "Torres",
            "Uchoa", "Urbano", "Ulhoa",
            "Vieira", "Vasconcelos", "Valente",
            "Wagner", "Werneck", "Wolff",
            "Xavier", "Ximenes", "Xisto",
            "Yamamoto", "Yoshida", "Yamada",
            "Zanetti", "Zago", "Zucci"
        ];
    }
}
