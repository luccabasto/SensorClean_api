
# Green Light - API para Monitoramento Ambiental em Escolas Públicas 🌱

API desenvolvida para o projeto **Green Light**: plataforma inteligente de prevenção de riscos climáticos em escolas públicas, focada no monitoramento ambiental e emissão de alertas automáticos em situações de calor extremo. Desenvolvida em .NET, conectada a banco de dados Oracle, seguindo Clean Architecture.

---

### Integrantes

Lucas Bastos - 553771<br/>
Erick Lopes - 553927<br/>
Marcelo Galli - 55365

---

## 🏫 **Contexto**

Com o aumento das ondas de calor, escolas públicas precisam de informação rápida para agir e proteger alunos. Esta API permite cadastrar escolas, sensores, registrar leituras ambientais (temperatura, umidade) e emitir alertas automáticos para gestão escolar, tudo via endpoints RESTful.

---

## ⚙️ **Principais Funcionalidades**

- CRUD de Escolas, Sensores, Leituras e Alertas
- Conectada ao banco Oracle já existente da rede pública
- Estrutura Clean Architecture (Domain, Application, Infra, WebAPI)
- **Documentação automática via Swagger**
- [**(Opcional)**] Rate Limit para proteger de abusos
- [**(Opcional)**] Respostas com HATEOAS

---

## 🚀 **Como rodar localmente**

### 1. **Clone o repositório**
```bash
git clone https://github.com/seu-usuario/seu-repo.git
cd seu-repo
```

### 2. **Configure o banco de dados**
- Edite o arquivo `appsettings.json` com sua connection string Oracle:
```json
"ConnectionStrings": {
  "DefaultConnection": "User Id=usuario;Password=senha;Data Source=localhost:1521/XEPDB1;"
}
```

### 3. **Instale as dependências**
```bash
dotnet restore
```

### 4. **Execute a aplicação**
```bash
dotnet run --project SensorClean.WebAPI
```
Acesse [http://localhost:5000/swagger](http://localhost:5000/swagger) para testar os endpoints via Swagger!

---

## 📝 **Principais Endpoints**

### **Escolas**
| Método | Rota            | Descrição              |
|--------|-----------------|------------------------|
| GET    | /api/school     | Lista todas escolas    |
| GET    | /api/school/{id}| Consulta por ID        |
| POST   | /api/school     | Cria nova escola       |
| PUT    | /api/school/{id}| Atualiza escola        |
| DELETE | /api/school/{id}| Remove escola          |

### **Sensores**
| Método | Rota             | Descrição              |
|--------|------------------|------------------------|
| GET    | /api/sensor      | Lista todos sensores   |
| POST   | /api/sensor      | Cria novo sensor       |

### **Leituras**
| Método | Rota             | Descrição              |
|--------|------------------|------------------------|
| GET    | /api/reading     | Lista todas leituras   |
| POST   | /api/reading     | Registra nova leitura  |

### **Alertas**
| Método | Rota             | Descrição              |
|--------|------------------|------------------------|
| GET    | /api/alert       | Lista todos alertas    |
| POST   | /api/alert       | Cria novo alerta       |

---

## 💡 **Exemplo de Request**

### **Criar uma escola**
```json
POST /api/school
{
  "name": "EMEF João Silva",
  "city": "São Paulo",
  "state": "SP",
  "isActive": "S"
}
```

### **Adicionar um sensor**
```json
POST /api/sensor
{
  "idEscola": 1,
  "localizacao": "Sala 4",
  "ativo": "S",
  "tipo": "temperatura",
  "descricao": "Sensor principal do pátio"
}
```

---

## 🔐 **Boas Práticas e Diferenciais**

- **Camadas bem definidas** (Domain, Application, Infra, WebAPI)
- **Models em inglês, mapping para Oracle 100% por Fluent API**
- **Pronto para Deploy em Azure, AWS, On-Premise ou Docker**
- [**A implementar**] Rate Limit e HATEOAS para mais pontos!

---

## 📚 **Como testar via Swagger**

1. Rode a API (`dotnet run`)
2. Acesse [http://localhost:5000/swagger](http://localhost:5000/swagger)  
3. Clique no endpoint desejado e preencha o body para testar

---

## 👥 **Contribuição**

Pull requests são bem-vindos!  
Sugestões e feedback? Abra uma issue ou me encontre no LinkedIn.

---

## 🛡️ **Licença**

MIT

---
