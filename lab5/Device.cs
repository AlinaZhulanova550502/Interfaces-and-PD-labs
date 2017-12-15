using System;
using System.Collections.Generic;

namespace lab5
{
    class Device
    {
        public string Name { get; }
        public String DeviceID { get; }
        public string GUID { get; }
        public string[] HardwareID { get; }
        public string Manufacturer { get; }
        public List<SysFile> SysFiles { get; }
        public bool Status { get; set; }

        public Device(string Name, string DeviceID, string GUID, string[] HardwareID, string Manufacturer,  
             List<SysFile> SysFiles, bool Status)
        {
            this.Name = Name;
            this.DeviceID = DeviceID;
            this.GUID = GUID;
            this.HardwareID = HardwareID;
            this.Manufacturer = Manufacturer;
            this.SysFiles = SysFiles;
            this.Status = Status;
        }

    }
}
