using System;
using System.Collections.Generic;
using System.IO;
namespace PropertyChecker.Data
{
    public class DirectoryAccessorService
    {
        public Dictionary<int, string> FileLists { get; private set; }

        public DirectoryAccessorService(string folderPath)
        {
            try
            {
                IEnumerable<string> files = Directory.EnumerateFiles(folderPath, "*", SearchOption.AllDirectories);
                int i = 0;
                FileLists = new Dictionary<int, string>();
                foreach (var file in files)
                {
                    if (File.Exists(file))
                    {
                        FileLists.Add(i, file.ToString());
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
