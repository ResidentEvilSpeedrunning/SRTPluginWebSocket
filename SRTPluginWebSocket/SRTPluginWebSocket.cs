using SRTPluginBase;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SRTPluginUIJSON
{
    public class SRTPluginWebSocket
    {
        public IPluginInfo Info => new PluginInfo();
        public string RequiredProvider => string.Empty;
        public static object gameMemory = null;
        public static MethodInfo serializer = null;
        public WebsocketClient ws;
        public void Startup()
        {
            ws = new WebsocketClient("https://relay.aricodes.net/ws", "443");
        }

        public void Shutdown()
        {
            ws.Dispose();
        }

        public void ReceiveData(object gameMemory)
        {
            ws.SendData(gameMemory);
        }
    }
}
