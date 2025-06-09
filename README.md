
# Green Light API - Monitoramento Ambiental Escolar

API desenvolvida em .NET (Web API), conectada ao banco Oracle, para gestão de riscos climáticos em escolas públicas, permitindo monitoramento de sensores, leituras ambientais e emissão de alertas automáticos.

## 🏫 Contexto

Com o aumento das ondas de calor, escolas precisam de informações para agir preventivamente. Esta API oferece cadastro de escolas, sensores, leituras de temperatura/umidade e alertas automáticos, permitindo integração com dashboards e aplicativos externos.

## ⚙️ Principais Funcionalidades

- CRUD completo para Escolas, Sensores, Leituras e Alertas
- Persistência em Oracle Database (FIAP)
- Boas práticas RESTful: HATEOAS e Rate Limit
- Documentação automática via Swagger
- Envio de alertas para RabbitMQ (microserviços)
- Predição de risco com ML.NET
- Testes automatizados xUnit

## 🚀 Como rodar localmente

1. Clone o repositório:
```bash
git clone https://github.com/seu-usuario/seu-repo.git
cd seu-repo
```

2. Configure o banco de dados:
```json
"ConnectionStrings": {
  "DefaultConnection": "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=oracle.fiap.com.br:1521/orcl;"
}
```

3. Instale as dependências:
```bash
dotnet restore
```

4. Execute a aplicação:
```bash
dotnet run --project SensorClean.WebAPI
```
Acesse [http://localhost:5071/swagger](http://localhost:5071/swagger) para testar.

---

## 📚 Principais Endpoints e exemplos

### Escola (`/api/school`)
**Criar escola:**
```json
POST /api/school
{
  "name": "EMEF João Silva",
  "city": "São Paulo",
  "state": "SP",
  "ativo": "S"
}
```
**Buscar todas:** `GET /api/school`  
**Buscar por ID:** `GET /api/school/1`  
**Atualizar:**  
```json
PUT /api/school/1
{
  "id": 1,
  "name": "EMEF Atualizada",
  "city": "São Paulo",
  "state": "SP",
  "ativo": "S"
}
```
**Remover:** `DELETE /api/school/1`

### Sensor (`/api/sensor`)
```json
POST /api/sensor
{
  "idEscola": 1,
  "localizacao": "Sala 1",
  "ativo": "S",
  "tipo": "temperatura",
  "descricao": "Sensor principal"
}
```
**Buscar todos:** `GET /api/sensor`

### Leitura (`/api/reading`)
```json
POST /api/reading
{
  "idSensor": 1,
  "temperatura": 35.5,
  "umidade": 75.2,
  "timestampLeitura": "2024-06-06T12:00:00"
}
```
**Buscar todas:** `GET /api/reading`

### Alerta (`/api/alert`)
```json
POST /api/alert
{
  "idLeitura": 1,
  "tipo": "Calor Extremo",
  "mensagem": "Temperatura acima do seguro.",
  "nivel": "Crítico",
  "status": "Emitido",
  "timestampAlerta": "2024-06-06T12:10:00"
}
```
**Buscar todos:** `GET /api/alert`

---

## 🔗 Exemplo de resposta HATEOAS

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

## ⏳ Exemplo de Rate Limit

- A API retorna HTTP 429 (Too Many Requests) caso ultrapasse o limite de 10 requisições por minuto por IP.
- Configurável via appsettings.json.

---

## 🛠️ RabbitMQ e ML.NET

- Ao criar um alerta, uma mensagem JSON é enviada para a fila `alertas` no RabbitMQ.
- O risco previsto de incidente é calculado via ML.NET e incluso na mensagem do alerta.

---

## 🧪 Exemplos de testes xUnit

```csharp
[Fact]
public void CreateSchool_ReturnsCreatedSchool()
{
    var school = new SchoolModel { Name = "Nova", City = "SP", State = "SP", Ativo = "S" };
    var mockRepo = new Mock<ISchoolRepository>();
    mockRepo.Setup(r => r.Create(It.IsAny<SchoolModel>())).Returns(school);
    var useCase = new CreateSchool(mockRepo.Object);
    var created = useCase.Create(school);
    Assert.Equal("Nova", created.Name);
}
```

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

## 👥 Contribuição

Pull requests são bem-vindos!  
Sugestões, dúvidas ou feedback? Abra uma issue ou me encontre no LinkedIn.

---

## 🛡️ Licença

MIT
