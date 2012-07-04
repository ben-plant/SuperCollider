using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Mapping
{
    public class Item
    {
        public int itemIndex;
        private Texture2D itemTexture;

        public Item(int itemNo, Dictionary<int, Texture2D> itemCatalogue)
        {
            this.itemIndex = itemNo;
            this.itemTexture = itemCatalogue[itemIndex];
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle tileDrawPosition)
        {
            spriteBatch.Draw(itemTexture, tileDrawPosition, Color.White);
        }
    }
}
