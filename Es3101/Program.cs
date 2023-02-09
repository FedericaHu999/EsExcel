using System.Drawing;
using System.Linq;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;

namespace Es3101
{
    class Program
    {
        //  fare un programma che legge i file contenuti in una cartella
        //  nella cartella ci saranno solo file di tipo immagine(es.jpg)
        //  stampare a video il nome del file e la dimensione(altezza e larghezza) delle immagini

        // creare file txt e inserire all'interno nome dei file, lunghezza e larghezza separati da ;
        // creare file excel e inserire all'interno nome del file, lunghezza e altezza nelle varie colonne.
        static void Main(string[] args)
        {
            var path = "C:\\imgs";
            string[] files = Directory.GetFiles(path);
            FileInfo fi = new("C:\\imgs\\text.txt");
            FileStream fs = fi.Create();
            fs.Close();
            StreamWriter newText = fi.CreateText();


            foreach (var file in files)
            {
                Image sourceImage = Image.FromFile(file);
                newText.WriteLine(Path.GetFileName(file) + " " + sourceImage.Height + " " + sourceImage.Width + ";");
            }
            newText.Close();

            //var img = new Images();
            //img.GetName("C:\\imgs");
            //img.GetSize("C:\\imgs");

            // Excel 

            var newFile = @"C:\\imgs\\newbook.core.xlsx";

            using (var excelFs = new FileStream(newFile, FileMode.Create, FileAccess.Write))
            {

                IWorkbook workbook = new XSSFWorkbook();

                ISheet sheet1 = workbook.CreateSheet("Sheet1");

                sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 10));
                var rowIndex = 0;
                IRow row = sheet1.CreateRow(rowIndex);

                    row.CreateCell(0).SetCellValue("this is content");
                //    sheet1.AutoSizeColumn(0);
                //    rowIndex++;
               
            }
        }
    }
}