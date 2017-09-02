using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace PropertyChecker.Data
{
    public class FilePropertyAccessorService
    {
        public Dictionary<int, string> FileLists { get; private set; }
        public ObservableCollection<PropertyItem> FilePropertyLists { get; private set; }
        private string TargetDirectory { get; set; }
        public FilePropertyAccessorService(string targetDirectory, Dictionary<int, string> fileLists)
        {
            try
            {
                TargetDirectory = targetDirectory;
                if (fileLists.Count == 0)
                {
                    throw new ArgumentException(Properties.Resources.EmptyFileLists.ToString());
                }
                FilePropertyLists = GetFilesProperty(fileLists);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private ObservableCollection<PropertyItem> GetFilesProperty(Dictionary<int, string> fileLists)
        {
            ObservableCollection<PropertyItem> returnValue;
            try
            {
                returnValue = new ObservableCollection<PropertyItem>();
                foreach (var filePath in fileLists)
                {
                    if (File.Exists(filePath.Value))
                    {
                        returnValue.Add(new PropertyItem(TargetDirectory, filePath.Value));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;
        }
        public void SetProperty(ObservableCollection<PropertyItem> target)
        {
            try
            {
                foreach(var targetItem in target)
                {
                    targetItem.SetProperty();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
