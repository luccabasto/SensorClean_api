
# Green Light API

API em .NET (Web API) para monitoramento ambiental e alertas em escolas públicas.  
Funciona com banco Oracle, integra RabbitMQ e ML.NET, cobre CRUD, práticas RESTful e testes automatizados.

---

## 🏫 Contexto

Com o aumento das ondas de calor, escolas precisam de informações para agir preventivamente. Esta API oferece cadastro de escolas, sensores, leituras de temperatura/umidade e alertas automáticos, permitindo integração com dashboards e aplicativos externos.

---

## 👨‍💻 Integrantes

Lucas Bastos - 553771  
Erick Lopes - 553927  
Marcelo Galli - 55365  

---

## ⚙️ Funcionalidades

- CRUD completo para escolas, sensores, leituras e alertas
- Documentação Swagger disponível em `/swagger`
- Rate Limit para evitar abuso (10 req/min por IP)
- HATEOAS em rotas de detalhe
- Envio de alertas para fila RabbitMQ
- ML.NET para predição de risco em alertas
- Testes xUnit para UseCases

---

## Como rodar

1. **Clone o repositório:**
   ```sh
   git clone https://github.com/seu-usuario/seu-repo.git
   cd seu-repo
   ```

2. **Configure a connection string do Oracle** no `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=oracle.fiap.com.br:1521/orcl;"
   }
   ```

3. **Instale as dependências:**
   ```sh
   dotnet restore
   ```

4. **Execute a aplicação:**
   ```sh
   dotnet run --project SensorClean.WebAPI
   ```
   E acesse `/swagger` no navegador.

---

## Exemplos de requisições

### Criar escola (POST `/api/school`)
```json
{
  "name": "EMEF João Silva",
  "city": "São Paulo",
  "state": "SP",
  "ativo": "S"
}
```

### Criar alerta (POST `/api/alert`)
```json
{
  "idLeitura": 1,
  "tipo": "Calor Extremo",
  "mensagem": "Temperatura acima do seguro.",
  "nivel": "Crítico",
  "status": "Emitido",
  "timestampAlerta": "2024-06-06T12:10:00"
}
```

---

## Resposta HATEOAS (exemplo)
```json
{
  "result": {
    "id": 1,
    "name": "EMEF João Silva",
    "city": "São Paulo",
    "state": "SP",
    "ativo": "S"
  },
  "_links": {
    "self": "/api/school/1",
    "update": "/api/school/1",
    "delete": "/api/school/1"
  }
}
```

---

## Testes automatizados (xUnit/Moq)

### SchoolServiceTests.cs
```csharp
[Fact]
public void CreateSchool_ReturnsCreatedSchool()
{
    var school = new SchoolModel { Name = "Nova", City = "SP", State = "SP", IsActive = "S" };
    var mockRepo = new Mock<ISchoolRepository>();
    mockRepo.Setup(r => r.Create(It.IsAny<SchoolModel>())).Returns(school);
    var useCase = new CreateSchool(mockRepo.Object);
    var created = useCase.Create(school);
    Assert.Equal("Nova", created.Name);
}
```

### AlertServiceTests.cs
```csharp
[Fact]
public void CreateAlert_ReturnsCreatedAlert()
{
    var alert = new AlertModel { Tipo = "Calor", Mensagem = "Atenção!", Nivel = "Alto", Status = "Emitido", TimestampAlerta = DateTime.Now };
    var mockRepo = new Mock<IAlertRepository>();
    mockRepo.Setup(r => r.Create(It.IsAny<AlertModel>())).Returns(alert);
    var useCase = new CreateAlert(mockRepo.Object);
    var created = useCase.Create(alert);
    Assert.Equal("Atenção!", created.Mensagem);
}
```

---

## Rate Limit

Se fizer mais de 10 requisições/minuto, recebe HTTP 429 (Too Many Requests).

---

## RabbitMQ e ML.NET

- Alerta criado = mensagem JSON publicada na fila `alertas` (RabbitMQ)
- Predição de risco feita com ML.NET na lógica de alerta
