using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDataAnalyzerProject
{
    public class TxtFileAnalyzer : FileAnalyzer, IFileAnalysis
    {
        public void AnalyzeFile(FileInfo fileInfo)
        {
            //store all txt of the file
            string path = fileInfo.FullName; //get full path of directory or file
            string FileString = File.ReadAllText(path);
            AnalysisResult results = new AnalysisResult();

            //calc number of words
            string[] words = FileString.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            results.WordCount = words.Length;

            //calc number of chars
            results.CharsCount = FileString.Length;

            //calc number of lines
            var lines = File.ReadAllLines(path);
            results.LinesCount = lines.Length;


            SetResults(results);
        }
    }
}
