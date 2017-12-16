using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab6
{
    class FormManager
    {
        internal ConnectionsManager connectionsManager;
        public int NumberOfConnections { get => connectionsManager.Connections.Count; }

        public FormManager() => connectionsManager = new ConnectionsManager();

        public ListViewItem[] ConnectionsNames
        {
            get
            {
                var connectionsList = new ListViewItem[NumberOfConnections];
                for (int i = 0; i < NumberOfConnections; i++)
                {
                    connectionsList[i] = new ListViewItem(connectionsManager.Connections[i].SSID ?? "Hidden connection");
                }
                return connectionsList;
            }
        }

        public ListViewItem[] ConnectionInfo(int index)
        {
            var connection = connectionsManager.Connections[index];
            return new ListViewItem[] {
                    new ListViewItem($"Name: {connection.SSID ?? "Hidden connection"}"),
                    new ListViewItem($"Auth Type: {connection.AuthType}"),
                    new ListViewItem($"Mac: {connection.Mac}"),
                    new ListViewItem($"Signal Strength: {connection.SignalStrength}"),
                    new ListViewItem($"Is Secured: {connection.IsSecured}"),
                    new ListViewItem($"Has profile: {connection.HasProfile}"),
                    new ListViewItem($"Is Connected: {connection.IsConnected}")
                };
        }

        public bool BuildConnectionsList() => connectionsManager.FindAccessPoints();

        public void Disconnect() => connectionsManager.Disconnect();

        public void Connect(int index, string password, Action<bool> onConnectComplite)
        {
            var connection = connectionsManager.Connections[index];
            connectionsManager.Connect(connection, password, onConnectComplite);
        }

    }
}