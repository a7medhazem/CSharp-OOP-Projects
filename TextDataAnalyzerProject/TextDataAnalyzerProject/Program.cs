using System.Threading.Tasks;

namespace TextDataAnalyzerProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tWelcome to Text Data Analyzer System.");
            Console.WriteLine("*******************************************************");
            Console.WriteLine("This program analyzes files in a given folder.");
            Console.WriteLine("It supports two file types:");
            Console.WriteLine("  - Text files (.txt): counts words, characters, and lines.");
            Console.WriteLine("  - CSV files (.csv): counts fields.");
            Console.WriteLine("*******************************************************");
            Console.Write("Please enter folder path: ");

            var FolderPath = Console.ReadLine();

            DirectoryInfo Folder = new DirectoryInfo(FolderPath);

            // Check existence for the path of the directory
            if (Folder.Exists == false)
            {
                Console.WriteLine("Folder doesn't exist ");
                return;

            }

            //retrieves all the files in the folder
            var FilesNames = Folder.GetFiles();

            IFileAnalysis fileanalysis = null;
            foreach (var file in FilesNames)
            {
                if (file.IsTextFile())
                {
                    fileanalysis = new TxtFileAnalyzer();
                    fileanalysis.AnalyzeFile(file);
                    //casting from TxtFileAnalyzer to FileAnalyzer
                    var results = ((FileAnalyzer)fileanalysis).GetResults();

                    Console.WriteLine($"File name: {file.Name}");
                    Console.WriteLine($"Words count: {results.WordCount}");
                    Console.WriteLine($"Chars count: {results.CharsCount}");
                    Console.WriteLine($"Lines count: {results.LinesCount}");
                    Console.WriteLine("*******************************************************");
                }
                else if (file.IsCsvFile())
                {
                    fileanalysis = new CSVFileAnalyzer();
                    fileanalysis.AnalyzeFile(file);
                    //casting from TxtFileAnalyzer to FileAnalyzer
                    var results = ((FileAnalyzer)fileanalysis).GetResults();

                    Console.WriteLine($"File name: {file.Name}");
                    Console.WriteLine($"Fields count: {results.FieldsCount}");
                    Console.WriteLine("*******************************************************");
                }
                else
                {
                    Console.WriteLine($"File '{file.Name}' type is not supported.");

                }
            }
        }
    }
}
