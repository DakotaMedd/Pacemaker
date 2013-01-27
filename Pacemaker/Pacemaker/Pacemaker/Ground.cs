using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacemaker
{
    class Ground : PacemakerComponent
    {
        RectangeGraphicSolid Graphic;
        DebugRect Physics;
        Point Position;
        int width;
        int height;

        public Ground(Point _Position, Rectangle bounds, Game _Game)
            : base(_Game, bounds)
        {
            width = 500;
            height = 200;
            Position = _Position;
            Graphic = new RectangeGraphicSolid(new Rectangle(0, 0, width, height), Color.Black, _Game);

            Physics = new DebugRect(Position, new Point(0, 0), width, height, DebugRect.DebugType.Physics, _Game);
        }

        public override void Initialize()
        {
            Graphic.Initialize();
            Physics.Initialize();
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            Graphic.Move(Position);
            Physics.Move(Position);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Graphic.Draw(gameTime);
            Physics.Draw(gameTime);
            base.Draw(gameTime);
        }

        public Rectangle getBounds()
        {
            return new Rectangle(Position.X, Position.Y, width, height);
        }
    }
}
