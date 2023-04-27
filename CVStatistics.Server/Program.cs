using CVStatistics.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddServices();
var app = builder.Build();
app.RegisterPipelineComponents();
app.Run();
