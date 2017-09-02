using System;
using System.IO;
using System.Text;
namespace PropertyChecker.Data
{
    public class PropertyItem
    {
        
        public string FileFullPath { get; private set; }
        public string FileName { get; private set; }
        public string Path { get; private set; }
        public string RelativePath { get; private set; }
        public string FileBaseName { get; private set; }
        public string Extension { get; private set; }
        public DateTime Creation​Time { get; private set; }
        public string CreationTimeString { get; private set; }
        public DateTime Creation​Time​Utc { get; private set; }
        public string CreationTimeUtcString { get; private set; }
        public DateTime Last​Access​Time { get; private set; }
        public string Last​Access​TimeString { get; private set; }
        public DateTime Last​Access​Time​Utc { get; private set; }
        public string Last​Access​Time​UtcString { get; private set; }
        public DateTime Last​Write​Time { get; private set; }
        public string Last​Write​TimeString { get; private set; }
        public DateTime Last​Write​Time​Utc { get; private set; }
        public string Last​Write​Time​UtcString { get; private set; }
        public FileAttributes Attribute { get; private set; }
        public bool IsChangePropertyTarget { get; set; }
        public string Title { get; private set; }
        public string Subject { get; private set; }
        public string Author { get; private set; }
        public string Keywords { get; private set; }
        public string Comments { get; private set; }
        public string Template { get; private set; }
        public string LastAuthor{ get; private set; }
        public string RevisionNumber{ get; private set; }
        public string ApplicationName{ get; private set; }
        public string LastPrintDate { get; private set; }
        public string CreationDate{ get; private set; }
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
        
        public PropertyItem(string targetDirectory, string fileNameFullPath)
        {
            try
            {
                if(string.IsNullOrEmpty(targetDirectory) || string.IsNullOrWhiteSpace(targetDirectory))
                {
                    throw new ArgumentNullException(Properties.Resources.FileIsNotExists.ToString());
                }
                if (string.IsNullOrEmpty(fileNameFullPath) || string.IsNullOrWhiteSpace(fileNameFullPath))
                {
                    throw new ArgumentNullException(Properties.Resources.FileIsNotExists.ToString());
                }
                if (!File.Exists(fileNameFullPath))
                {
                    throw new FileNotFoundException(Properties.Resources.FileIsNotExists.ToString());
                }
                this.FileFullPath = fileNameFullPath;
                this.Extension = System.IO.Path.GetExtension(FileFullPath);
                this.Path = System.IO.Path.GetDirectoryName(FileFullPath);
                this.RelativePath = RelativePathString(targetDirectory, this.Path);
                this.FileBaseName = System.IO.Path.GetFileNameWithoutExtension(FileFullPath);
                this.Attribute = File.GetAttributes(fileNameFullPath);
                this.FileName = this.FileBaseName + this.Extension;
                this.CreationTime = File.GetCreationTime(fileNameFullPath);
                this.CreationTimeUtc = File.GetCreationTimeUtc(fileNameFullPath);
                this.LastAccessTime = File.GetLastAccessTime(fileNameFullPath);
                this.LastAccessTimeUtc = File.GetLastAccessTimeUtc(fileNameFullPath);
                this.LastWriteTime = File.GetLastWriteTime(fileNameFullPath);
                this.LastWriteTimeUtc = File.GetLastWriteTimeUtc(fileNameFullPath);
                this.CreationTimeString = this.CreationTime.ToString();
                this.CreationTimeUtcString = this.CreationTimeUtc.ToString();
                this.LastAccessTimeString = this.LastAccessTime.ToString();
                this.LastAccessTimeUtcString = this.LastAccessTimeUtc.ToString();
                this.LastWriteTimeString = this.LastWriteTime.ToString();
                this.LastWriteTimeUtcString = this.LastWriteTimeUtc.ToString();
                GetOfficeProperties();
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
                var officeFile = new OfficeFileAccessorService(FileFullPath);
                officeFile.SetProperty();
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
                var officeFile = new OfficeFileAccessorService(FileFullPath);
                Title = officeFile.Title;
                Subject = officeFile.Subject;
                Author = officeFile.Author;
                Keywords = officeFile.Keywords;
                Comments = officeFile.Comments;
                Template = officeFile.Template;
                LastAuthor = officeFile.LastAuthor;
                RevisionNumber = officeFile.RevisionNumber;
                ApplicationName = officeFile.ApplicationName;
                LastPrintDate = officeFile.LastPrintDate;
                CreationDate = officeFile.CreationDate;
                LastSaveTime = officeFile.LastSaveTime;
                TotalEditingTime = officeFile.TotalEditingTime;
                NumberofPages = officeFile.NumberofPages;
                NumberofWords = officeFile.NumberofWords;
                NumberofCharacters = officeFile.NumberofCharacters;
                Security = officeFile.Security;
                Category = officeFile.Category;
                Format = officeFile.Format;
                Manager = officeFile.Manager;
                Company = officeFile.Company;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string RelativePathString(string absPath, string relTo)
        {
            if (absPath.Equals(relTo)) { return @"."; }
            string[] absDirs = absPath.Split('\\');
            string[] relDirs = relTo.Split('\\');
            // Get the shortest of the two paths 
            int len = absDirs.Length < relDirs.Length ? absDirs.Length : relDirs.Length;
            // Use to determine where in the loop we exited 
            int lastCommonRoot = -1; int index;
            // Find common root 
            for (index = 0; index < len; index++)
            {
                if (absDirs[index] == relDirs[index])
                    lastCommonRoot = index;
                else break;
            }
            // If we didn't find a common prefix then throw 
            if (lastCommonRoot == -1)
            {
                throw new ArgumentException("Paths do not have a common base");
            }
            // Build up the relative path 
            StringBuilder relativePath = new StringBuilder();
            // Add on the .. 
            for (index = lastCommonRoot + 1; index < absDirs.Length; index++)
            {
                if (absDirs[index].Length > 0) relativePath.Append("..\\");
            }
            // Add on the folders 
            for (index = lastCommonRoot + 1; index < relDirs.Length - 1; index++)
            {
                relativePath.Append(relDirs[index] + "\\");
            }
            relativePath.Append(relDirs[relDirs.Length - 1]);
            return relativePath.ToString();
        }
    }
}
