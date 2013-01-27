using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacemaker
{
    public class PacemakerComponent : DrawableGameComponent
    {
        protected Rectangle boundingRec;
        private Game game;
        protected PhysicsComponent p;

        public PacemakerComponent(Game game, Rectangle bounds) : base(game)
        {
            this.game = game;
            boundingRec = bounds;
            p = new PhysicsComponent(game, bounds);
        }

        public PhysicsComponent getCollisonObject() 
        {
            return p;
        }

        public void UpdateCollision(Rectangle c)
        {
            p.Update(c.X, c.Y);
            boundingRec = c;
        }
    }
}
