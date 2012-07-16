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

using SuperCollider.Sprites.NonPlayable;
using SuperCollider.Sprites.SpriteFeatures;

namespace SuperCollider.Sprites.Playable
{
    public class Player : Sprite
    {
        private KeyboardState keyState;
        private KeyboardState prevKeyState;
        public static string playerName = "Sylvester Cordello";
        public List<Sprite> spriteInventory;
        private bool checkingInventory;


        public Player(Vector2 spawn, Texture2D tex, Texture2D debugTexture, List<Rectangle> boundsTiles, List<Sprite> charInv) : base(playerName, spawn, tex, debugTexture, boundsTiles)
        {
            this.spriteInventory = charInv;
            this.thisSpriteState = SpriteState.PLAYING;
        }

        public void Update(GameTime gameTime)
        {
            this.keyState = Keyboard.GetState();
            if (!checkingInventory)
            {
                updateMovement(keyState, this.wallTiles);
            }
            else
            {
                updateInventory();
            }
            updateActionKey(keyState);
            updateControlBoxes();

            this.prevKeyState = keyState;
        }

        public void updateMovement(KeyboardState keyState, List<Rectangle> wallTiles)
        {
            spriteDirection = Vector2.Zero;

            foreach (Rectangle tile in wallTiles)
            {
                if (!tile.Contains(spriteBoundsBox))
                {
                    if ((keyState.IsKeyDown(Keys.Down) == true) && (prevKeyState.IsKeyDown(Keys.Down) == false))
                    {
                        spriteFacingDirection = 2;
                        spriteDirection.Y = 1;
                    }
                    if ((keyState.IsKeyDown(Keys.Up) == true) && (prevKeyState.IsKeyDown(Keys.Up) == false))
                    {
                        spriteFacingDirection = 0;
                        spriteDirection.Y = -1;
                    }

                    if ((keyState.IsKeyDown(Keys.Left) == true) && (prevKeyState.IsKeyDown(Keys.Left) == false))
                    {
                        spriteFacingDirection = 3;
                        spriteDirection.X = -1;
                    }

                    if ((keyState.IsKeyDown(Keys.Right) == true) && (prevKeyState.IsKeyDown(Keys.Right) == false))
                    {
                        spriteFacingDirection = 1;
                        spriteDirection.X = 1;
                    }
                }
                else
                {
                    switch (spriteFacingDirection)
                    {
                        case 0:
                            spriteLocation.Y += 32;
                            break;
                        case 1:
                            spriteLocation.X -= 32;
                            break;
                        case 2:
                            spriteLocation.Y -= 32;
                            break;
                        case 3:
                            spriteLocation.X += 32;
                            break;
                        default:
                            break;
                    }
                }
                this.spriteBoundsBox = new Rectangle((int)spriteLocation.X, (int)spriteLocation.Y, 32, 32);
            }
            this.spriteLocation += (spriteDirection * spriteSpeed);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteTexture, spriteDrawBox, Color.White);

            if (checkingInventory)
            {
                spriteBatch.Draw(base.spriteLocationTexture, this.spriteBoundsBox, Color.Yellow);
                spriteBatch.Draw(base.spriteLocationTexture, spriteSelectionBox, Color.Red);
                spriteBatch.Draw(base.spriteLocationTexture, this.spriteDrawBox, Color.LimeGreen);
            }
        }

        public override void identifySprite()
        {
            Debug.WriteLine("Player " + spriteIdentifier + " spawned at " + spriteBoundsBox.X + ", " + spriteBoundsBox.Y + ".");
        }

        public void updateActionKey(KeyboardState keyState)
        {
            if ((keyState.IsKeyDown(Keys.I) == true) && (prevKeyState.IsKeyDown(Keys.I) == false))
            {
                this.thisSpriteState = SpriteState.CHECK_INV;
                this.checkingInventory = !checkingInventory;
            }

            foreach (NPC sprite in spriteInventory)
            {
                if ((keyState.IsKeyDown(Keys.A) == true) && (prevKeyState.IsKeyDown(Keys.A) == false) && this.spriteSelectionBox.Contains(sprite.hitBox))
                {
                    sprite.triggerNPCEvent();
                }
            }
        }

        public void updateInventory()
        {
        }
    }
}
