using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacemaker.Engine.Physics
{
    class Collision
    {
        // TODO:: Write Real Collision Code
        // Note: Makes for forgiving Game
        public static Vector2 CheckCollision(Rectangle _A, Rectangle _B)
        {
            Rectangle IntersectRect = Rectangle.Intersect(_A, _B);

            if (IntersectRect.Width != 0.0f || IntersectRect.Height != 0.0f)
            {
                if (IntersectRect.Width < IntersectRect.Height) // Less X
                {
                    if(_A.X < _B.X)
                        return new Vector2(-IntersectRect.Width, 0.0f);
                    else if (_A.X > _B.X)
                        return new Vector2(IntersectRect.Width, 0.0f);
                }
                else if (IntersectRect.Height < IntersectRect.Width)// Less Y
                {
                    if(_A.Y > _B.Y)
                        return new Vector2(0.0f, IntersectRect.Height);
                    else if (_A.Y < _B.Y)
                        return new Vector2(0.0f, -IntersectRect.Height);
                }
            }

            return new Vector2(0.0f, 0.0f);
        }
    }
}
