using System.Linq;
using UsbEject;

namespace USBCheck
{
    class Usb       //класс USB устройств
    {
        public string DeviceName { get; set; }      //буква устройства
        public string FreeSpace { get; set; }       //свободное место
        public string UsedSpace { get; set; }       //заполненнное место
        public string Capacity { get; set; }        //всего
        public bool IsMtpDevice { get; set; }       //проверка MTP

        public Usb(string name, string freeSize, string usedSize, string totalSize, bool check)
        {
            DeviceName = name;
            FreeSpace = freeSize;
            UsedSpace = usedSize;
            Capacity = totalSize;
            IsMtpDevice = check;
        }
       
        public bool EjectDevice()                    //извлечение устройства с помощью утилиты RemoveDrive
        {
            var tempName = this.DeviceName.Remove(2);
            var ejectedDevice = new VolumeDeviceClass().SingleOrDefault(v => v.LogicalDrive == tempName);
            ejectedDevice.Eject(false);
            ejectedDevice = new VolumeDeviceClass().SingleOrDefault(v => v.LogicalDrive == tempName);
            if (ejectedDevice == null)
                return true;
            else
                return false;
        }
    }
}
