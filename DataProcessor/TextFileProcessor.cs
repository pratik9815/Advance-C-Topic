using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor
{
    public class TextFileProcessor
    {
        public string InputFilePath { get; set; }
        public string OutputFilePath { get; set; }
        public TextFileProcessor(string inputFilePath, string outputFilePath)
        {
            InputFilePath = inputFilePath;
            OutputFilePath = outputFilePath;
        }
        public void Process()
        {

        }
    }
}
