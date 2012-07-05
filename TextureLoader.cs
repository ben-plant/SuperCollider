using SuperCollider;

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SuperCollider
{
    public class TextureLoader
    {
        ContentManager Content;
        

        public TextureLoader(ContentManager contentMan)
        {
            this.Content = contentMan;
        }

        public Dictionary<int, Texture2D> loadTilesIntoMemory(string dirName)
        {
            DirectoryInfo dir = new DirectoryInfo(Content.RootDirectory + "\\" + dirName);
            Dictionary<int, Texture2D> allTiles = new Dictionary<int, Texture2D>();

            FileInfo[] files = dir.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                int key = Convert.ToInt32(Path.GetFileNameWithoutExtension(file.Name));
                allTiles[key] = Content.Load<Texture2D>(dirName + "/" + key);
                Debug.WriteLine("Tile number " + key + " loaded...");
            }

            return allTiles;
        }

        public Dictionary<int, Texture2D> loadItemsIntoMemory(string dirName)
        {
            DirectoryInfo dir = new DirectoryInfo(Content.RootDirectory + "\\" + dirName);
            Dictionary<int, Texture2D> allItems = new Dictionary<int, Texture2D>();

            FileInfo[] files = dir.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                int key = Convert.ToInt32(Path.GetFileNameWithoutExtension(file.Name));
                if (key > 99901) //99901 will always be reserved as the Inventory screen
                {
                    allItems[key] = Content.Load<Texture2D>(dirName + "/" + key);
                    Debug.WriteLine("Asset number " + key + " loaded...");
                }
            }

            return allItems;
        }
    }
}
