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
    public static class GlobalDictionaries
    {
        #region Miscellaneous

        public static FileParsingEngine fileParser;
        public static TextureEngine texLoader;

        public static bool debugGameEngine = true;
        public static int itemsOnMap = 0;

        public static City mainCity
        {
            get
            {
                return mainCity;
            }
            set
            {
                mainCity = value;
            }
        }

        public static Building[,] masterCityMap
        {
            get
            {
                return masterCityMap;
            }
            set
            {
                masterCityMap = value;
            }
        }

        public static Texture2D debugTexture
        {
            get
            {
                return debugTexture;
            }
            set
            {
                debugTexture = value;
            }
        }

        #endregion

        #region TilingEngine

        public static Dictionary<int, Texture2D> masterItemCatalogue
        {
            get
            {
                return masterItemCatalogue;
            }
            set
            {
                masterItemCatalogue = value;
            }
        }

        public static Dictionary<int, Texture2D> masterTileCatalogue
        {
            get
            {
                return masterTileCatalogue;
            }
            set
            {
                masterTileCatalogue = value;
            }
        }

        public static List<int> tilesYouCanWalkOn
        {
            get
            {
                return tilesYouCanWalkOn;
            }
            set
            {
                tilesYouCanWalkOn = value;
            }
        }

        public static Vector2 standardTileSize
        {
            get
            {
                return standardTileSize;
            }
            set
            {
                standardTileSize = value;
            }
        }

        public static Vector2 standardItemSize
        {
            get
            {
                return standardItemSize;
            }
            set
            {
                standardItemSize = value;
            }
        }

        #endregion
    }
}
