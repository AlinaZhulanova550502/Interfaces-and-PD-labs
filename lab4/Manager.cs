using System.Collections.Generic;
using System.Linq;
using System.IO;
using MediaDevices;

namespace USBCheck
{
    class Manager   //класс для выполнения действий по перезагрузке
    {
        public List<Usb> DeviseListCreate()  //метод добавления результатов в список устройств
        {
            List<Usb> usbDevices = new List<Usb>();
            //Получение USB и MTP-накопителей
            List<DriveInfo> diskDrives = DriveInfo.GetDrives().Where(d => d.IsReady && d.DriveType == DriveType.Removable).ToList();
            List<MediaDevice> mtpDrives = MediaDevice.GetDevices().ToList();
            foreach (MediaDevice device in mtpDrives)       //работа с MTP
            {
                device.Connect();                               //подключение к устройству MTP
                if (device.DeviceType != DeviceType.Generic)   
                {
                    usbDevices.Add(new Usb(device.FriendlyName, null, null, null, true));   //добавить MTP-устройство в список
                }
            }
            foreach (DriveInfo drive in diskDrives)     //floppy + usb
            {
                usbDevices.Add(new Usb(drive.Name, Convert(drive.TotalFreeSpace),   // добавить USB в список и рассчитать размеры
                    Convert(drive.TotalSize - drive.TotalFreeSpace),
                    Convert(drive.TotalSize), false));
            }
            return usbDevices;
        }

        private string Convert(long value)                  // перевести из байт в мегабайты
        {
            double megaBytes = (value / 1024) / 1024;
            return megaBytes.ToString() + " mb";
        }
    }
}
