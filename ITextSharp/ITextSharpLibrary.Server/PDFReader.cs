using System;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Data;
using System.Text;

namespace ITextSharpLibrary.Server
{
    public static class PDFReader
    {
        public static string pdfText(string path)
        {
            PdfReader reader = new PdfReader(path);
            string text = string.Empty;
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                text += PdfTextExtractor.GetTextFromPage(reader, page);
            }
            reader.Close();
            return text;
        }

        public static string ReadText(string filename )
        {
            string strText = string.Empty;

            using (PdfReader documentReader = new PdfReader(filename))
            {
                for (int page = 1; page <= documentReader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy();

                    using (PdfReader pageReader = new PdfReader(filename))
                    {
                        String s = PdfTextExtractor.GetTextFromPage(pageReader, page, its);

                        s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                        strText = strText + s;
                        pageReader.Close();
                    }
                }
            }
            return strText;
        }

    }
}

