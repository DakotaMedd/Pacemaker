using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Pacemaker.Engine.Graphics;
using Pacemaker.Engine.Physics;

namespace Pacemaker.Engine
{
    class WorldPhysicalObject : WorldSpriteObject, IPhysical
    {
        CollisionRectangle CollisionVolume;
        protected Vector2 Velocity;
#if DEBUG
        RectangleSprite Debug_Physics;
#endif

        public WorldPhysicalObject(Point _CollisionVolumeSize, String _TextureName, Vector2 _WorldPosition, Game _Game)
            : base(_TextureName, _WorldPosition, _Game)
        {
            Velocity = new Vector2(0.0f, 0.0f);
            CollisionVolume = new CollisionRectangle(_CollisionVolumeSize);

#if DEBUG
            Debug_Physics = new RectangleSprite(_Game);
#endif
        }

        public Rectangle GetCollisionVolume()
        {
            return CollisionVolume.GetCollisionVolume(WorldPosition);
        }

        public virtual void HandleCollision(Vector2 _Reaction)
        {
            
        }

        public override void Update(GameTime _GameTime)
        {
            WorldPosition.X += Velocity.X;
            WorldPosition.Y += Velocity.Y;

            base.Update(_GameTime);
        }

        public override void Draw(GameTime _GameTime)
        {
            base.Draw(_GameTime);
#if DEBUG
            Debug_Physics.Draw(_GameTime, WorldPosition, CollisionVolume.RectangleSize, 2, Color.White);
#endif

        }
    }
}
