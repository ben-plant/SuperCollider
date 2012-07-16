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

using SuperCollider;
using SuperCollider.Objects;

using SuperCollider.Sprites.SpriteFeatures;

namespace SuperCollider.Sprites.NonPlayable
{
    public class NPC : Sprite
    {
        public bool isNPCHostile;
        public int NPCHealth = 100;
        public readonly new SpriteState thisSpriteState = SpriteState.PLAYING;

        private int randomMovementCounter;

        public enum NPCWounds { STAB     = 10, 
                                SHOT     = 50, 
                                BLUDGEON = 30 };

        public NPC(string spriteName, Vector2 spawnPoint, Texture2D assetTexture, Texture2D debugTexture, List<Rectangle> boundsTiles, bool hostility) : base(spriteName, spawnPoint, assetTexture, debugTexture, boundsTiles)
        {
            this.spriteFacingDirection = 2;
            this.hitBox = new Rectangle(this.spriteBoundsBox.X + 8, this.spriteBoundsBox.Y + 8, 16, 16);
            this.isNPCHostile = hostility;
        }

        public override void identifySprite()
        {
            Debug.WriteLine("NPC " + spriteIdentifier + " spawned at " + spriteBoundsBox.X + ", " + spriteBoundsBox.Y + ".");
        }

        public void Update(GameTime gameTime)
        {
            this.updateControlBoxes();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (debugSprite)
            {
                spriteBatch.Draw(base.spriteLocationTexture, this.spriteSelectionBox, Color.HotPink);
            }
        }

        public void triggerNPCEvent()
        {
            Debug.WriteLine("NPC " + spriteIdentifier + " selected!", this.isNPCHostile == true ? "Hostile" : "Friendly");
        }

        public void isStabbed()
        {
        }

        public void isShot()
        {
        }

        public void isBludgeoned()
        {
        }
    }
}
