using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCollider
{
    class City
    {
        public void generateCity(string filename)
        {
            fileParser = new FileParsingEngine("Cities", filename);
        }
    }
}
