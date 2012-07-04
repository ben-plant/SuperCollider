using System;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace Mapping
{
    class FileParser
    {
        private StreamReader streamReader;
        private StringBuilder stringBuilder = new StringBuilder();
        
        private int currentMapWidth;
        private int currentMapHeight;
        private int currentScanningY;
        private int currentScanningX;
        private int[,] masterMapArray;

        public FileParser(string extension, string filename)
        {
            Debug.WriteLine("Map generation initiated...");
            this.parseFile(generateFilePath(extension, filename));
        }

        public string generateFilePath(string extension, string filename)
        {
            return (stringBuilder.Append(extension + "//" + filename)).ToString();
        }

        public int[,] parseFile(string filename)
        {
            streamReader = new StreamReader(filename);
            Debug.WriteLine("Loaded {0} into memory and scanning..." + filename);

            int linesInFile = 0;
            string line = streamReader.ReadToEnd();

            foreach (char digit in line)
            {
                if (char.IsNumber(digit))
                {
                    stringBuilder.Append(digit);
                }
                else if (char.IsSeparator(digit))
                {
                    string tempStr = stringBuilder.ToString();
                    masterMapArray[currentScanningX, currentScanningY] = Convert.ToInt32(tempStr);
                    stringBuilder.Clear();
                    ++currentScanningX;
                }
                else if (char.IsLetter(digit))
                {
                    Debug.WriteLine("End of line character found. Moving to line {0}" + linesInFile++);
                    stringBuilder.Remove(0, stringBuilder.Length);
                    currentScanningX = 0;
                    currentScanningY++;
                }
            }

            Debug.WriteLine("Current job complete: closing instance.");
            streamReader.Close();
            return masterMapArray;
        }
    }
}
