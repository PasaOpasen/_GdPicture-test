
using System;
using System.Windows;
using GdPicture14;


// https://www.gdpicture.com/guides/gdpicture/Optimize%20PDF%20MRC.html


GdPicturePDFReducer gdpicturePDFReducer = new GdPicturePDFReducer();

//PDFReducerConfiguration class provides different properties and options for the compression.
gdpicturePDFReducer.PDFReducerConfiguration.Author = "GdPicture.NET PDF Reducer SDK";
gdpicturePDFReducer.PDFReducerConfiguration.Producer = "GdPicture.NET 14";
gdpicturePDFReducer.PDFReducerConfiguration.ProducerName = "Orpalis";
gdpicturePDFReducer.PDFReducerConfiguration.Title = "MRC Compression";

//When compressing your PDF files, you have the possibility to decide which version of PDF to use.
gdpicturePDFReducer.PDFReducerConfiguration.OutputFormat = PDFReducerPDFVersion.PdfVersionRetainExisting;

//By selecting required options through the PDFReducerConfiguration class you enable or disable the features you want to accent.

gdpicturePDFReducer.PDFReducerConfiguration.RecompressImages = true;
gdpicturePDFReducer.PDFReducerConfiguration.DownscaleImages = false;
gdpicturePDFReducer.PDFReducerConfiguration.EnableParallelization = false;

//MRC compression.
gdpicturePDFReducer.PDFReducerConfiguration.EnableMRC = true;
// gdpicturePDFReducer.PDFReducerConfiguration.DownscaleResolutionMRC = 200;
gdpicturePDFReducer.PDFReducerConfiguration.PreserveSmoothing = true;

string input_pdf = "J:\\aprbot\\dreamocr\\examples\\local_runs\\result\\_deskew\\deskew.pdf";
string output_pdf = "J:\\aprbot\\dreamocr\\examples\\local_runs\\result\\_deskew\\deskew_opt.pdf";

long inputSize = new System.IO.FileInfo(input_pdf).Length;

//Processing the specified document.
GdPictureStatus status = gdpicturePDFReducer.ProcessDocument(input_pdf, output_pdf);
if (status == GdPictureStatus.OK)
{
    long outputSize = new System.IO.FileInfo(output_pdf).Length;
    int ratio = 100 - (int)(outputSize * 100 / inputSize);
    Console.WriteLine("The compression ratio is " + ratio + "%.\n" + inputSize / 100 + "KB -> " + outputSize / 100 + "KB");
}
else
{
    Console.WriteLine("The compression failed. Error: " + gdpicturePDFReducer.GetReducerStat());
    //You can also check reported warnings or the page number when an error has been reported.
}