using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDataAnalyzerProject
{
    public class CSVFileAnalyzer : FileAnalyzer, IFileAnalysis
    {
        public void AnalyzeFile(FileInfo fileInfo)
        {
            //store arrat
            string[] FileString = File.ReadAllLines(fileInfo.FullName);//fileInfo.FullName ==>get full path of directory or file
            string[] fields = FileString[0].Split(',');
            AnalysisResult results = new AnalysisResult();
            results.FieldsCount = fields.Length;
            SetResults(results);
        }
    }
}
