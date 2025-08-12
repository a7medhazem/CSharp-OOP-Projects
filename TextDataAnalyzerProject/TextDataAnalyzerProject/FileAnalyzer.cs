using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDataAnalyzerProject
{
    public class FileAnalyzer
    {
        //feild
        private AnalysisResult Results;


        //proprties
        public AnalysisResult GetResults()
        {
            return Results;
        }
        public void SetResults(AnalysisResult reults)
        {

            Results = reults;
        }
    }
}
