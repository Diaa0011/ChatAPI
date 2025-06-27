using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;
using ChatApp;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<ChatService>();
var app = builder.Build();
app.UseWebSockets();
Console.WriteLine("using of WeSocket succeeded");

app.MapGet("/", async (HttpContext context, ChatService chatService) =>
{   
    Console.WriteLine("begin chat service");
    if (context.WebSockets.IsWebSocketRequest)
    {
        var webSocket = await context.WebSockets.AcceptWebSocketAsync();
        Console.WriteLine("Worked Successfully!");
        await chatService.HandleWebSocketConnection(webSocket);

    }
    else
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Expected a WebSocket request");
    }
});

Console.WriteLine("Server started. Press Ctrl+C to stop.");
await app.RunAsync();