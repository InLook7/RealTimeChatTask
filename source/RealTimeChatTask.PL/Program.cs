using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using RealTimeChatTask.PL.Hubs;
using RealTimeChatTask.PL.Mappings;
using RealTimeChatTask.BLL.Interfaces;
using RealTimeChatTask.BLL.Services;
using RealTimeChatTask.BLL.Mappings;
using RealTimeChatTask.DAL.Interfaces;
using RealTimeChatTask.DAL.Infrastructure;
using RealTimeChatTask.BLL.DTOs;
using RealTimeChatTask.BLL.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSignalR().AddAzureSignalR(builder.Configuration.GetValue<string>("ConnectionStringAzureSignalR"));

builder.Services.AddTransient<IChatRoomService, ChatRoomService>();
builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddTransient<ISentimentService, SentimentService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITextAnalyticsService, TextAnalyticsService>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<AppDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStringDB"));
});

builder.Services.AddScoped<IValidator<MessageDTO>, MessageValidator>();

builder.Services.AddAutoMapper(typeof(BusinessLayerMapper), typeof(PresentationLayerMapper));

builder.Services.AddSingleton(new TextAnalyticsClient(
    new Uri(builder.Configuration.GetValue<string>("TextAnalyticsEndpoint")), 
    new AzureKeyCredential(builder.Configuration.GetValue<string>("TextAnalyticsApiKey"))
));

var app = builder.Build();

app.MapControllers();
app.MapHub<ChatHub>("chat");

app.Run();
