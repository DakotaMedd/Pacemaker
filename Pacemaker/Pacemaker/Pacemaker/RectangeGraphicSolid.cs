using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Pacemaker
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class RectangeGraphicSolid : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Game Game;
        Texture2D Pixel;

        public Rectangle Rectangle;
        public Color Color;

        public RectangeGraphicSolid(Rectangle _Rectangle, Color _Color, Game _Game)
            : base(_Game)
        {
            Color = _Color;
            Rectangle = _Rectangle;
            Game = _Game;
        }

        protected override void LoadContent()
        {
            Pixel = new Texture2D(Game.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            Pixel.SetData(new[] { Color.White });

            base.LoadContent();
        }

        public override void Initialize()
        {
            LoadContent();

            base.Initialize();
        }

        public void Move(Point _Point)
        {
            Rectangle.X = _Point.X;
            Rectangle.Y = _Point.Y;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.SpriteBatch.Draw(Pixel, new Rectangle(Rectangle.X + Game.Camera.X, Rectangle.Y + Game.Camera.Y, Rectangle.Width, Rectangle.Height), Color);
            base.Draw(gameTime);
        }
    }
}
