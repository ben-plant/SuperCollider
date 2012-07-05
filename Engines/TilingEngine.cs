using SuperCollider;

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
    class TilingEngine
    {
        public Tile[,] tileMap(int[,] thisMap)
        {
            Tile[,] tiledMap = new Tile[thisMap.GetUpperBound(0), thisMap.GetUpperBound(1)];
            Rectangle tileTemplate = new Rectangle(0, 0, (int)GlobalDictionaries.standardTileSize.X, (int)GlobalDictionaries.standardTileSize.Y);

            for (int controlVar1 = 0; controlVar1 <= thisMap.GetUpperBound(0); controlVar1++)
            {
                for (int controlVar2 = 0; controlVar2 <= thisMap.GetUpperBound(1); controlVar2++)
                {
                    int tileTextureID = thisMap[controlVar1, controlVar2];
                    bool? isTileOpaque = null;
                    if (!GlobalDictionaries.tilesYouCanWalkOn.Contains(tileTextureID))
                    {
                        isTileOpaque = true;
                    }
                    else
                    {
                        isTileOpaque = false;
                    }
                    Tile tempTile = new Tile(tileTemplate, tileTextureID, isTileOpaque);
                    tiledMap[controlVar1, controlVar2] = tempTile;
                    tileTemplate.X += 32;
                    Debug.WriteLine("Tile value " + tileTextureID + " loaded at " + tileTemplate.X + ", " + tileTemplate.Y + ".");
                }
                tileTemplate.X = 0;
                tileTemplate.Y += 32;
            }
            return tiledMap;
        }
    }
}
