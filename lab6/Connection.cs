using System;
using SimpleWifi;


namespace lab6
{
    class Connection
    {
        internal AccessPoint accessPoint;
        public string Mac { get; set; }

        public Connection()
        {

        }

        public Connection(AccessPoint accessPoint, string Mac)
        {
            this.accessPoint = accessPoint;
            this.Mac = Mac;
        }

        public string SSID => (accessPoint.Name.Equals("") ? null : accessPoint.Name);
        public int SignalStrength => (int)accessPoint.SignalStrength;
        public bool IsSecured => accessPoint.IsSecure;
        public bool HasProfile => accessPoint.HasProfile;
        public bool IsConnected => accessPoint.IsConnected;

        public string AuthType
        {
            get
            {
                var cipherAlgorithm = accessPoint.ToString().Split()[10];
                var authAlgorithm = accessPoint.ToString().Split()[6];
                switch (cipherAlgorithm)
                {
                    case "None":
                        return "Open";
                    case "Wep":
                        return "Wep";
                    case "CCMP":
                    case "TKIP":
                        return (authAlgorithm.Equals("RSNA") ? "WPA2-Enterprise-PEAP-MSCHAPv2" : "WPA2-PSK");
                    default:
                        return "Unknown";
                }
            }
        }

        public void ConnectAsync(AuthRequest authRequest, Action<bool> onConnectComplete)
        {
            accessPoint.ConnectAsync(authRequest, true, onConnectComplete);
        }
    }
}
