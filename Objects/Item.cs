using SuperCollider;
using SuperCollider.Engines;
using SuperCollider.Objects;
using SuperCollider.CityComponents;

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


namespace SuperCollider.Objects
{
    public class Item
    {
        private readonly Vector2 itemSize = new Vector2(24, 24);

        public Texture2D itemTexture
        {
            get
            {
                return itemTexture;
            }
            set
            {
                itemTexture = value;
            }
        }

        public int itemIndex
        {
            get
            {
                return itemIndex;
            }
            set
            {
                itemIndex = value;
            }
        }

        public Vector2 itemPlacement
        {
            get
            {
                return itemPlacement;
            }
            set
            {
                itemPlacement = value;
            }
        }

        public Item(Vector2 itemPlacement, int itemID)
        {
            GlobalDictionaries.itemsOnMap++;

            this.itemIndex = itemID;
            this.itemTexture = GlobalDictionaries.masterItemCatalogue[itemID];
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle tileDrawPosition)
        {
            spriteBatch.Draw(itemTexture, new Rectangle((int)itemPlacement.X, (int)itemPlacement.Y, (int)itemSize.X, (int)itemSize.Y), Color.White);
        }
    }
}
