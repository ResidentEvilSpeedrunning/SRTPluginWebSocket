using SRTPluginBase;
using System;

namespace SRTPluginUIJSON
{
    public class SRTPluginWebSocket : IPluginUI
    {
        public IPluginInfo Info => new PluginInfo();
        public string RequiredProvider => string.Empty;
        public WebsocketClient ws;

        public int Startup(IPluginHostDelegates hostDelegates)
        {
            ws = new WebsocketClient("ws://relay.aricodes.net/ws", "443");
            return 0;
        }

        public int Shutdown()
        {
            try
            {
                ws?.Dispose();
                ws = null;
            }
            catch { return 1; }
            
            return 0;
        }

        public int ReceiveData(object gameMemory)
        {
            ws.SendData(gameMemory);
            return 0;
        }
    }
}
