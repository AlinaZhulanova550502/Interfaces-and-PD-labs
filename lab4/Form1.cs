using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace USBCheck
{
    public partial class Form1 : Form
    {
        private const int WM_DEVICECHANGE = 0X219;      // константа для перезаписи системного метода
                                                        // private static readonly Manager _manager = new Manager();
        private readonly Manager _manager = new Manager();
        private List<Usb> DeviceList;
        private readonly DataTable Table = new DataTable();       //таблица выбора

        protected override void WndProc(ref Message m)            //следить за системными сообщениями
        {
            base.WndProc(ref m);                                  //перенаправление соообщений в эту программу
            if (m.Msg == WM_DEVICECHANGE)                         //если конфигурация устройств изменилась
            {
                ReloadForm();                                     //перезагрузка формы
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadForm(object sender, EventArgs e)       //при первой загрузке формы
        {
            DeviceList = new List<Usb>();
            Table.Columns.Add("Name", typeof(string));          //шаблон для программы
            ReloadForm();                                       //получить все устройства
            USBList.DataSource = Table;
            EjectButton.Enabled = false;
            timer.Enabled = true;
        }
       
        private void ReloadForm()                               //перезагрузка формы
        {
            int currentPosition = 0;
            if (USBList.CurrentRow != null)                     //проверка выбранной строки
            {
                currentPosition = USBList.CurrentRow.Index;
            }
            Table.Clear();                                      //удаление прошлых данных
            DeviceList = _manager.DeviseListCreate();
            foreach(Usb device in DeviceList)
            {
                Table.Rows.Add(device.DeviceName);
            }
            if (USBList.RowCount - 1 > currentPosition)         //если нет индекса границ
            {
                USBList.Rows[currentPosition].Selected = true;  //выбираем эту строку
            }
            label1.Text = "";
        }

        private void TickTimer(object sender, EventArgs e)     //таймер для обновления каждые 5 секунд
        {
            ReloadForm();
        }

        private void ChangeSelect(object sender, EventArgs e)       //событие для выбора нескольких строк
        {
            if (USBList.CurrentRow != null)         //если строка существует
            {
                if (USBList.CurrentRow.Index >= 0 && USBList.CurrentRow.Index < DeviceList.Count)   //если нет индекса границ
                {
                    EjectButton.Enabled = !DeviceList[USBList.CurrentRow.Index].IsMtpDevice;    //можем извлечь только usb, не mtp
                    if (!DeviceList[USBList.CurrentRow.Index].IsMtpDevice)      //то же самое с выводом
                    {
                        spaceTextBox.Text = "Free Space: " + DeviceList[USBList.CurrentRow.Index].FreeSpace + "\r\n" +
                                        "Used space: " + DeviceList[USBList.CurrentRow.Index].UsedSpace + "\r\n" +
                                        "Capacity: " + DeviceList[USBList.CurrentRow.Index].Capacity;
                    }
                }
                else                    //в других ситуациях просто заблокировать всё
                {
                    EjectButton.Enabled = false;
                    spaceTextBox.Text = "";
                }
            }
        }

        private void HitEjectButton(object sender, EventArgs e)     //событие для кнопки извлечения
        {
            if (USBList.CurrentRow != null)                      //если выбрали устройство для извлечения
            {
                bool isEjected = DeviceList[USBList.CurrentRow.Index].EjectDevice();
                if (isEjected == false)
                {
                    label1.Text = "Device is busy.";
                }
                else
                {
                    spaceTextBox.Text = "";
                }
            }
        }
    }
}
