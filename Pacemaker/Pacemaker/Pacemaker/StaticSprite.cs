using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pacemaker
{
    class StaticSprite : DrawableGameComponent
    {
        String TextureName;
        Game game;
        Texture2D Texture;
        Rectangle Dest;

        public StaticSprite(Game _Game, Rectangle _Dest, String _szTexture)
            : base(_Game)
        {
            TextureName = _szTexture;
            Dest = _Dest;
            game = _Game;
        }

        public override void Initialize()
        {
            Texture = game.Content.Load<Texture2D>(TextureName);

            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            game.SpriteBatch.Draw(Texture, Dest, Color.White);
            base.Draw(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
