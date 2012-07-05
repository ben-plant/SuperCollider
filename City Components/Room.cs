using SuperCollider;
using SuperCollider.Engines;
using SuperCollider.Objects;
using SuperCollider.CityComponents;

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

namespace SuperCollider.CityComponents
{
    public class Room
    {
        public void renderMap(SpriteBatch mapBatch)
        {
            foreach (Tile tile in thisMap)
            {
                tile.Draw(mapBatch);
                if (tile.thisTileItem != null)
                {
                    tile.thisTileItem.Draw(mapBatch, tile.tileItemPosition);
                }
                if (debugMap)
                {
                    mapBatch.Draw(debugTexture, tile.tileItemPosition, Color.Orange);
                }
            }

        }

        private void defineFloorTiles()
        {
            streamReader = new StreamReader("floorTiles.TXT");

            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                tilesThatCanBeWalkedOn.Add(Convert.ToInt32(line));
            }
        }
    }
}
