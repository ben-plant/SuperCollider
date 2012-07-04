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
    public class Tile
    {
        public Rectangle tilePosition;
        public Rectangle tileItemPosition;
        public Texture2D tileTexture;
        public Item thisTileItem = null;

        public Dictionary<int, Texture2D> itemCatalogue;

        public Tile(Rectangle tilePos, int tileTextureID, Dictionary<int, Texture2D> tileCat, Dictionary<int, Texture2D> itemCat)
        {
            this.tilePosition = tilePos;
            this.tileTexture = tileCat[tileTextureID];
            this.itemCatalogue = itemCat;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tileTexture, tilePosition, Color.White);
        }

        public void addItemToTile(int itemNumber)
        {
            this.thisTileItem = new Item(itemNumber, itemCatalogue);
        }
    }
}
