/**************************************************
 * SuperCollider Game Engine 2012                 *
 *                                                *
 * Written by Benjamin Plant for private use only *
 * Restricted build: not for production use!      *
 **************************************************/

using SuperCollider.CityComponents;

using System.Diagnostics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace SuperCollider.Engines
{
    public class MapEngine
    {
        /* Manages the map as a whole, spawning and initializing buildings according to a master plan.
         * Each building then spawns its own Room() groups according to its own text file, which it is
         * designated by this class.
         */

        public MapEngine(ContentManager Content, SpriteBatch spriteBatch, string cityName)
        {
            Debug.WriteLine("SuperCollider Game Engine - (C) Benjamin Plant 2012" + "\n" + "SuperCollider online...");

            Debug.WriteLine("Loading global objects...");
            GlobalDictionaries.texLoader = new TextureEngine(Content);
            GlobalDictionaries.engineSpriteBatch = spriteBatch;

            Debug.WriteLine("Texture engine engaged...");
            GlobalDictionaries.masterItemCatalogue = GlobalDictionaries.texLoader.loadItemsIntoMemory("Items");
            GlobalDictionaries.masterTileCatalogue = GlobalDictionaries.texLoader.loadTilesIntoMemory("Tiles");
            
            Debug.WriteLine("Tiles and items loaded successfully." + "/n" + "Beginning city generation...");
            GlobalDictionaries.mainCity = new City(cityName);
        }
    }
}
