using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;  
namespace DataProcessor;

public class DocumentGenerator
{
    //using file stream
    public static void CreatePdf()
    {
        //string outputFilePath = @"C:\iTextPdf";
        string outputFilePath = Path.Combine(@"C:\Users\hp\", "iTextPdf");    
        Random random = new Random();
        
        string filename = string.Concat("here",random.Next(0, 1000) ,".pdf");
        string path = Path.Combine(outputFilePath, filename);
        string directoryPath = Path.GetDirectoryName(path);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        using (FileStream memoryStream = new FileStream(directoryPath,FileMode.Create))
        {
            //Create document object
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            //Create PDF Writer that writes the PDF content to the MemoryStream
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            // Open the document for writing
            document.Open();
            // Add content to the PDF (This will generate a large PDF)
            //document.Add(new Paragraph("Hello World"));
            AddContentToPdf(document);
            // Close the document (This finalizes the PDF and writes to the MemoryStream)
            document.Close();
        }
    }

    public static void CreatePdfMemStream()
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            //Create document object
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            //Create PDF Writer that writes the PDF content to the MemoryStream
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            // Open the document for writing
            document.Open();
            // Add content to the PDF (This will generate a large PDF)
            //document.Add(new Paragraph("Hello World"));
            AddContentToPdf(document);
            // Close the document (This finalizes the PDF and writes to the MemoryStream)
            document.Close();
            // After closing, the MemoryStream contains the PDF
            byte[] pdfData = memoryStream.ToArray();
            // Optionally: Save the PDF data to a physical file
            File.WriteAllBytes("itextPdf.pdf", pdfData);
        }
    }
    public static void AddContentToPdf(Document document)
    {
        for (int i = 0; i < 1000; i++) // This creates 1000 pages
        {
            document.Add(new Paragraph($"This is page {i + 1} of the large PDF document generated with iTextSharp."));
        }
    }
    
}
