# Desafio Authentication - BackendBr

Link do desafio: https://github.com/backend-br/desafios/blob/master/authentication/PROBLEM.md

---

## Descrição

O Worker atuará como um mini servidor HTTP leve e dedicado à validação de tokens via requisições HTTP,
utilizando injeção de dependência e arquitetura em camadas para manter o projeto limpo, desacoplado e testável.

## Tecnologias e Ferramentas Utilizadas
- C# (.NET 8)
- Postman (para testes de requisições HTTP)

---

## 🚀 Como Executar

1. Clone o repositório:
   ```
   git clone https://github.com/seu-repositorio/authentication.git
   cd authentication
   ```

2. - Compile e execute o projeto com o .NET CLI:
	```
	dotnet build
	dotnet run
    ```

   - Ou abra o projeto no Visual Studio e execute a aplicação.

3. Utilizando o Postman ou qualquer ferramenta de requisições HTTP (Postman):

   - Crie uma nova requisição GET.
   - Insira a URL:
	 ```
	 http://localhost:5000/ValidateToken/
	 ```
   - No cabeçalho, adicione o campo `Authorization` com o valor do token que deseja validar.
	- Valor do token: `p4$$0rD`.

   - Clique em "Send" para enviar a requisição.

4. Resultado esperado:
   - Se o token for válido, será retornado o status `204 No Content`.
   - Se o token for inválido, você receberá uma resposta JSON com o status `401 Unauthorized` e a mensagem de erro.

---

## Estrutura das pastas

```
Authentication/
├── Properties/
│   └── launchSettings.json
├── Interfaces/
│   └── ICryptoService.cs
│   └── ITokenValidator.cs
├── Request/
│   └── HttpRequestHandler.cs
├── Validator/
│   └── CryptoService.cs
│   └── TokenValidator.cs
├── appsettings.json
├── Problem.md
├── Program.cs
├── Worker.cs
```
