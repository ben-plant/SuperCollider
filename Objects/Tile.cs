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

namespace SuperCollider
{
    public class Tile
    {
        public Rectangle tilePosition;
        public Rectangle tileItemPosition;
        public Texture2D tileTexture;
        public bool tileCanBeWalkedOn;
        public Item thisTileItem = null;

        public Tile(Rectangle tilePos, int tileTextureID, bool? canTileBeWalkedOn)
        {
            this.tilePosition = tilePos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tileTexture, tilePosition, Color.White);
        }

        public void addItemToTile(int itemNumber)
        {
            this.thisTileItem = new Item(itemNumber);
        }
    }
}
