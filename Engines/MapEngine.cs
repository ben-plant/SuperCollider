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
    public class MapEngine
    {
        /* Manages the map as a whole, spawning and initializing buildings according to a master plan.
         * Each building then spawns its own Room() groups according to its own text file, which it is
         * designated by this class.
         */

        public MapEngine(ContentManager Content, string cityName)
        {
            GlobalDictionaries.texLoader = new TextureEngine(Content);
            Debug.WriteLine("Texture engine engaged...");
            GlobalDictionaries.masterItemCatalogue = GlobalDictionaries.texLoader.loadItemsIntoMemory("Items");
            GlobalDictionaries.masterTileCatalogue = GlobalDictionaries.texLoader.loadTilesIntoMemory("Tiles");
            
            Debug.WriteLine("Tiles and items loaded successfully." + "/n" + "Beginning city generation...");
            GlobalDictionaries.mainCity = new City();
        }
    }
}
