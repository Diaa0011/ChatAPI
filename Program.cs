using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;
using ChatApp;
using ChatApp.Extensions;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAppServices(builder.Configuration);

var app = builder.Build();
app.UseAppPipeline();

Console.WriteLine("Server started. Press Ctrl+C to stop.");
await app.RunAsync();