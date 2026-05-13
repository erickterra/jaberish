# Jaberish API

API para geração de dados aleatórios baseada em campos dinâmicos.
Disponível em [https://jaberish.onrender.com/](https://jaberish.onrender.com/swagger/index.html)]

---

# Como funciona

A API recebe uma string contendo os campos que devem ser gerados.

Cada campo deve seguir um formato específico.

Os campos devem ser separados por `;`.

---

# Estrutura do comando

```txt
NomeCampo Tipo Min Max; NomeCampo Tipo Min Max
```

| Parâmetro | Descrição |
|---|---|
| `NomeCampo` | Nome da propriedade no JSON Final|
| `Tipo` | Tipo do dado a ser gerado |
| `Min` | Valor mínimo |
| `Max` | Valor máximo |

---

# Tipos suportados

| Tipo | Descrição |
|---|---|
| `Nome` | Gera nomes aleatórios |
| `Sobrenome` | Gera sobrenomes aleatórios |
| `String` | Texto aleatório |
| `Integer` | Número inteiro aleatório |
| `Decimal` | Número decimal aleatório |
| `Boolean` | Verdadeiro ou falso |
| `DateTime` | Data aleatória |
| `Enum` | Escolhe aleatoriamente um valor entre uma lista fornecida |


---

# Tipo `Nome`

O tipo `Nome` gera nomes aleatórios a partir de uma lista interna de nomes próprios.

## Formato

```txt
NomeCampo Nome Min Max
```

## Exemplo

Entrada:

```txt
NomeCompleto Nome 1 2
```

Resposta:

```json
{
  "NomeCompleto": "Lucas Henrique"
}
```

A API irá gerar entre `Min` e `Max` nomes aleatórios concatenados.

---

# Tipo `Sobrenome`

O tipo `Sobrenome` gera sobrenomes aleatórios a partir de uma lista interna de sobrenomes.

## Formato

```txt
NomeCampo Sobrenome Min Max
```

## Exemplo

Entrada:

```txt
SobrenomeCompleto Sobrenome 1 2
```

Resposta:

```json
{
  "SobrenomeCompleto": "Silva Oliveira"
}
```

A API irá gerar entre `Min` e `Max` sobrenomes aleatórios concatenados.

---

# Tipo `String`

## Formato

```txt
NomeCampo String Min Max
```

## Exemplo

Entrada:

```txt
Nome String 10 20
```

Resposta:

```json
{
  "Nome": "asdhqwejkzx"
}
```

A string terá entre 10 e 20 caracteres.

---

# Tipo `Integer`

## Formato

```txt
NomeCampo Integer Min Max
```

## Exemplo

Entrada:

```txt
Idade Integer 18 60
```

Resposta:

```json
{
  "Idade": 34
}
```

O Integer será um número entre 18 e 60.

---

# Tipo `Decimal`

## Formato

```txt
NomeCampo Decimal 1000 5000
```

## Exemplo

Entrada:

```txt
Salario Decimal 1000 5000
```

Resposta:

```json
{
  "Salario": 3487.42
}
```

O Decimal será um Número entre 1000 e 5000, com 2 casas decimais aleatórias.

---

# Tipo `Boolean`

## Formato

```txt
NomeCampo Boolean
```

## Exemplo

Entrada:

```txt
Ativo Boolean
```

Resposta:

```json
{
  "Ativo": true
}
```

Será um Bool aleatoriamente true e false.

---

# Tipo `Enum`

O tipo `Enum` permite escolher aleatoriamente um valor entre uma lista de opções.

## Formato

```txt
NomeCampo Enum (Valor1,Valor2,Valor3)
```

## Regras

- Os valores devem ficar entre `()`
- Os valores devem ser separados por `,`
- Não deve haver espaços dentro dos parênteses
- A API selecionará aleatoriamente um dos valores informados

## Exemplo

Entrada:

```txt
Status Enum (Ativo,Inativo,Pendente)
```

Resposta:

```json
{
  "Status": "Ativo"
}
```

## Formato válido

```txt
Tipo Enum (A,B,C,D)
```

## Formato inválido

```txt
Tipo Enum (A, B, C, D)
```

O formato inválido contém espaços dentro do `()`.

---

# Como consumir a API

## Endpoint

```txt
POST /api/Generator?quantidade=10
```

| Parâmetro | Descrição |
|---|---|
| `quantidade` | Quantidade de objetos gerados |

---

# Body da requisição

Enviar uma string simples:

```txt
Nome String 10 20; Idade Integer 18 60
```

---

# Exemplo usando Axios

```ts
const response = await api.post(
  '/api/generate?quantidade=10',
  JSON.stringify("Nome String 10 20; Idade Integer 18 60"),
  {
    headers: {
      'Content-Type': 'application/json'
    }
  }
);
```

---

# Resposta esperada

```json
[
  {
    "Nome": "abcxyzqwe",
    "Idade": 25
  },
  {
    "Nome": "lmnopqrs",
    "Idade": 41
  }
]
```

---

# Exemplo completo

Entrada:

```txt
Nome Nome 1 2;
Sobrenome Sobrenome 1 2;
Idade Integer 18 80;
Cargo Enum (Junior,Pleno,Senior,Especialista);
Salario Decimal 1500 12000;
Ativo Boolean;
DataContratacao DateTime;
```

Resposta:

```json
{
  "Nome": "Lucas Henrique",
  "Sobrenome": "Silva Oliveira",
  "Idade": 29,
  "Cargo": "Senior",
  "Salario": 7854.22,
  "Ativo": true,
  "DataContratacao": "2026-08-05T09:57:14.1613204-03:00"
}
```

---

# Regras importantes

- Os campos devem ser separados por `;`
- Os parâmetros devem estar separados por espaço
- `Min` e `Max` devem ser números válidos
- O nome do campo não pode conter espaços
- Tipos inválidos serão ignorados ou retornarão erro
- Valores do `Enum` devem ser separados por vírgula e não deve haver espaços dentro do `()`

---

# Casos de uso

- Mock de APIs
- Testes automatizados
- Seed de banco de dados
- Desenvolvimento frontend
- Protótipos rápidos
- Testes de performance

---

# English Version

# Jaberish API

API for generating random data based on dynamic field definitions.
Available at [https://jaberish.onrender.com/](https://jaberish.onrender.com/swagger/index.html)]

---

# How it works

The API receives a string containing the fields that should be generated.

Each field must follow a specific format.

Fields must be separated using `;`.

---

# Command Structure

```txt
FieldName Type Min Max; FieldName Type Min Max
```

| Parameter | Description |
|---|---|
| `FieldName` | Property name in the result JSON response |
| `Type` | Type of data to generate |
| `Min` | Minimum value |
| `Max` | Maximum value |

---

# Supported Types

| Type | Description |
|---|---|
| `Name` | Generates random names |
| `Surname` | Generates random surnames |
| `String` | Random text |
| `Integer` | Random integer number |
| `Decimal` | Random decimal number |
| `Boolean` | True or false |
| `DateTime` | Random date |
| `Enum` | Randomly selects a value from a list |

---

# `Name` Type

The `Name` type generates random first names from an internal name list.

## Format

```txt
FieldName Name Min Max
```

## Example

Input:

```txt
FullName Name 1 2
```

Output:

```json
{
  "FullName": "Lucas Henrique"
}
```

The API will generate between `Min` and `Max` random names concatenated together.

---

# `Surname` Type

The `Surname` type generates random surnames from an internal surname list.

## Format

```txt
FieldName Surname Min Max
```

## Example

Input:

```txt
FullSurname Surname 1 2
```

Output:

```json
{
  "FullSurname": "Silva Oliveira"
}
```

The API will generate between `Min` and `Max` random surnames concatenated together.

---

# `String` Type

## Format

```txt
FieldName String 10 20
```

## Example

Input:

```txt
Name String 10 20
```

Output:

```json
{
  "Name": "asdhqwejkzx"
}
```

The generated string will contain between 10 and 20 characters.

---

# `Integer` Type

## Format

```txt
FieldName Integer 18 60
```

## Example

Input:

```txt
Age Integer 18 60
```

Output:

```json
{
  "Age": 34
}
```

Integer will be a value between 18 and 60.

---

# `Decimal` Type

## Format

```txt
FieldName Decimal 1000 5000
```

## Example

Input:

```txt
Salary Decimal 1000 5000
```

Output:

```json
{
  "Salary": 3487.42
}
```

Decimal will be a number between 1000 and 5000 with 2 random decimal places.

---

# `Boolean` Type

## Format

```txt
FieldName Boolean
```

## Example

Input:

```txt
Active Boolean
```

Output:

```json
{
  "Active": true
}
```

Will be a Bool randomly true or false.

---

# `Enum` Type

The `Enum` type allows the API to randomly select one value from a list.

## Format

```txt
FieldName Enum (Value1,Value2,Value3)
```

## Rules

- Values must be inside `()`
- Values must be separated using `,`
- No spaces are allowed inside the parentheses

## Example

Input:

```txt
Status Enum (Active,Inactive,Pending)
```

Output:

```json
{
  "Status": "Active"
}
```

The API will randomly select one of the provided values.

---

# How to consume the API

## Endpoint

```txt
POST /api/Generator?quantidade=10
```

| Parameter | Description |
|---|---|
| `quantidade` | Amount of objects to generate |

---

# Request Body

Send a plain string:

```txt
Name String 10 20; Age Integer 18 60
```

---

# Axios Example

```ts
const response = await api.post(
  '/api/generate?quantidade=10',
  JSON.stringify("Name String 10 20; Age Integer 18 60"),
  {
    headers: {
      'Content-Type': 'application/json'
    }
  }
);
```

---

# Expected Response

```json
[
  {
    "Name": "abcxyzqwe",
    "Age": 25
  },
  {
    "Name": "lmnopqrs",
    "Age": 41
  }
]
```

---

# Complete Example

Input:

```txt
Name Name 1 2;
LastName Surname 1 2;
Age Integer 18 80;
Role Enum (Junior,MidLevel,Senior,Specialist);
Salary Decimal 1500 12000;
Active Boolean;
HireDate DateTime
```

Output:

```json
{
  "Name": "Lucas Henrique",
  "LastName": "Silva Oliveira",
  "Age": 29,
  "Role": "Senior",
  "Salary": 7854.22,
  "Active": true,
  "HireDate": "2026-08-05T09:57:14.1613204-03:00"
}
```

---

# Important Rules

- Fields must be separated using `;`
- Parameters must be separated using spaces
- `Min` and `Max` must be valid numbers
- Field names cannot contain spaces
- Invalid types will be ignored or return an error
- Enum values must be separated using commas, and no spaces are allowed inside Enum parentheses

---

# Use Cases

- API mocking
- Automated tests
- Database seeding
- Frontend development
- Rapid prototyping
- Performance testing
