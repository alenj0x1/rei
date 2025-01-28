using Rei.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServiceExtension(builder.Configuration);

var app = builder.Build();
app.Run();