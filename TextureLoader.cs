using Mapping;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mapping
{
    class TextureLoader
    {
        private int lowestItemIndex;

        public TextureLoader(int lowestItem)
        {
            lowestItemIndex = lowestItem;
        }

        private Dictionary<int, Texture2D> loadIntoMemory(string dirName)
        {
            DirectoryInfo dir = new DirectoryInfo(Content.RootDirectory + "\\" + dirName);
            Dictionary<int, Texture2D> result = new Dictionary<int, Texture2D>();
            FileInfo[] files = dir.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                int key = Convert.ToInt32(Path.GetFileNameWithoutExtension(file.Name));
                result[key] = Content.Load<Texture2D>(dirName + "/" + key);
                if (key < lowestItemIndex)
                {
                    Debug.WriteLine("Asset number " + key + " loaded...");
                }
                else
                {
                    Debug.WriteLine("Item number " + key + " loaded...");
                }
            }

            return result;
        }
    }
}
