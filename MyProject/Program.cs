using MyProject;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

app.Map("/favicon.ico", (a) => a.Run(async c => await Task.CompletedTask));

app.UseErrorHandlingMiddleware();
app.UseMyMiddleware();
app.UseMyLogMiddleware();

app.Use(async (context, next) => {
    await context.Response.WriteAsync("middleware start...\n");
    await next.Invoke();
    await context.Response.WriteAsync("middleware end!!!\n");
});

// app.Map("/test1", (a) => 
//     a.Run(async context => await context.Response.WriteAsync("our test1-map terminal middleware!\n")));
// app.Map("/test2", (a) => 
//     a.Run(async context => await context.Response.WriteAsync("our test2-map terminal middleware!\n")));
// app.Run(async context => await context.Response.WriteAsync("our no-map terminal and middleware!\n"));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


