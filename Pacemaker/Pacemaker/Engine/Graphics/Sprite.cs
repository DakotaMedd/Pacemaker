using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pacemaker.Engine.Graphics
{
    class Sprite
    {
        Texture2D SpriteAsset;
        protected Game GameInstance;
#if DEBUG
        RectangleSprite Debug_View;
#endif

        public Sprite(String _TextureName, Game _Game)
        {
            GameInstance = _Game;
            SpriteAsset = GameInstance.Content.Load<Texture2D>(_TextureName);

#if DEBUG
            Debug_View = new RectangleSprite(_Game);
#endif
        }

        public void Draw(GameTime _GameTime, Vector2 WorldPosition)
        {
            Draw(_GameTime, WorldPosition, Color.White);
        }

        public void Draw(GameTime _GameTime, Vector2 WorldPosition, Color _Color)
        {
            Vector2 FinalPosition = new Vector2();
            FinalPosition.X = WorldPosition.X - (SpriteAsset.Bounds.Width / 2) + (1280 / 2) - GameInstance.Camera.X;
            FinalPosition.Y = WorldPosition.Y * -1 - (SpriteAsset.Bounds.Height / 2) + (720 / 2) - GameInstance.Camera.Y * -1;

            GameInstance.SpriteBatch.Draw(SpriteAsset, FinalPosition, _Color);

#if DEBUG
            Debug_View.Draw(_GameTime, WorldPosition, new Point(SpriteAsset.Bounds.Width, SpriteAsset.Bounds.Height) , 4, Color.Blue);
#endif
        }
    }
}
