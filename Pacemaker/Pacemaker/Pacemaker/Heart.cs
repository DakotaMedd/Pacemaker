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
    public class Heart : Microsoft.Xna.Framework.DrawableGameComponent
    {
        double LeftPressure;
        double RightPressure;
        public double BodyPressure {get; set;}
        bool LeftLocked;
        bool RightLocked;

        RectangeGraphicSolid LeftHeart;
        RectangeGraphicSolid RightHeart;
        RectangeGraphicSolid Blood;

        private SoundEffect HeartBeat;

        Game Game;

        public Heart(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
            LeftPressure = 15;
            RightPressure = 15;
            BodyPressure = 70;
            LeftLocked = false;
            RightLocked = false;

            LeftHeart = new RectangeGraphicSolid(new Rectangle(0, 0, 30, 50), Color.Blue, game);
            RightHeart = new RectangeGraphicSolid(new Rectangle(0, 0, 30, 50), Color.Red, game);
            Blood = new RectangeGraphicSolid(new Rectangle(0, 0, 30, 50), Color.Green, game);
            HeartBeat = game.Content.Load<SoundEffect>("heartbeat");
            Game = game;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            LeftPressure = 15;
            RightPressure = 15;
            BodyPressure = 70;
            LeftLocked = false;
            RightLocked = false;

            LeftHeart.Initialize();
            RightHeart.Initialize();
            Blood.Initialize();
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {

            BodyPressure -= gameTime.ElapsedGameTime.TotalSeconds * 10.0;
            if (BodyPressure <= 0.0)
                BodyPressure = 0.0;

            LeftHeart.Move(new Point(Game.Camera.X - 100, Game.Camera.Y - 700));
            RightHeart.Move(new Point(Game.Camera.X - 60, Game.Camera.Y - 700));

            // -300 -> 300
            Blood.Move(new Point(Game.Camera.X - 60, (int)((Game.Camera.Y - (720 / 2) + 300) - 600 * (BodyPressure / 100)))); //(int)(Game.Camera.Y - (700.0 * (BodyPressure / 100))))

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (LeftLocked)
                LeftHeart.Draw(gameTime);

            if (RightLocked)
                RightHeart.Draw(gameTime);

            Blood.Draw(gameTime);

            base.Draw(gameTime);
        }

        public void HandleLeftPump()
        {
            LeftPressure += 5;
            if (LeftPressure >= 15)
                LeftPressure = 15;
            HeartBeat.Play(1.0f, 0.0f, -1.0f);

            LeftLocked = true;
        }

        public void HandleLeftRelease()
        {
            LeftLocked = false;
        }

        public void HandleRightPump()
        {
            if (!LeftLocked && LeftPressure >= 5)
            {
                LeftPressure -= 5;
                RightPressure += 5;

                if (LeftPressure <= 0)
                    LeftPressure = 0;

                if (RightPressure >= 15)
                    RightPressure = 15;
            }
            HeartBeat.Play(1.0f, 0.0f, 1.0f);
            RightLocked = true;
        }

        public void HandleRightRelease()
        {
            if (RightPressure >= 5)
            {
                RightPressure -= 5;
                BodyPressure += 5;

                if (RightPressure <= 0)
                    RightPressure = 0;

                if (BodyPressure >= 100.0)
                    BodyPressure = 100.0;
            }
            RightLocked = false;
        }
    }
}
