var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login",(LoginDTO loginDto) => {
    if(loginDto.Email == "adm@teste.com" && loginDto.Senha == "123456")
        return Results.Ok("Usuário logado com sucesso!");
    else
        return Results.Unauthorized();
});

app.Run();

public record LoginDTO(string Email, string Senha);