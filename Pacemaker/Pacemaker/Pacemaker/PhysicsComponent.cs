using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pacemaker
{
    public class PhysicsComponent
    {
        private static int totalID = 0;
        public int id { get; set;}
        private Rectangle bounds;
        private Rectangle previousBounds;
        private Game game;

        public PhysicsComponent(Game game, int x, int y, int width, int height) : this(game, new Rectangle(x,y,width,height))
        {
        }

        public PhysicsComponent(Game game, Rectangle rec)
        {
            id = totalID++;
            bounds = new Rectangle(rec.X,rec.Y,rec.Width,rec.Height);
            this.game = game;
        }

        /**
         * Just copies a class
         **/
        public PhysicsComponent(PhysicsComponent rec) : this(rec.game, rec.bounds)
        {
            this.id = rec.id;
            totalID--;
        }

        /**
         * Returns true if the PhysicsComponents are the same
         **/
        public bool checkColliding(PhysicsComponent p) 
        {
            if (p.id != id)
            {
                return bounds.Intersects(p.bounds);
            }
            return false;
        }

        public void Update(int x, int y)
        {
            previousBounds = bounds;
            bounds = new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height);
            bounds.X = x;
            bounds.Y = y;

        }

        public void rollBack()
        {
            bounds = new Rectangle(previousBounds.X, previousBounds.Y, previousBounds.Width, previousBounds.Height);
        }
    }
}
