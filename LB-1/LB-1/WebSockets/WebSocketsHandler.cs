using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace LB_1.WebSockets
{
    public class WebSocketsHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(WsRequest);
            }
        }

        private async Task WsRequest(AspNetWebSocketContext webSocketContext)
        {
            var webSocket = webSocketContext.WebSocket;

            var message = await ReadMessage(webSocket);
            await SendMessage(webSocket, message);

            while (webSocket.State == WebSocketState.Open)
            {
                Thread.Sleep(2000);
                await SendMessage(webSocket, DateTime.Now.ToLongTimeString());
            }
        }

        private async Task<string> ReadMessage(WebSocket webSocket)
        {
            var buffer = new ArraySegment<byte>(new byte[512]);
            var message = await webSocket.ReceiveAsync(buffer, CancellationToken.None);

            return Encoding.UTF8.GetString(buffer.Array, 0, message.Count);
        }

        private async Task SendMessage(WebSocket webSocket, string message)
        {
            var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));

            await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
