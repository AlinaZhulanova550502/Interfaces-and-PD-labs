using System;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form1 : Form
    {
        private FormManager formManager;
        private Timer timer;
        private int selectedIndex;

        public Form1()
        {
            InitializeComponent();
            formManager = new FormManager();
            selectedIndex = -1;
            Load += (s, e) =>
            {
                PaintUI();
                timer = new Timer
                {
                    Interval = 5 * 1000 // 5secs
                };
                timer.Tick += new EventHandler(Timer_Tick);
                timer.Start();
            };
        }

        private void Timer_Tick(object sender, EventArgs e) => PaintUI();

        private void PaintUI()
        {
            timer?.Stop();

            if (!formManager.BuildConnectionsList())
            {
                logLabel.Text = "Wifi is turned off.";
            }
            else if(logLabel.Text.Equals("Wifi is turned off."))
            {
                logLabel.Text = "";
            }

            ShowConnections();
            if (IsValidSelection)
            {
                connectionsList.Items[selectedIndex].Selected = true;
                ShowSelectedInfo();
            }
           
            timer?.Start();
        }

        private void ShowConnections()
        {
            connectionsList.Items.Clear();
            connectionsList.Items.AddRange(formManager.ConnectionsNames);
        }

        private void ShowSelectedInfo()
        {
            infoList.Items.Clear();
            infoList.Items.AddRange(formManager.ConnectionInfo(selectedIndex));
        }

        private bool IsValidSelection
        {
            get
            {
                if ((selectedIndex != -1) && (selectedIndex < formManager.NumberOfConnections))
                {
                    return true;
                }
                else
                {
                    selectedIndex = -1;
                    return false;
                }
            }
        }

        private void CheckConnectionSuccess(bool success) => logLabel.Text = $"Connection complite, success: {success}";

        private void DisconnectButton_Click(object sender, EventArgs e)  
        {
            formManager.Disconnect();
            logLabel.Text = "Disconnected!";
        }

        private void ConnectButton_Click(object sender, EventArgs e)  
        {
            if (IsValidSelection)
            {
                var password = passwordBox.Text;
                formManager.Connect(selectedIndex, password, CheckConnectionSuccess);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e) 
        {
            PaintUI();
            logLabel.Text = "";
        }

        private void ConnectionsList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var selected = connectionsList.FocusedItem;
                if ((selected != null) && (selected.Bounds.Contains(e.Location) == true))
                {
                    selectedIndex = selected.Index;
                    ShowSelectedInfo();
                    logLabel.Text = "";
                }
            }
        }

    }
}
