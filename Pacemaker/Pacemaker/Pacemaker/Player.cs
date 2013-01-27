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
    public class Player : PacemakerComponent
    {
        Point Position;
        DebugRect View;
        DebugRect Physics;
        int width;
        int height;

        Game game;
        public Player(Game game, Rectangle bounds)
            : base(game, bounds)
        {
            Position = new Point(bounds.X, bounds.Y);
            width = bounds.Width;
            height = bounds.Height;
            View = new DebugRect(Position, new Point(0, 0), width, height, DebugRect.DebugType.View, game);
            Physics = new DebugRect(Position, new Point(0, 0), width, height, DebugRect.DebugType.Physics, game);
            this.game = game;
        }

        public override void Initialize()
        {
            View.Initialize();
            Physics.Initialize();
            base.Initialize();
        }

        public void moveRight(List<PhysicsComponent> p)
        {
            int velocity = (int)Math.Round((decimal)(3*(game.Heart.BodyPressure/100)));
            bool collision = false;
            PhysicsComponent core = new PhysicsComponent(base.p);
            core.Update(base.boundingRec.X + velocity, base.boundingRec.Y);
            foreach (PhysicsComponent f in p)
            {
                collision = core.checkColliding(f);
                if (collision)
                        return;
            }
            Position.X = Position.X + velocity;
            UpdateCollision(new Rectangle(base.boundingRec.X + velocity, base.boundingRec.Y, base.boundingRec.Width, base.boundingRec.Height));

        }

        public override void Update(GameTime gameTime)
        {
            View.Move(Position);
            Physics.Move(Position);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            View.Draw(gameTime);
            Physics.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
