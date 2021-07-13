using System;

namespace SRTPluginWebSocket
{
    public class PluginConfiguration
    {
        public string Token { get; set; }
        public string Key { get; set; }

        public bool LowBandwithMode = true;

        public PluginConfiguration()
        {
            Token = "";
            Key = "";
        }
    }
}
