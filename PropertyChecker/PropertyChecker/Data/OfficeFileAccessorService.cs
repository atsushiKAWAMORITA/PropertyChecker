using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using System.IO;
using System.IO.Packaging;
using ClosedXML.Excel;
using NPOI.HSSF.UserModel;
using iTextSharp.text.pdf;
using iTextSharp.text;
namespace PropertyChecker.Data
{
    public class OfficeFileAccessorService
    {
        public string Title { get; private set; }
        public string Subject { get; private set; }
        public string Author { get; private set; }
        public string Keywords { get; private set; }
        public string Comments { get; private set; }
        public string Template { get; private set; }
        public string LastAuthor { get; private set; }
        public string RevisionNumber { get; private set; }
        public string ApplicationName { get; private set; }
        public string LastPrintDate { get; private set; }
        public string CreationDate { get; private set; }
        public string LastSaveTime { get; private set; }
        public string TotalEditingTime { get; private set; }
        public string NumberofPages { get; private set; }
        public string NumberofWords { get; private set; }
        public string NumberofCharacters { get; private set; }
        public string Security { get; private set; }
        public string Category { get; private set; }
        public string Format { get; private set; }
        public string Manager { get; private set; }
        public string Company { get; private set; }
        public string NumberofBytes { get; private set; }
        public string NumberofLines { get; private set; }
        public string NumberofParagraphs { get; private set; }
        public string NumberofSlides { get; private set; }
        public string NumberofNotes { get; private set; }
        public string NumberofHiddenSlides { get; private set; }
        public string NumberofMultimediaClips { get; private set; }
        public string HyperlinkBase { get; private set; }

        public string OfficeFileName { get; private set; }
        public OfficeFileAccessorService(string officeFileName)
        {
            try
            {
                OfficeFileName = officeFileName;
                GetOfficeProperties();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void GetOfficeProperties()
        {
            try
            {
                if (!File.Exists(OfficeFileName)) { throw new FileNotFoundException(Properties.Resources.FileNotExists); }
                //Excel
                if (Regex.IsMatch(OfficeFileName, Properties.Resources.ExcelExtentionRX))
                {
                    using (FileStream fs = new FileStream(OfficeFileName, FileMode.Open, FileAccess.Read))
                    {
                        var workbook = new HSSFWorkbook(fs);
                        var info = workbook.SummaryInformation;
                        Title = info.Title;
                        Subject = info.Subject;
                        Author = info.Author;
                        Keywords = info.Keywords;
                        LastAuthor = info.LastAuthor;
                        RevisionNumber = info.RevNumber;
                        LastPrintDate = info.LastPrinted.ToString();
                        CreationDate = info.CreateDateTime.ToString();
                        var dinfo = workbook.DocumentSummaryInformation;
                    }
                }
                //Word
                if (Regex.IsMatch(OfficeFileName, Properties.Resources.WordExtentionRX))
                {
                    using (var document = WordprocessingDocument.Open(OfficeFileName, false))
                    {
                        var props = document.PackageProperties;
                        Title = props.Title;
                        Subject = props.Subject;
                        Author = props.Creator;
                        Keywords = props.Keywords;
                        LastAuthor = props.LastModifiedBy;
                        RevisionNumber = props.Revision;
                        LastPrintDate = props.LastPrinted.ToString();
                        CreationDate = props.Created.ToString();
                        Category = props.Category;
                        var props2 = document.ExtendedFilePropertiesPart.Properties;
                    }
                }
                //Power Point
                if (Regex.IsMatch(OfficeFileName, Properties.Resources.PowerPointExtentinRX))
                {
                    using (var slide = PresentationDocument.Open(OfficeFileName, false))
                    {
                        var props = slide.PackageProperties;
                        Title = props.Title;
                        Subject = props.Subject;
                        Author = props.Creator;
                        Keywords = props.Keywords;
                        LastAuthor = props.LastModifiedBy;
                        RevisionNumber = props.Revision;
                        LastPrintDate = props.LastPrinted.ToString();
                        CreationDate = props.Created.ToString();
                        Category = props.Category;
                    }
                }
                //PDF
                if(Regex.IsMatch(OfficeFileName, Properties.Resources.PDFExtentionRX))
                {
                    PdfReader reader = new PdfReader(OfficeFileName);
                    Title = reader.Info["Title"].ToString();
                    Subject = reader.Info["Subject"].ToString();
                    Author = reader.Info["Author"].ToString();
                    Keywords = reader.Info["Keywords"].ToString();
                    CreationDate = reader.Info["CreationDate"].ToString();
                    Category = reader.Info["Category"].ToString();
                    reader.Close();
                }
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
                if (!File.Exists(OfficeFileName)) { throw new FileNotFoundException(Properties.Resources.FileNotExists); }
                if (Regex.IsMatch(OfficeFileName, Properties.Resources.ExcelExtentionRX))
                {
                    using (FileStream fs = new FileStream(OfficeFileName, FileMode.Open, FileAccess.Write))
                    {
                        var workbook = new HSSFWorkbook(fs);
                        var info = workbook.SummaryInformation;
                        var dinfo = workbook.DocumentSummaryInformation;
                        info.RemoveApplicationName();
                        info.RemoveAuthor();
                        info.RemoveCharCount();
                        info.RemoveComments();
                        info.RemoveCreateDateTime();
                        info.RemoveEditTime();
                        info.RemoveKeywords();
                        info.RemoveLastAuthor();
                        info.RemoveLastPrinted();
                        info.RemoveLastSaveDateTime();
                        info.RemovePageCount();
                        info.RemoveRevNumber();
                        info.RemoveSecurity();
                        info.RemoveSubject();
                        info.RemoveTemplate();
                        info.RemoveThumbnail();
                        info.RemoveTitle();
                        info.RemoveWordCount();
                        dinfo.RemoveByteCount();
                        workbook.Write(fs);
                        fs.Flush();
                        fs.Close();
                    }

                }
                if (Regex.IsMatch(OfficeFileName, Properties.Resources.WordExtentionRX))
                {
                    using (var document = WordprocessingDocument.Open(OfficeFileName, false))
                    {
                        var props = document.PackageProperties;
                        props.Title = "";
                        props.Subject = "";
                        props.Creator = "";
                        props.Keywords = "";
                        props.LastModifiedBy = "";
                        props.Revision = "";
                        props.Category = "";
                        document.Save();
                    }
                }
                if (Regex.IsMatch(OfficeFileName, Properties.Resources.PowerPointExtentinRX))
                {
                    using (var slide = PresentationDocument.Open(OfficeFileName, false))
                    {
                        var props = slide.PackageProperties;
                        props.Title = "";
                        props.Subject = "";
                        props.Creator = "";
                        props.Keywords = "";
                        props.LastModifiedBy = "";
                        props.Revision = "";
                        props.Category = "";
                        slide.Save();
                    }
                }
                //PDF
                if (Regex.IsMatch(OfficeFileName, Properties.Resources.PDFExtentionRX))
                {
                    var reader = new PdfReader(OfficeFileName);
                    var stamper = new PdfStamper(reader, new FileStream(OfficeFileName, FileMode.Open));
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
