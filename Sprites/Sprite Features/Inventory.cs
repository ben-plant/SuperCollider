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

using SuperCollider.Objects;

namespace SuperCollider.Sprites.SpriteFeatures
{
    class Inventory
    {
        public Item[,] thisInventory;
        public Vector2 currentItem;
        public Texture2D invTex;

        public Item leftHand;
        public Item rightHand;

        public Inventory(int inventoryX, int inventoryY)
        {
            //NPC INVENTORY
            this.invTex = null;
            thisInventory = new Item[inventoryX, inventoryY];
            currentItem = Vector2.Zero;
        }

        public Inventory(Texture2D inventoryTex, int inventoryX, int inventoryY)
        {
            //PLAYER INVENTORY
            this.invTex = inventoryTex;
            thisInventory = new Item[inventoryX, inventoryY];
            currentItem = Vector2.Zero;
        }

        public void addItem()
        {
        }

        //public Item takeItem()
        //{
        //}

        public void updateInventory(SpriteBatch spriteBatch)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
