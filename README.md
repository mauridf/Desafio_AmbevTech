
# Desafio_AmbevTech

Protótipo de API de Vendas para a empresa 123Vendas.

## Tecnologias

- .NET 8
- SQL Server
- EF Core
- Serilog
- JWT Authentication
- XUnit, FluentAssertions, Bogus, NSubstitute
- TestContainers (integração)
- Docker

## Estrutura do Projeto

- `Desafio.Api` → API REST, Controllers, Swagger
- `Desafio.Data` → DbContext, Repositórios
- `Desafio.Domain` → Entidades, Eventos, Lógica de negócio
- `Desafio.Application` → DTOs e Mappers
- `Desafio.Tests.Unit` → Testes unitários
- `Desafio.Tests.Integration` → Testes de integração com container SQL Server

## Requisitos

- .NET 8 SDK
- SQL Server (local)

---

## Executando Localmente

1. Clonar o repositório:

```bash
git clone <repo-url>
cd Desafio_AmbevTech
```

2. Configurar connection string em `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=DesafioAmbevTech;User Id=sa;Password=SuaSenha123;"
}
```
3. Configurar JWT em `appsettings.json`:

```json
"Jwt": {
    "Key": "troque_essa_chave_por_uma_muito_segura_e_longa",
    "Issuer": "Desafio_AmbevTech",
    "Audience": "Desafio_AmbevTechUsers",
    "ExpiresMinutes": 60
}
```

4. Executar migrations e iniciar API:

```bash
cd src/Desafio.Api
dotnet ef database update
dotnet run
```

5. Acessar Swagger:

```text
https://localhost:5001/swagger/index.html
```

6. Usuário Seed:

```
Username: admin
Password: Teste@123
```

- Use o endpoint `/api/v1/auth/login` para obter o JWT Bearer e testar os endpoints.

---

## Download do projeto

Você pode baixar o projeto completo diretamente do GitHub:

[Desafio_AmbevTech - GitHub](https://github.com/mauridf/Desafio_AmbevTech)

- Clone ou baixe o ZIP.
- Siga os passos acima para configuração e execução local.
