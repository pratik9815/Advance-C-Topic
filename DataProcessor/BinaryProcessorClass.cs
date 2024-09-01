using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor
{
    public class BinaryProcessorClass
    {
        public string InputFilePath { get; set; }
        public string OutputFilePath { get; set; }
        public BinaryProcessorClass(string inputFilePath, string outputFilePath) 
        {
            InputFilePath = inputFilePath;
            OutputFilePath = outputFilePath;
        }
        public void Process() 
        {
            byte[] data = File.ReadAllBytes(InputFilePath);
            byte largest = data.Max();
            byte[] newData = new byte[data.Length + 1];
            Array.Copy(data, newData, newData.Length);
            newData[newData.Length - 1] = largest;

            File.WriteAllBytes(OutputFilePath, newData);


        }
    }
}
