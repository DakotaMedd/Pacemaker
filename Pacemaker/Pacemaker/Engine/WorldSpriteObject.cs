using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Pacemaker.Engine.Graphics;

namespace Pacemaker.Engine
{
    class WorldSpriteObject : WorldObject, IDrawable
    {
        public Sprite SpriteInstance;

        public WorldSpriteObject(String _TextureName, Vector2 _WorldPosition, Game _Game)
            : base(_WorldPosition, _Game)
        {
            SpriteInstance = new Sprite(_TextureName, _Game);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime _GameTime)
        {
            base.Update(_GameTime);
        }

        public virtual void Draw(GameTime _GameTime)
        {
            SpriteInstance.Draw(_GameTime, WorldPosition);
        }
    }
}
