# Locadora de Carros — API REST

API REST em ASP.NET Core para cadastro de carros e cálculo de locações.

**Stack:** .NET 10 · ASP.NET Core · Entity Framework Core 8 · Oracle

---

## Como rodar

**1. Configure suas credenciais** em `LocacaoDeCarros/appsettings.json`:
```json
"OracleConnection": "User Id=rmSEURM;Password=SUASENHA;Data Source=..."
```

**2. Instale o dotnet-ef (se necessário):**
```bash
dotnet tool install --global dotnet-ef
```

**3. Crie o banco e rode:**
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

---

## Endpoints

### Carros — `/api/carros`

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/carros` | Lista todos |
| GET | `/api/carros/{id}` | Busca por ID |
| POST | `/api/carros` | Cria novo carro |
| PUT | `/api/carros/{id}` | Atualiza carro |
| DELETE | `/api/carros/{id}` | Remove carro |

**Body (POST/PUT):**
```json
{
  "modelo": "Civic",
  "marca": "Honda",
  "ano": 2020,
  "valorDiaria": 150.00
}
```

---

### Locação — `/api/locacoes/calcular`

**POST** — calcula o valor da locação sem salvar no banco.

**Body:**
```json
{
  "carroId": 1,
  "dataInicio": "2025-04-25",
  "dataFim": "2025-04-30"
}
```

**Resposta:**
```json
{
  "carro": "Civic",
  "marca": "Honda",
  "dataInicio": "2025-04-25T00:00:00",
  "dataFim": "2025-04-30T00:00:00",
  "valorDiaria": 150.00,
  "subtotal": 750.00,
  "desconto": "5%",
  "valorFinal": 712.50
}
```

---

## Regra de Desconto

| Dias | Desconto |
|------|----------|
| < 3 | Sem desconto |
| 3 a 6 | 5% |
| >= 7 | 10% |
