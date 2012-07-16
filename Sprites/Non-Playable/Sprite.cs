using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperCollider.Sprites.NonPlayable
{
    public abstract class Sprite
    {
        public bool debugSprite = true;

        public string spriteIdentifier;

        public Vector2 spriteLocation;
        public Vector2 spriteDirection = Vector2.Zero;

        public Rectangle spriteBoundsBox;
        public Rectangle spriteDrawBox;

        public Texture2D spriteTexture;
        public Texture2D spriteLocationTexture;

        public int spriteFacingDirection;
        public int spriteSpeed;

        public Rectangle spriteSelectionBox;
        public Rectangle hitBox;

        public List<Rectangle> wallTiles;

        public enum SpriteState { CHECK_INV, PLAYING };
        public SpriteState thisSpriteState;

        public Sprite(string spriteName, Vector2 spawnPoint, Texture2D assetTexture, Texture2D debugTexture, List<Rectangle> boundsTiles)
        {
            this.wallTiles = boundsTiles;

            this.spriteIdentifier = spriteName;
            this.spriteTexture = assetTexture;
            this.spriteLocationTexture = debugTexture;
            this.spriteLocation = new Vector2(spawnPoint.X, spawnPoint.Y);
            this.spriteFacingDirection = 2;
            this.spriteSpeed = 32;

            spriteSelectionBox = new Rectangle(0, 0, 24, 24);
            spriteDrawBox = new Rectangle((int)spawnPoint.X, (int)spawnPoint.Y, 32, 50);
            spriteBoundsBox = new Rectangle(((int)spriteDrawBox.X), ((int)spriteDrawBox.Y), 32, 32);

            this.debugSprite = true;
            updateControlBoxes();
            identifySprite();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (debugSprite)
            {
                spriteBatch.Draw(spriteLocationTexture, spriteBoundsBox, Color.White);
            }
            spriteBatch.Draw(spriteTexture, spriteDrawBox, Color.White);
        }


        public virtual void identifySprite()
        {
            Debug.WriteLine("Sprite " + spriteIdentifier + " spawned at " + spriteBoundsBox.X + ", " + spriteBoundsBox.Y + ".");
        }


        public void updateControlBoxes()
        {
            switch (spriteFacingDirection)
            {
                case 0:
                    spriteSelectionBox.X = spriteBoundsBox.X + 4;
                    spriteSelectionBox.Y = spriteBoundsBox.Y - 28;
                    break;
                case 1:
                    spriteSelectionBox.Y = this.spriteBoundsBox.Y + 4;
                    spriteSelectionBox.X = this.spriteBoundsBox.X + 36;
                    break;
                case 2:
                    spriteSelectionBox.X = this.spriteBoundsBox.X + 4;
                    spriteSelectionBox.Y = this.spriteBoundsBox.Y + 36;
                    break;
                case 3:
                    spriteSelectionBox.Y = this.spriteBoundsBox.Y + 4;
                    spriteSelectionBox.X = this.spriteBoundsBox.X - 28;
                    break;
                default:
                    Debug.WriteLine("Selection box failure!");
                    break;
            }

            this.spriteDrawBox.X = spriteBoundsBox.X;
            this.spriteDrawBox.Y = (spriteBoundsBox.Y - 18);
        }

        //public void locateSprite()
        //{
        //    string tempDirection;
        //    switch (this.spriteFacingDirection)
        //    {
        //        case 0:
        //            tempDirection = "NORTH";
        //            break;
        //        case 1:
        //            tempDirection = "EAST";
        //            break;
        //        case 2:
        //            tempDirection = "SOUTH";
        //            break;
        //        case 3:
        //            tempDirection = "WEST";
        //            break;
        //        default:
        //            tempDirection = "FAIL";
        //            break;
        //    }
        //}
    }
}
