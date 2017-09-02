using PropertyChecker.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PropertyChecker.Models
{
    public class MainWindowModel
    {
        private DirectoryAccessorService _das = null;
        private Dictionary<int, string> _fileLists = null;
        private string _folderName = string.Empty;
        public MainWindowModel(string FolderName)
        {
            try
            {
                if(string.IsNullOrEmpty(FolderName) || string.IsNullOrWhiteSpace(FolderName))
                {
                    throw new ArgumentException(Properties.Resources.NullEmptySpace.ToString());
                }
                _folderName = FolderName;
                _das = new DirectoryAccessorService(_folderName);
                _fileLists = _das.FileLists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ObservableCollection<PropertyItem> GetProperties()
        {
            try
            {
                if (string.IsNullOrEmpty(_folderName) || string.IsNullOrWhiteSpace(_folderName))
                {
                    throw new ArgumentException(Properties.Resources.NullEmptySpace.ToString());
                }
                var fpas = new FilePropertyAccessorService(_folderName, _fileLists);
                return fpas.FilePropertyLists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SetProperty(ObservableCollection<PropertyItem> target)
        {
            try
            {
                var fpas = new FilePropertyAccessorService(_folderName, _fileLists);
                foreach(var item in target)
                {
                    item.IsChangePropertyTarget = true;
                }
                fpas.SetProperty(target);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
