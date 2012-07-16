using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

using SuperCollider.Engines;
using SuperCollider.CityComponents;
using SuperCollider.Sprites.NonPlayable;

namespace SuperCollider
{
    public static class GlobalDictionaries
    {
        public static bool debugGameEngine = true;

        #region Miscellaneous

        public static List<Sprite> masterSpriteCatalogue = new List<Sprite>();

        public static FileParsingEngine fileParser = new FileParsingEngine();
        public static TextureEngine texLoader;
        public static RenderingEngine renderEngine;

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

        #region Rendering

        public static SpriteBatch engineSpriteBatch
        {
            get
            {
                return engineSpriteBatch;
            }
            set
            {
                engineSpriteBatch = value;
            }
        }
        #endregion
    }
}
