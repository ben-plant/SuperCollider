using Mapping;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SylvesterCordello
{
    public class MapEngine
    {
        /* Manages the map as a whole, spawning and initializing buildings according to a master plan.
         * Each building then spawns its own Room() groups according to its own text file, which it is
         * designated by this class.
         */

        StreamReader streamReader;
        StringBuilder stringBuilder;

        public List<Building> buildingsInMap = new List<Building>();
        

        public Building[,] masterMapArray;

        public bool debugMap = false;
        private Texture2D debugTexture;

        public MapEngine(Texture2D debugTex)
        {
            this.debugTexture = debugTex;
            Debug.WriteLine("Mapping engine engaged...");

        }

        public bool generateMap()
        {
            Debug.WriteLine("Map generation initiated...");
            streamReader = new StreamReader("City01.TXT");
            stringBuilder = new StringBuilder();

            while (currentMapX != mapSizeX)
            {
                string line = streamReader.ReadToEnd();

                foreach (char digit in line)
                {
                    if (char.IsNumber(digit))
                    {
                        stringBuilder.Append(digit);
                    }
                    else if (char.IsSeparator(digit))
                    {
                        string tempStr = stringBuilder.ToString();
                        masterMapArray[currentMapX, currentMapY] = Convert.ToInt32(tempStr);
                        stringBuilder.Remove(0, stringBuilder.Length);
                        ++currentMapY;
                    }
                    else if (char.IsLetter(digit))
                    {
                        stringBuilder.Remove(0, stringBuilder.Length);
                        currentMapY = 0;
                        currentMapX++;
                    }
                }
            }

            streamReader.Close();
            return true;
        }

        public void printMap()
        {
            Debug.WriteLine(masterMapArray[1, 0]);
        }

        public List<Tile> tileMap(Dictionary<int, Texture2D> tileCatalogue, Dictionary<int, Texture2D> itemCatalogue)
        {
            Rectangle tempRect = new Rectangle(0, 0, 32, 32);

            for (int controlVar1 = 0; controlVar1 <= masterMapArray.GetUpperBound(0); controlVar1++)
            {
                for (int controlVar2 = 0; controlVar2 <= masterMapArray.GetUpperBound(1); controlVar2++)
                {
                    int tempValue = masterMapArray[controlVar1, controlVar2];
                    Tile tempTile = new Tile(tempRect, tempValue, tileCatalogue, itemCatalogue);
                    this.masterTiledMapArray[controlVar1, controlVar2] = tempTile;
                    this.thisMap.Add(tempTile);
                    if (!tilesThatCanBeWalkedOn.Contains(tempValue))
                    {
                        wallTilesInMap.Add(tempRect);
                    }
                    else
                    {
                        floorTilesInMap.Add(tempRect);
                        tempTile.tileItemPosition = new Rectangle(tempTile.tilePosition.X + 4, tempTile.tilePosition.Y + 4, 24, 24);
                        tempTile.addItemToTile(99901);
                    }
                    tempRect.X += 32;
                    Debug.WriteLine("Tile value " + tempValue + " loaded at " + tempRect.X + ", " + tempRect.Y + ".");
                }

                tempRect.X = 0;
                tempRect.Y += 32;
            }

            return thisMap;
        }

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
