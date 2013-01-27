using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacemaker.Engine
{
    class WorldObject : Object
    {
        public Vector2 WorldPosition;

        public WorldObject(Vector2 _WorldPosition, Game _Game)
            : base(_Game)
        {
            WorldPosition = _WorldPosition;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime _GameTime)
        {
            base.Update(_GameTime);
        }
    }
}
