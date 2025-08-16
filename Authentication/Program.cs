using Authentication;
using Authentication.Interfaces;
using Authentication.Request;
using Authentication.Validator;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddSingleton<ITokenValidator, TokenValidator>();
builder.Services.AddSingleton<ICryptoService, CryptoService>();
builder.Services.AddSingleton<HttpRequestHandler>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
