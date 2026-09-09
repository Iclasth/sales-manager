 # 📊 SalesManager

 Aplicação web para gerenciamento de **vendas, vendedores e departamentos**, desenvolvida com **C# e ASP.NET Core MVC**.

 O projeto nasceu como uma aplicação proposta pelo curso de C# completo com Programação Orientada a Objetos, fornecido pelo Nelio Alves, sendo MVC simples e foi evoluindo para uma estrutura mais organizada, com separação de responsabilidades através de services, persistência com Entity Framework Core, migrations, validações, operações assíncronas e recursos de consulta e filtragem de vendas.

 > Projeto desenvolvido com foco em prática de desenvolvimento web com .NET, modelagem de dados, arquitetura MVC e evolução incremental através do Git.

 ## ✨ Funcionalidades

 ### Vendas

 - Consulta de registros de vendas.
- Pesquisa de vendas por período.
- Pesquisa agrupada por departamento.
- Exibição de vendedor e departamento relacionados à venda.
- Formatação de datas e valores monetários.
- Operações de acesso a dados de forma assíncrona.

 ### Vendedores

 - Listagem de vendedores.
- Cadastro de vendedores.
- Visualização de detalhes.
- Edição de vendedores.
- Exclusão de vendedores.
- Associação do vendedor a um departamento.
- Carregamento dos relacionamentos necessários para exibição dos dados.

 ### Departamentos

 - Cadastro e gerenciamento de departamentos.
- Listagem de departamentos.
- Visualização de detalhes.
- Edição e exclusão.
- Relacionamento com vendedores e registros de vendas.

 ### Aplicação

 - Interface baseada em ASP.NET Core MVC e Razor.
- Validação de dados nos formulários.
- Tratamento de erros e exceções específicas da aplicação.
- Proteção contra requisições de formulário indevidas com Anti-Forgery Token.
- Seed de dados para facilitar o desenvolvimento.
- Configuração de localização e formatação de dados.
- Separação da lógica de acesso a dados em services.

---

 ## 🧱 Arquitetura

 O projeto utiliza **ASP.NET Core MVC**, mantendo responsabilidades separadas entre controllers, models, views e services.

```
SalesManager
│
├── SalesManager.Web
│   ├── Controllers
│   │   ├── DepartmentsController
│   │   ├── HomeController
│   │   ├── SalesRecordsController
│   │   └── SellersController
│   │
│   ├── Data
│   │   └── SalesManagerDbContext
│   │
│   ├── Migrations
│   │
│   ├── Models
│   │   ├── Department
│   │   ├── Seller
│   │   ├── SalesRecord
│   │   ├── Enums
│   │   └── ViewModels
│   │
│   ├── Services
│   │   ├── DepartmentService
│   │   ├── SellerService
│   │   ├── SalesRecordService
│   │   └── Exceptions
│   │
│   ├── Views
│   │
│   ├── wwwroot
│   │
│   ├── Program.cs
│   └── appsettings.json
│
└── SalesManager.sln
```

 A aplicação possui atualmente controllers para departamentos, vendedores e registros de vendas, enquanto a camada de services concentra operações relacionadas à persistência e às consultas.  GitHub+1

---

 ## 🛠️ Tecnologias

 | Tecnologia | Utilização |
| --- | --- |
| **C#** | Linguagem principal |
| **.NET 8** | Plataforma de desenvolvimento |
| **ASP.NET Core MVC** | Estrutura da aplicação web |
| **Entity Framework Core 8** | ORM e acesso a dados |
| **SQL Server** | Banco de dados |
| **Docker/Podman** | Gerenciador de containers |
| **Razor** | Renderização das views |
| **HTML5 / CSS3** | Interface |
| **Bootstrap** | Estilização e responsividade |
| **JavaScript** | Comportamentos da interface |
| **Git / GitHub** | Versionamento |

 O projeto está configurado para `net8.0` e utiliza os pacotes do Entity Framework Core para SQL Server e SQLite, além das ferramentas de migrations.  GitHub

---

 ## 🗃️ Modelo de dados

 O domínio principal é composto por três entidades:

```
Department
    │
    └── Seller
           │
           └── SalesRecord
```

 Um **Department** pode possuir vários **Sellers**, enquanto cada registro de **SalesRecord** está associado a um vendedor.

 Essa estrutura permite consultar as vendas juntamente com seus relacionamentos e também realizar agrupamentos por departamento.

---

 ## 🔎 Consultas e pesquisa

 Um dos pontos de evolução do projeto foi a criação de uma camada específica para consultas de vendas.

 A aplicação passou a suportar pesquisa por intervalo de datas e, posteriormente, agrupamento dos resultados por departamento.

 Exemplo conceitual:

```
Período selecionado
       │
       ▼
SalesRecordService
       │
       ├── Filtra por data
       ├── Carrega Seller
       ├── Carrega Department
       └── Ordena os resultados
              │
              ▼
             View
```

 As consultas utilizam Entity Framework Core e métodos assíncronos como `ToListAsync()`, mantendo o acesso ao banco de dados sem bloquear a execução da aplicação.  GitHub+1

---

 ## 🧩 Services

 A aplicação utiliza services para evitar concentrar toda a lógica de persistência nos controllers.

 Entre eles:

 - `DepartmentService`
- `SellerService`
- `SalesRecordService`

 O `SellerService`, por exemplo, foi evoluído ao longo do projeto para oferecer operações de consulta, criação, atualização, exclusão e busca por identificador.  GitHub

 Essa abordagem deixa os controllers mais focados no fluxo HTTP e facilita a evolução das regras da aplicação.

---

 ## 🛡️ Validação e tratamento de erros

 Durante a evolução do projeto foram adicionados mecanismos para tornar o comportamento da aplicação mais previsível:

 - Validação de campos.
- ViewModels específicos para formulários.
- Tratamento de entidades inexistentes.
- Exceções personalizadas.
- Tratamento de problemas relacionados à integridade referencial.
- Proteção com `ValidateAntiForgeryToken`.
- Página de erro personalizada.
- Tratamento de conflitos durante operações de atualização.

 Também houve uma preocupação específica com o cenário em que uma entidade não pode ser removida devido a relacionamentos existentes no banco de dados.

---

 ## ⚡ Programação assíncrona

 As operações de acesso ao banco foram progressivamente convertidas para o padrão assíncrono utilizando:

```
async
await
Task
```

 Isso é aplicado principalmente nas operações de consulta e persistência realizadas através do Entity Framework Core.  GitHub

---

 ## 🗄️ Banco de dados e Migrations

 O projeto utiliza **Entity Framework Core Code First**.

 As alterações do modelo são versionadas através de migrations, permitindo acompanhar a evolução do banco junto com o código da aplicação.

 Durante o desenvolvimento também foi utilizado um banco SQL Server local para validar a integração com o Entity Framework Core. As credenciais da conexão foram mantidas fora do código através do mecanismo de **User Secrets**.  GitHub

---

 ## 🚀 Como executar o projeto

 ### Pré-requisitos

 Antes de começar, tenha instalado:

 - [.NET 8 SDK](<https://dotnet.microsoft.com/download/dotnet/8.0>)
- Um ambiente para executar SQL Server ou SQLite.
- Visual Studio, JetBrains Rider ou VS Code.

 ### 1\. Clone o repositório

```
git clone https://github.com/Iclasth/sales-manager.git
cd sales-manager
```

 ### 2\. Configure a conexão com o banco

 O projeto utiliza configuração externa para a connection string.

 Para desenvolvimento local, você pode utilizar **User Secrets**:

```
dotnet user-secrets init --project SalesManager.Web
```

 Depois, configure a connection string correspondente ao ambiente local.

 > Não versionar credenciais ou strings de conexão contendo senhas no repositório.

 ### 3\. Execute as migrations

 A partir da pasta do projeto web:

```
dotnet ef database update
```

 Caso o Entity Framework CLI ainda não esteja instalado:

```
dotnet tool install --global dotnet-ef
```

 ### 4\. Execute a aplicação

```
dotnet run --project SalesManager.Web
```

 Ou abra `SalesManager.sln` na IDE de sua preferência e execute o projeto `SalesManager.Web`.

---

 ## 🌱 Seed de dados

 O projeto possui um serviço de **seeding** utilizado para popular as tabelas com dados iniciais durante o desenvolvimento.

 Isso facilita a execução e demonstração da aplicação sem a necessidade de cadastrar manualmente todos os registros antes de testar os recursos.

---

 ## 📈 Evolução do projeto

 O desenvolvimento foi realizado de forma incremental. Entre os principais marcos estão:

 - Estrutura inicial da solução e aplicação web.
- Criação do domínio de departamentos, vendedores e vendas.
- Implementação do `DbContext`.
- Configuração do banco de dados e primeiras migrations.
- Seed de dados.
- Criação do `SellerService`.
- Implementação do CRUD de vendedores.
- Criação de ViewModels para formulários.
- Relacionamento entre vendedores e departamentos.
- Eager loading para carregamento dos relacionamentos.
- Serviços de atualização, exclusão e busca por ID.
- Exceções específicas e tratamento de integridade referencial.
- Validação de campos.
- Conversão das operações de persistência para `async/await`.
- Pesquisa de vendas por período.
- Pesquisa agrupada por departamento.
- Melhorias de navegação e apresentação dos resultados.

 O histórico atual do GitHub registra **34 commits**, acompanhando essa evolução desde a estrutura inicial até os recursos de pesquisa e organização atuais.  GitHub

---

 ## 🎯 Objetivos de aprendizado

 Mais do que um CRUD, este projeto foi utilizado para praticar conceitos que aparecem em aplicações .NET reais:

 - Desenvolvimento web com ASP.NET Core MVC.
- Modelagem de entidades e relacionamentos.
- Entity Framework Core e Code First.
- Migrations e evolução do banco de dados.
- Injeção de dependência.
- Separação de responsabilidades com Services.
- ViewModels.
- LINQ e consultas com EF Core.
- Eager loading.
- Programação assíncrona.
- Validação de dados.
- Tratamento de exceções.
- Integridade referencial.
- Organização de código.
- Uso seguro de configurações e credenciais.
- Evolução incremental utilizando Git.

---

 ## 📌 Status

 **Completo.**

 O projeto continua sendo utilizado como espaço de aprendizado e experimentação de recursos do ecossistema .NET, com novas funcionalidades e melhorias sendo adicionadas conforme a evolução da aplicação, mas o escopo original do projeto, proposto pelo curso, já foi devidamente alcaçado.

---

 ## 👨‍💻 Autor

 Desenvolvido por **Iclasth**.

 - GitHub: @Iclasth
- Repositório: Iclasth/sales-manager

---
