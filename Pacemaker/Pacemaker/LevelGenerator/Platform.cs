using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace Pacemaker.LevelGenerator
{
    public class Platform
    {
        public int startLocation { get; set; }
        public Point size {get; set;}
        public int height { get; set; }
        public string texture {get; set;}

        public int spaceToNext;
        public Platform next;

        public Platform(int offset_width, int offset_height, string texture, Point size)
        {
            startLocation = offset_width;
            height = offset_height;
            this.texture = texture;
            this.size = size;
        }
    }
}
