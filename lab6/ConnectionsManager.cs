using System;
using System.Collections.Generic;
using SimpleWifi;
using System.Diagnostics;

namespace lab6
{
    class ConnectionsManager
    {
        public List<Connection> Connections { get; private set; }
        internal string[] bssids;

        public ConnectionsManager() => Connections = new List<Connection>();

        public bool FindAccessPoints()
        {
            FindBssids();
            try
            {
                Wifi wifi = new Wifi();
                List<Connection> newConnections = new List<Connection>();
                foreach (var accessPoint in wifi.GetAccessPoints())
                {
                    newConnections.Add(new Connection {
                        accessPoint = accessPoint,
                        Mac = FindMac(accessPoint)
                    });
                }
                Connections = newConnections;
                return true;
            }
            catch (System.ComponentModel.Win32Exception) // Wifi is turned off
            {
                Connections.Clear();
                return false;
            }
        }

        private void FindBssids()
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    FileName = "cmd",
                    Arguments = @"/C ""netsh wlan show networks mode=bssid | findstr SSID""",
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                }
            };
            process.Start();
            bssids = process.StandardOutput.ReadToEnd().Replace(" ", "").Replace("\r", "").Split('\n');
            process.WaitForExit();
        }

        private string FindMac(AccessPoint accessPoint)
        {
            bool foundMac = false;
            foreach (var bssid in bssids)
            {
                if (foundMac)
                {
                    return bssid.Remove(0, bssid.IndexOf(":") + 1);
                }

                // Check if string contains required SSID 
                // If SSID Found, BSSID next step
                foundMac = (bssid.Split(':')[0].Contains("SSID") && accessPoint.Name.Equals(bssid.Split(':')[1]));
            }
            return null;
        }

        public void Connect(Connection connection, string password, Action<bool> onConnectComplite)
        {
            var authRequest = new AuthRequest(connection.accessPoint)
            {
                Password = password
            };
            connection.ConnectAsync(authRequest, onConnectComplite);
        }

        public void Disconnect() => new Wifi().Disconnect();
    }
}
