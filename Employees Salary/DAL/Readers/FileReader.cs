using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
namespace Employees_Salary.DAL.Readers
{
    public class FileReader :IHelper
    {
        private static readonly Encoding Utf8NoBOM = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);


        #region ListDirectoriesAndFiles
        private static string Normalize(string sPath) =>
           Path.GetFullPath(sPath ?? throw new ArgumentNullException(nameof(sPath)));
        private  static void CheckDirectoryExistence(string fullFilePath)
        {
            var directory = Path.GetDirectoryName(fullFilePath);

            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);
        }
       


        #endregion
     
        public string Read(string path,out string message)
        {
            //intialize message to empty string
            message = string.Empty;

            //normalize the path and check if the file exists, if not create it and return empty string
            string FullPath = Normalize(path);
            if (!File.Exists(FullPath))
            {
                CheckDirectoryExistence(FullPath);
              File.WriteAllTextAsync(FullPath, string.Empty, Utf8NoBOM);
                message = "Employees.json file does not exist.";
                return string.Empty;
            }
            //read the content of the file and check if it is empty, if so return a message
            var content = File.ReadAllText(FullPath, Utf8NoBOM);

            if (string.IsNullOrEmpty(content))
            {
               message  = "Employees.json file is empty.";
            }
            return content;
        }    
        

    }
}
