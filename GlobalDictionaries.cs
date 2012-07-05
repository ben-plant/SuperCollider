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
        public static int itemsOnMap = 0;
        public static Building[,] masterCityMap;

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
    }
}
