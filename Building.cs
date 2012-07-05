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
using SuperCollider;

namespace SuperCollider
{
    public class Building
    {
        StreamReader streamReader;
        StringBuilder stringBuilder;

        public List<Tile> thisMap = new List<Tile>();
        public List<int> tilesThatCanBeWalkedOn = new List<int>();
        public List<Rectangle> wallTilesInMap = new List<Rectangle>();
        public List<Rectangle> floorTilesInMap = new List<Rectangle>();
        private Texture2D debugTexture;

        public int[,] masterMapArray;
        public Tile[,] masterTiledMapArray;

        int masterMapID;
        int mapSizeX;
        int mapSizeY;
        int currentMapX = 0; //Iterates top to bottom
        int currentMapY = 0; //Iterates left to right
        //This sort of makes sense, right?

        public bool debugMap = false;

        public Building(int mapID, int X, int Y, Dictionary<int, Texture2D> tileCatalogue, Dictionary<int, Texture2D> itemCatalogue, Texture2D debugTex)
        {
            this.masterMapID = mapID;
            this.mapSizeX = X;
            this.mapSizeY = Y;

            this.masterMapArray = new int[mapSizeX, mapSizeY];
            this.masterTiledMapArray = new Tile[mapSizeX, mapSizeY];
            defineFloorTiles();

            this.debugTexture = debugTex;

            Debug.WriteLine("Mapping engine engaged...");

        }

        public bool generateMap()
        {
            Debug.WriteLine("Map generation initiated...");
            streamReader = new StreamReader("TestMap.TXT");
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
