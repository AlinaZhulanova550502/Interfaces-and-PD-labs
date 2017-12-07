using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IIPU_lab3
{
    class Work
    {
        public int PreviousTime { get; set; }
        public int CurrentTime { get; set; }
        public string PowerStatus { get; set; } // подкл/откл
        public string Percent { get; set; }
        public string Remaining { get; set; }

        Regex VideoIdleExpression = new Regex("VIDEOIDLE.*\\n.*\\n.*\\n.*\\n.*\\n.*\\n.*"); // 6 строк отключать экран через

        public Work()
        {
            PreviousTime = GetTime();
            CurrentTime = PreviousTime;
            UpdateInfo();
        }

        public ProcessStartInfo PrepareStartInfo(string fileName, string arguments, string value)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = fileName;
            startInfo.Arguments = arguments + value;
            startInfo.UseShellExecute = false;                  // нужно ли использовать оболочку ос для запуска процесса.
            startInfo.RedirectStandardOutput = true;            // записываются ли текстовые выходные данные в поток Process.StandardOutput
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden; // состояние окна призапуске процесса
            return startInfo;

        }

        public int GetTime()                            //отключать экран через
        {
            Process timeProcess = Process.Start(PrepareStartInfo("cmd.exe", "/c powercfg /q", String.Empty)); // powercfg -q отображает содержимое указанной схемы управления питанием
            string videoIdle = VideoIdleExpression.Match(timeProcess.StandardOutput.ReadToEnd()).Value; // cчитывает все символы, начиная с текущей позиции до конца потока + рег.
            string currentTime = videoIdle.Substring(videoIdle.Length - 11).TrimEnd(); // последнее 16-ричное без пробела
            timeProcess.WaitForExit();
            timeProcess.Close();
            return Convert.ToInt32(currentTime, 16) / 60;           // из 16-ричной
        }

        public void UpdateInfo(bool timeChanged = false)
        {
            if (PowerStatus != SystemInformation.PowerStatus.PowerLineStatus.ToString()) // текущее состояние системного питания
            {
                SetNewTime(PreviousTime);
                timeChanged = true;
            }
            if (timeChanged) CurrentTime = GetTime();
            PowerStatus = SystemInformation.PowerStatus.PowerLineStatus.ToString();
            Percent = SystemInformation.PowerStatus.BatteryLifePercent * 100 + "%";
            SetPowerLifeRemaining();
        }

        public void SetPowerLifeRemaining()
        {
            if (PowerStatus == "Offline")
            {
                int batteryLife = SystemInformation.PowerStatus.BatteryLifeRemaining; // количество секунд оставшегося времени
                if (batteryLife != -1)  // известно
                {
                    Remaining = new TimeSpan(0, 0, batteryLife).ToString("c"); //интерв времени чмс
                }
                else Remaining = "Is processing";
            }
            else
            {
                Remaining = "Is charging";
            }
        }

        public void SetNewTime(int time)    //переназначить время затемнения
        {
            Process setTimeProcess = Process.Start(PrepareStartInfo("cmd.exe", "/c powercfg /x -monitor-timeout-dc ", time.ToString())); // изменяет значение параметра, минуты
            setTimeProcess.WaitForExit();
            setTimeProcess.Close();
        }
    }
}
