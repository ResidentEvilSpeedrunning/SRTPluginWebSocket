using System;
using System.Net.WebSockets;
using System.Threading;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using SRTPluginBase;
using System.Reflection;
using System.IO;

namespace SRTPluginWebSocket
{
    public class WebsocketClient : IDisposable
    {
        private ClientWebSocket client;
        private string Url;
        private bool IsConnected;
        private bool IsIdentified;
        private string previousMessage;
        public PluginConfiguration Config;
        public WebsocketClient(string url, PluginConfiguration config)
        {
            client = new ClientWebSocket();
            Url = url;
            Config = config;
        }

        public async Task Connect()
        {
            await client.ConnectAsync(new Uri(Url), CancellationToken.None);
            IsConnected = true;
            await SetIdentity();
        }

        public async Task SetIdentity()
        {
            if (!IsConnected) { await Connect(); }
            var username = Config.Token;
            var user = string.Format("ident:{0}", username);
            await client.SendAsync(Encoding.UTF8.GetBytes(user), WebSocketMessageType.Text, true, CancellationToken.None);
            IsIdentified = true;
        }

        public async Task SendData(object gameMemory)
        {
            if (!IsConnected) { await Connect(); }
            if (!IsIdentified) { await SetIdentity(); }
            var json = JsonSerializer.Serialize(gameMemory);
            if (previousMessage == json) { return; }
            await client.SendAsync(Encoding.UTF8.GetBytes(json), WebSocketMessageType.Text, true, CancellationToken.None);
            previousMessage = json;
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