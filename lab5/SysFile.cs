using System;


namespace lab5
{
    class SysFile
    {
        public string Path { get; }
        public string Description { get; }

        public SysFile(string Path, String Description)
        {
            this.Path = Path;
            this.Description = Description;
        }
    }
}
