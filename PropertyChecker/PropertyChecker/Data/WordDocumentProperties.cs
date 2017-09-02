using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
namespace PropertyChecker.Data
{
    public class WordDocumentProperties : IOfficeDocumentProperties
    {
        private Application _application = null;
        private Documents _documents = null;
        private Document _document = null;
        public string FileNameFullPath { get; private set; }
        public WordDocumentProperties(string fileNameFullPath)
        {
            try
            {
                FileNameFullPath = fileNameFullPath;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public OfficePropertyItem GetProperties()
        {
            DocumentProperties returnValue = null;
            try
            {
                _application = new Application();
                _application.Visible = false;
                _documents = _application.Documents;
                _document = _documents.Open(Path.GetFullPath(FileNameFullPath));
                returnValue = _document.BuiltInDocumentProperties;
                _document.Close();
                _documents.Close();
                _documents = null;
                _application = null;
                return returnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SetProperty()
        {
            try
            {
                _application = new Application();
                _application.Visible = false;
                _documents = _application.Documents;
                _document = _documents.Open(Path.GetFullPath(FileNameFullPath));
                DocumentProperties properties = _document.BuiltInDocumentProperties;
                dynamic property = properties["Title"];
                property = "";
                property = properties["Subject"];
                property = "";
                property = properties["Author"];
                property = "";
                property = properties["Keywords"];
                property = "";
                property = properties["Comments"];
                property = "";
                property = properties["Template"];
                property = "";
                property = properties["Last Author"];
                property = "";
                property = properties["Revision Number"];
                property = "";
                property = properties["Application Name"];
                property = "";
                property = properties["Last Print Date"];
                property = "";
                property = properties["Creation Date"];
                property = "";
                property = properties["Last Save Time"];
                property = "";
                property = properties["Total Editing Time"];
                property = "";
                property = properties["Number of Pages"];
                property = "";
                property = properties["Number of Words"];
                property = "";
                property = properties["Number of Characters"];
                property = "";
                property = properties["Security"];
                property = "";
                property = properties["Category"];
                property = "";
                property = properties["Format"];
                property = "";
                property = properties["Manager"];
                property = "";
                property = properties["Company"];
                property = "";
                property = properties["Number of Bytes"];
                property = "";
                property = properties["Number of Lines"];
                property = "";
                property = properties["Number of Paragraphs"];
                property = "";
                property = properties["Number of Slides"];
                property = "";
                property = properties["Number of Notes"];
                property = "";
                property = properties["Number of Hidden Slides"];
                property = "";
                property = properties["Number of Multimedia Clips"];
                property = "";
                property = properties["Hyperlink Base"];
                property = "";
                property = properties["Number of Characters"];
                property = "";
                _document.Save();
                _document.Close();
                _documents = null;
                _application = null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
