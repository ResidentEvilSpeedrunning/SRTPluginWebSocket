using SRTPluginBase;
using System;

namespace SRTPluginUIJSON
{
    internal class PluginInfo : IPluginInfo
    {
        public string Name => "Websocket Relay";

        public string Description => "A Websocket Relay Plugin for connecting to SRT Host gameMemory data.";

        public string Author => "VideoGameRoulette & Willow";

        public Uri MoreInfoURL => new Uri("https://github.com/ResidentEvilSpeedrunning/SRTPluginWebSocket");

        public int VersionMajor => assemblyFileVersion.ProductMajorPart;

        public int VersionMinor => assemblyFileVersion.ProductMinorPart;

        public int VersionBuild => assemblyFileVersion.ProductBuildPart;

        public int VersionRevision => assemblyFileVersion.ProductPrivatePart;

        private System.Diagnostics.FileVersionInfo assemblyFileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
    }
}
