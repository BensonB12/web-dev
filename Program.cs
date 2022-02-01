var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

int total = 0;

IResult DoSomething(int id = 1000)
{
    total += id;
    //return $"Hello World! This is your id: {id} This is your total: {total}";
    return Results.Redirect($"/index.html?id={id}&total={total}");
}

app.UseStaticFiles();
app.MapGet("/app", DoSomething);
app.MapGet("/getage", (int id) => 
{
    return new Person(id: id, name: "text", age: 21);
});
app.MapPost("/app", (HttpRequest request) =>
{
    return DoSomething(int.Parse(request.Form["id"]));
});

app.Run();

record Person(int id, string name, int age);