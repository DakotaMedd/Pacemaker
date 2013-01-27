using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Pacemaker.GameSpecific
{
    class Heart : Pacemaker.Engine.Object, Pacemaker.Engine.IUpdateable, Pacemaker.Engine.IDrawable
    {
        public bool HasLeftPressure;
        public bool HasRightPressure;
        public bool IsLeftLocked;
        public bool IsRightLocked;
        public double BodyPressure;
        double Velocity;

        private SoundEffect HeartBeat;

        public Heart(Game _Game) 
            : base(_Game)
        {
            HeartBeat = GameInstance.Content.Load<SoundEffect>("heartbeat");

            Reset();
        }

        public void Reset()
        {
            HasLeftPressure = false;
            HasRightPressure = false;
            IsLeftLocked = false;
            IsRightLocked = false;

            BodyPressure = 80.0;
            Velocity = 0.0;
        }

        public override void Update(GameTime _GameTime)
        {
            Velocity -= _GameTime.ElapsedGameTime.TotalSeconds * 25.0;
            Velocity -= BodyPressure * _GameTime.ElapsedGameTime.TotalSeconds * 0.25;
            BodyPressure += Velocity * _GameTime.ElapsedGameTime.TotalSeconds;

            if (BodyPressure > 100.0)
                BodyPressure = 100.0;

            if (BodyPressure < 0)
                BodyPressure = 0;

            if (Velocity > 25.0)
                Velocity = 25.0;

            if (Velocity < -25.0)
                Velocity = -25.0;
#if DEBUG
            GameInstance.Camera.Y = 0;
#else
             GameInstance.Camera.Y = (int)( ((BodyPressure - 50.0) / 70) * 720);
#endif

            base.Update(_GameTime);
        }

        public void Draw(GameTime gameTime)
        {
            
        }

        public void HandleLeftPump()
        {
            HasLeftPressure = true;
            IsLeftLocked = true;
            HeartBeat.Play(1.0f, 0.0f, -1.0f);
        }

        public void HandleLeftRelease()
        {
            IsLeftLocked = false;
        }

        public void HandleRightPump()
        {
            if (!IsLeftLocked && HasLeftPressure)
            {
                HasLeftPressure = false;
                HasRightPressure = true;
            }
            HeartBeat.Play(1.0f, 0.0f, 1.0f);
            IsRightLocked = true;
        }

        public void HandleRightRelease()
        {
            if (HasRightPressure)
            {
                HasRightPressure = false;
                Velocity += (100 - BodyPressure) * 0.5;
            }
            IsRightLocked = false;
        }
    }
}
