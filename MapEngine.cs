using SuperCollider;
using SuperCollider.GlobalDictionaries;

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

namespace SuperCollider
{
    public class MapEngine
    {
        /* Manages the map as a whole, spawning and initializing buildings according to a master plan.
         * Each building then spawns its own Room() groups according to its own text file, which it is
         * designated by this class.
         */

        StreamReader streamReader;
        StringBuilder stringBuilder;
        FileParser fileParser;
        TextureLoader texLoader;
        
        public Building[,] masterMapArray;        

        public bool debugMap = false;
        private Texture2D debugTexture;

        public MapEngine(ContentManager Content, string cityName)
        {
            this.debugTexture = Content.Load<Texture2D>("debugTex");

            texLoader = new TextureLoader(Content);
            Debug.WriteLine("Texture engine engaged...");
            GlobalDictionaries.masterItemCatalogue = texLoader.loadItemsIntoMemory("Items");
            GlobalDictionaries.masterTileCatalogue = texLoader.loadTilesIntoMemory("Tiles");
            
            Debug.WriteLine("Tiles and items loaded successfully." + "/n" + "Beginning city generation...");

            this.generateCity(cityName);
        }

        public void generateCity(string filename)
        {
            fileParser = new FileParser("Cities", filename);
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

        public void LoadTiles(ContentManager Content)
        {
        }

        public void LoadItems(ContentManager Content)
        {
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


    }
}
