using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClosedXML.Excel;
namespace PropertyChecker.Data
{
    public class ExcelDocumentProperties: IOfficeDocumentProperties
    {
        public string FileNameFullPath { get; private set; }
        public ExcelDocumentProperties(string fileNameFullPath)
        {
            try
            {
                FileNameFullPath = fileNameFullPath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public OfficePropertyItem GetProperties()
        {
            OfficePropertyItem returnValue = null;
            try
            {
                returnValue = new OfficePropertyItem(FileNameFullPath);
                var workbook = new XLWorkbook(FileNameFullPath);
                var properties = workbook.Properties;
                returnValue.Author = properties.Author;
                returnValue.Category = properties.Category;

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
                using (FileStream file = new FileStream(FileNameFullPath, FileMode.Open, FileAccess.Write))
                {
                    POIFSFileSystem fs = new POIFSFileSystem(file);
                    var dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                    dsi.RemoveByteCount();
                    dsi.RemoveCategory();
                    dsi.RemoveCompany();
                    dsi.RemoveCustomProperties();
                    dsi.RemoveDocparts();
                    dsi.RemoveHeadingPair();
                    dsi.RemoveHiddenCount();
                    dsi.RemoveLineCount();
                    dsi.RemoveLinksDirty();
                    dsi.RemoveManager();
                    dsi.RemoveMMClipCount();
                    dsi.RemoveNoteCount();
                    dsi.RemoveParCount();
                    dsi.RemovePresentationFormat();
                    dsi.RemoveScale();
                    dsi.RemoveSlideCount();
                    var si = PropertySetFactory.CreateSummaryInformation();
                    si.RemoveApplicationName();
                    si.RemoveAuthor();
                    si.RemoveCharCount();
                    si.RemoveComments();
                    si.RemoveCreateDateTime();
                    si.RemoveEditTime();
                    si.RemoveKeywords();
                    si.RemoveLastAuthor();
                    si.RemoveLastPrinted();
                    si.RemoveLastSaveDateTime();
                    si.RemovePageCount();
                    si.RemoveRevNumber();
                    si.RemoveSecurity();
                    si.RemoveSubject();
                    si.RemoveTemplate();
                    si.RemoveThumbnail();
                    si.RemoveTitle();
                    si.RemoveWordCount();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
