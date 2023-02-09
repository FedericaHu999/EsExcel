using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace Es3101
{
    public class Images
    {
        public void GetName(string path)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }

        public void GetSize(string path)
        {
            var sourceFolder = path;
            string[] sourceFiles = Directory.GetFiles(sourceFolder, "*", SearchOption.AllDirectories);
            foreach (string file in sourceFiles)
            {
                using (Image sourceImage = Image.FromFile(file))
                {
                    string sizes = "Width: " + sourceImage.Width + ". Height: " + sourceImage.Height;
                    Console.WriteLine(sizes);
                }
            }
            
        }

    }
}
