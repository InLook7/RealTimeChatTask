using RealTimeChatTask.PL.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSignalR();

var app = builder.Build();

app.MapControllers();
app.MapHub<ChatHub>("chat");

app.Run();
