using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Pacemaker.Engine;

namespace Pacemaker.GameSpecific
{
    class BackgroundSection : WorldSpriteObject
    {
        Vector2 OriPos;

        public BackgroundSection(String _TextureName, Vector2 _WorldPosition, Game _Game)
            : base(_TextureName, _WorldPosition, _Game)
        {
            OriPos = _WorldPosition;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime _GameTime)
        {
            if (WorldPosition.X + 512.0f < GameInstance.Camera.X - 640.0f)
            {
                WorldPosition.X += 1024.0f * 3.0f;
            }

            // Reset Case
            if (GameInstance.Camera.X + 640.0f < WorldPosition.X - 1024.0f)
            {
                WorldPosition = OriPos;
            }

            base.Update(_GameTime);
        }

        public override void Draw(GameTime _GameTime)
        {
            base.Draw(_GameTime);
        }
    }
}
