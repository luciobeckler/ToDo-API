
# ToDo-API

API desenvolvida em ASP.NET Core utilizando .NET 8 para gerenciamento de tarefas (to-do list).

## Modelo de dados
![image](https://github.com/user-attachments/assets/c764af3f-ed84-4385-8640-cdbc22a1eb02)

## Pacotes instalados

- Microsoft Entityframeworkcore v9.0.4
- Microsoft Entityframeworkcore Tools v9.0.4
- Npgsql Entityframeworkcore PostgreSQL v9.0.4


## Como rodar o projeto

1. Clone o repositório

```bash
git clone https://github.com/luciobeckler/ToDo-API.git
cd ToDo-API/ToDo-API    
```

2. No arquivo "appsettings.json" adicione a sua senha do PostgreSQL na string de conexão e verifique a porta 5432, porta padrão, esta configurada no PostgreSQL.
```bash
"ConnectionStrings": {
  "DevConnection": "Host=localhost;Port=5432;Database=tododb;Username=postgres;Password=SuaSenhaAqui"
},
```

3. Rode as migrações 
```bash
dotnet ef database update
```

4. Execute a aplicação
```bash
dotnet ef database update
```

5. Acesse o swagger que será aberto no navegador
