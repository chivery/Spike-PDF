using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITextSharpLibrary.Server;

namespace ITextSharpLibrary.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //@"D:\Development\Spike Projects\Office\PDF\ITextSharp\ITextSharpLibrary.Help\IText 5.5.13 Read Me.pdf");
            string fileName = @"..\..\..\ITextSharpLibrary.Help\IText 5.5.13 Read Me.pdf"; // AbsolutePathToRelative();
            string text = PDFReader.ReadText(fileName);
            Console.Write(text);
            Console.ReadKey();
        }

        static string AbsolutePathToRelative()
        {
            System.Uri uri1 = new Uri(AppDomain.CurrentDomain.BaseDirectory);

            System.Uri uri2 = new Uri(@"D:\Development\Spike Projects\Office\PDF\ITextSharp\ITextSharpLibrary.Help\");



            Uri relativeUri = uri1.MakeRelativeUri(uri2);



           return relativeUri.ToString();


        }
    }
}
