using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Pacemaker.Engine.Physics;

namespace Pacemaker.Engine
{
    public class ObjectManager : Object, IDrawable
    {
        List<IObject> GameObjects;

        public ObjectManager(Game _Game)
            : base(_Game)
        {
            GameObjects = new List<IObject>();
        }

        public override void Initialize()
        {
            GameObjects = new List<IObject>();
            base.Initialize();
        }

        public void Register(IObject _Object)
        {
            GameObjects.Add(_Object);
        }

        public void Unregister(IObject _Object)
        {
            GameObjects.Remove(_Object);
        }

        public override void Update(GameTime _GameTime)
        {
            foreach (IUpdateable Object in GameObjects)
            {
                if (Object != null)
                    Object.Update(_GameTime);
            }

            // TODO:: Add Collision Checking
            foreach (IObject ObjectA in GameObjects)
            {
                if (ObjectA is IPhysical)
                {
                    foreach (IObject ObjectB in GameObjects)
                    {
                        if (ObjectB is IPhysical)
                        {
                            if (ObjectA != ObjectB)
                            {
                                Vector2 Reaction = Collision.CheckCollision(((IPhysical)ObjectA).GetCollisionVolume(), ((IPhysical)ObjectB).GetCollisionVolume());
                                if (!(Reaction.X == 0.0f && Reaction.Y == 0.0f))
                                    ((IPhysical)ObjectA).HandleCollision(Reaction);
                            }
                        }
                    }
                }
            }

            base.Update(_GameTime);
        }

        public void Draw(GameTime _GameTime)
        {
            foreach (IDrawable Object in GameObjects)
            {
                if (Object != null)
                    Object.Draw(_GameTime);
            }
        }
    }
}
