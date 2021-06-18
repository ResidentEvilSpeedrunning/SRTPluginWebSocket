using System;
using System.Net.WebSockets;
using System.Threading;
using System.Text.Json;
using System.Text;

namespace SRTPluginUIJSON
{
    public class WebsocketClient : IDisposable
    {
        private ClientWebSocket client;
        public WebsocketClient(string url, string port)
        {
            client = new ClientWebSocket();
            client.ConnectAsync(new Uri(string.Format("{0}:{1}", url, port)), CancellationToken.None);
            //var user = "ident:VideoGameRoulette";
            //client.SendAsync(Encoding.Unicode.GetBytes(user), WebSocketMessageType.Text, false, CancellationToken.None);
        }

        public void SendData(object gameMemory)
        {
            var json = JsonSerializer.Serialize(gameMemory);
            client.SendAsync(Encoding.Unicode.GetBytes(json), WebSocketMessageType.Text, false, CancellationToken.None);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    client?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~JSONServer()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
