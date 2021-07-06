using SRTPluginBase;
using System;

namespace SRTPluginWebSocket
{
    public class SRTPluginWebSocket : PluginBase, IPluginUI
    {
        public override IPluginInfo Info => new PluginInfo();
        public string RequiredProvider => string.Empty;
        public WebsocketClient ws;
        public PluginConfiguration config;

        public override int Startup(IPluginHostDelegates hostDelegates)
        {
            config = LoadConfiguration<PluginConfiguration>();
            if (config.Token == "") 
            { 
                SaveConfiguration(config);
                Console.WriteLine("Please Close SRT and Enter username in /plugins/SRTPluginWebSocket/SRTPluginWebSocket.cfg and Restart");
                return 1;
            }
            ws = new WebsocketClient("wss://relay.aricodes.net/ws", config);
            return 0;
        }

        public override int Shutdown()
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
            if (config.Token != "")
            {
                ws.SendData(gameMemory);
                return 0;
            }
            return 1;  
        }

    }
}