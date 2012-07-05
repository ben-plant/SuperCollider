using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperCollider;

namespace SuperCollider
{
    class Room
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
