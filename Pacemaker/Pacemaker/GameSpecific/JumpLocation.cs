using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace Pacemaker.GameSpecific
{
    public class JumpLocation
    {
        public Point position;
        public bool jumped;
        public int velocity;

        public JumpLocation(Point position, int velocity)
        {
            this.position = position;
            this.velocity = velocity;
        }

        public JumpLocation(Point position)
            : this(position, 0)
        {
        }
    }
}
