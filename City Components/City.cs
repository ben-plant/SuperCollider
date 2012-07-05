﻿using SuperCollider;
using SuperCollider.Engines;
using SuperCollider.Objects;
using SuperCollider.CityComponents;

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


namespace SuperCollider.CityComponents
{
    public class City
    {
        public void generateCity(string filename)
        {
            fileParser = new FileParsingEngine("Cities", filename);
        }
    }
}
