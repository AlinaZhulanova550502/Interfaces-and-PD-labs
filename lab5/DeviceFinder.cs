using System.Collections.Generic;
using System.Management;


namespace lab5
{
    class DeviceFinder
    {
        public List<Device> devices { get; }
        public string SystemName { get; private set; }

        public DeviceFinder()
        {
            devices = new List<Device>();
            SystemName = null;
        }

        public void FindDevices()
        {
            ManagementObjectSearcher deviceList = new ManagementObjectSearcher("Select * from Win32_PnPEntity");

            if (deviceList == null)
            {
                return;
            }

            foreach (ManagementObject device in deviceList.Get())
            {
                //try
                //{
                    List<SysFile> sysFiles = new List<SysFile>();

                    foreach (var sysFile in device.GetRelated("Win32_SystemDriver"))
                    {
                       sysFiles.Add(new SysFile(sysFile["PathName"]?.ToString(), sysFile["Description"]?.ToString()));
                    }

                    devices.Add(new Device(
                        device["Name"]?.ToString(),
                        device["DeviceID"]?.ToString(),
                        device["ClassGuid"]?.ToString(),
                        device["HardwareID"] != null ? (string[])device["HardwareID"] : null,
                        device["Manufacturer"]?.ToString(),
                        sysFiles,
                        device.GetPropertyValue("Status").ToString().Equals("OK")));

                if (SystemName == null)
                {
                    SystemName = device["SystemName"].ToString();
                }
                //}
                //catch (NullReferenceException) { }
            }

        }

        public bool TurnOff(Device device)
        {
            if (!check(device.DeviceID.ToString()))
            {
                ChangeStatus(device);
                return false;
            }

            foreach (ManagementObject dev in new ManagementObjectSearcher("Select * from Win32_PnPEntity").Get())
            {
                if (dev["DeviceID"].ToString().Equals(device.DeviceID))
                {
                    dev.InvokeMethod("Disable", new object[] { true });

                    if(!check(dev["DeviceID"].ToString()))
                    {
                        device.Status = false;
                        return true;
                    }

                    break;
                }
            }

            return false;
        }

        public bool TurnOn(Device device)
        {
            if (check(device.DeviceID.ToString()))
            {
                ChangeStatus(device);
                return false;
            }

            foreach (ManagementObject dev in new ManagementObjectSearcher("Select * from Win32_PnPEntity").Get())
            {
                if (dev["DeviceID"].ToString().Equals(device.DeviceID))
                {
                    dev.InvokeMethod("Enable", new object[] { true });
                    
                    if (check(dev["DeviceID"].ToString()))
                    {
                        device.Status = true;
                        return true;
                    }

                    break;
                }
            }

            return false;
        }

        public void ChangeStatus(Device device)
        {
            device.Status = !device.Status;
        }

        public bool check(string deviceID)
        {
            foreach (ManagementObject dev in new ManagementObjectSearcher("Select * from Win32_PnPEntity").Get())
            {
                if (dev["DeviceID"].ToString().Equals(deviceID))
                {
                    return dev["Status"].ToString().Equals("OK");
                }
            }
            return false;
        }

    }
}
