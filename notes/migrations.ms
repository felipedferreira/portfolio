dotnet ef migrations add InitialCreate --project src/Portfolio.PostgresSQL/Portfolio.PostgresSQL.csproj --startup-project src/Portfolio.WebServer/Portfolio.WebServer.csproj


dotnet ef database update --project src/Portfolio.PostgresSQL/Portfolio.PostgresSQL.csproj --startup-project src/Portfolio.WebServer/Portfolio.WebServer.csproj