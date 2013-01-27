using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pacemaker.Engine.Graphics
{
    class RectangleSprite
    {
        Texture2D SpriteAsset;
        protected Game GameInstance;

        public RectangleSprite(Game _Game)
        {
            GameInstance = _Game;
            SpriteAsset = new Texture2D(GameInstance.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            SpriteAsset.SetData(new[] { Color.White });
        }

        public void Draw(GameTime _GameTime, Vector2 _WorldPosition, Point _RectangleSize, int _BorderThinkness, Color _Color)
        {
            Vector2 FinalPosition = new Vector2();
            FinalPosition.X = _WorldPosition.X - (_RectangleSize.X / 2) + (1280 / 2) - GameInstance.Camera.X;
            FinalPosition.Y = _WorldPosition.Y * -1 - (_RectangleSize.Y / 2) + (720 / 2) - GameInstance.Camera.Y * -1;


            GameInstance.SpriteBatch.Draw(SpriteAsset, new Rectangle((int)FinalPosition.X, (int)FinalPosition.Y, _RectangleSize.X, _BorderThinkness), _Color);

            GameInstance.SpriteBatch.Draw(SpriteAsset, new Rectangle((int)FinalPosition.X, (int)FinalPosition.Y, _BorderThinkness, _RectangleSize.Y), _Color);

            GameInstance.SpriteBatch.Draw(SpriteAsset, new Rectangle(((int)FinalPosition.X + _RectangleSize.X - _BorderThinkness),
                                            (int)FinalPosition.Y,
                                            _BorderThinkness,
                                            _RectangleSize.Y), _Color);

            GameInstance.SpriteBatch.Draw(SpriteAsset, new Rectangle((int)FinalPosition.X,
                                            (int)FinalPosition.Y + _RectangleSize.Y - _BorderThinkness,
                                            _RectangleSize.X,
                                            _BorderThinkness), _Color);
        }

        public void Draw(GameTime _GameTime, Vector2 _WorldPosition, Point _RectangleSize, Color _Color)
        {
            Vector2 FinalPosition = new Vector2();
            FinalPosition.X = _WorldPosition.X - (_RectangleSize.X / 2) + (1280 / 2) - GameInstance.Camera.X;
            FinalPosition.Y = _WorldPosition.Y * -1 - (_RectangleSize.Y / 2) + (720 / 2) - GameInstance.Camera.Y * -1;

            GameInstance.SpriteBatch.Draw(SpriteAsset, new Rectangle((int)FinalPosition.X, (int)FinalPosition.Y, _RectangleSize.X, _RectangleSize.Y), _Color);
        }
    }
}
