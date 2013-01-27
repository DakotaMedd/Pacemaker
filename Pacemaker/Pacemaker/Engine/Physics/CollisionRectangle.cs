using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacemaker.Engine.Physics
{
    class CollisionRectangle
    {
        public Point RectangleSize;

        public CollisionRectangle(Point _CollsionVolumeSize)
        {
            RectangleSize = _CollsionVolumeSize;
        }

        public Rectangle GetCollisionVolume(Vector2 _WorldPosition)
        {
            return new Rectangle((int)_WorldPosition.X - (RectangleSize.X / 2), (int)_WorldPosition.Y - (RectangleSize.Y / 2), RectangleSize.X, RectangleSize.Y);
        }
    }
}
