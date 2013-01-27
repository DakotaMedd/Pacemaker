using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pacemaker.Engine;

namespace Pacemaker.GameSpecific
{
    class Player : WorldPhysicalObject
    {

        private KeyboardState PreviousKeyboardState;
        private MouseState PreviousMouseState;
        private GamePadState PreviousGamePadState;

        private Heart PlayerHeart;
        private WorldSpriteObject LeftHeart;
        private WorldSpriteObject RightHeart;

        bool isGrounded;
        bool canjump;

        List<JumpLocation> jumps;
        private IEnumerable<JumpLocation> currentlocation;
        int index;
        ////////////////////////////////////////////
        bool[] Jump;
        float[] JumpPos;
        float[] JumpForce;

        public Player(Vector2 _WorldPosition, Game _Game, List<JumpLocation> jumps) 
            : base(new Point(64, 128), "Player", _WorldPosition, _Game)
        {
            PreviousKeyboardState = Keyboard.GetState();
            PreviousMouseState = Mouse.GetState();
            PreviousGamePadState = GamePad.GetState(PlayerIndex.One);
            PlayerHeart = new Heart(_Game);

            canjump = true;
            LeftHeart = new WorldSpriteObject("LeftFade", new Vector2(-750.0f, 0.0f), _Game);
            RightHeart = new WorldSpriteObject("RightFade", new Vector2(750.0f, 0.0f), _Game);

            this.jumps = jumps;
            currentlocation = jumps.AsEnumerable<JumpLocation>();
            Reset();
        }

        public override void HandleCollision(Vector2 _Reaction)
        {
            WorldPosition += _Reaction;

            if (_Reaction.Y != 0.0f)
            {
                Velocity.Y = 0.0f;
                isGrounded = true;
                Velocity.X = 5.0f;
            }

            if (_Reaction.X != 0.0f)
                Velocity.X = 0.0f;
        }

        private void Reset()
        {
            PlayerHeart.Reset();
            isGrounded = false;
            WorldPosition.X = 100.0f;
            WorldPosition.Y = 500.0f;
            index = 0;
            /**
            ////////////////////////////////////////////
            Jump = new bool[10];
            JumpForce = new float[10];
            JumpPos = new float[10];

            int Index = 0;

            Index++;
            Jump[Index] = false;
            JumpForce[Index] = 8.0f;
            JumpPos[Index] = 768.0f;

            Index++;
            Jump[Index] = false;
            JumpForce[Index] = 3.0f;
            JumpPos[Index] = 2000.0f;

            Index++;
            Jump[Index] = false;
            JumpForce[Index] = 3.0f;
            JumpPos[Index] = 2600.0f;

            Index++;
            Jump[Index] = true;
            JumpForce[Index] = 0.0f;
            JumpPos[Index] = 0.0f;

            Index++;
            Jump[Index] = true;
            JumpForce[Index] = 0.0f;
            JumpPos[Index] = 0.0f;

            Index++;
            Jump[Index] = true;
            JumpForce[Index] = 0.0f;
            JumpPos[Index] = 0.0f;

            Index++;
            Jump[Index] = true;
            JumpForce[Index] = 0.0f;
            JumpPos[Index] = 0.0f;

            Index++;
            Jump[Index] = true;
            JumpForce[Index] = 0.0f;
            JumpPos[Index] = 0.0f;

            Index++;
            Jump[Index] = true;
            JumpForce[Index] = 0.0f;
            JumpPos[Index] = 0.0f;
            **/
        }

        public override void Update(GameTime _GameTime)
        {
            PlayerHeart.Update(_GameTime);

            // Gravity
            if(!isGrounded)
                Velocity.Y -= 4f * (float)_GameTime.ElapsedGameTime.TotalSeconds;

            UpdateInput();

            base.Update(_GameTime);

            GameInstance.Camera.X = (int)WorldPosition.X;
            GameInstance.Camera.Y = (int)WorldPosition.Y;

            isGrounded = false;

            ///////////////////////////////////////////////////////
            if (canjump && WorldPosition.X > jumps.ElementAt(index).position.X - 10.0f && WorldPosition.X < jumps.ElementAt(index).position.X + 10.0f)
                {
                    Velocity.Y = jumps.ElementAt(index).velocity * (float)(PlayerHeart.BodyPressure / 100.0);
                    jumps.ElementAt(index++).jumped = true;
                }
            if (index == jumps.Count)
                canjump = false;
            ////////////////////////////////////////////////////////

            if (WorldPosition.Y <= -1000.0f)
            {
                Reset();
            }
        }

        public override void Draw(GameTime _GameTime)
        {
            if (PlayerHeart.IsLeftLocked)
            {
                LeftHeart.WorldPosition.X = WorldPosition.X - 750.0f;
                LeftHeart.WorldPosition.Y = GameInstance.Camera.Y;
                LeftHeart.Draw(_GameTime);
            }

            if (PlayerHeart.IsRightLocked)
            {
                RightHeart.WorldPosition.X = WorldPosition.X + 750.0f;
                RightHeart.WorldPosition.Y = GameInstance.Camera.Y;
                RightHeart.Draw(_GameTime);
            }

            base.Draw(_GameTime);
        }

        private void UpdateInput()
        {
            // Get Current States
            KeyboardState CurrentKeyboardState = Keyboard.GetState();
            MouseState CurrentMouseState = Mouse.GetState();
            GamePadState CurrentGamePadState = GamePad.GetState(PlayerIndex.One);

            // [KeyBoard]   Caps Lock       / Enter
            // [KeyBoard]   Left Shift      / Right Shift
            // [KeyBoard]   Left Ctrl       / Right Ctrl 
            // [KeyBoard]   Left Alt        / Right Alt
            // [KeyBoard]   Left Arrow      / Right Arrow
            // [Mouse]      Left Button     / Right Button
            // [X360]       Left Tigger     / Right Tigger
            // [X360]       Left Shoulder   / Right Shoulder

            if ((CurrentKeyboardState.IsKeyDown(Keys.CapsLock) && PreviousKeyboardState.IsKeyUp(Keys.CapsLock))
                || (CurrentKeyboardState.IsKeyDown(Keys.LeftShift) && PreviousKeyboardState.IsKeyUp(Keys.LeftShift))
                || (CurrentKeyboardState.IsKeyDown(Keys.LeftControl) && PreviousKeyboardState.IsKeyUp(Keys.LeftControl))
                || (CurrentKeyboardState.IsKeyDown(Keys.LeftAlt) && PreviousKeyboardState.IsKeyUp(Keys.LeftAlt))
                || (CurrentKeyboardState.IsKeyDown(Keys.Left) && PreviousKeyboardState.IsKeyUp(Keys.Left))

                //|| (CurrentMouseState.LeftButton == ButtonState.Pressed && PreviousMouseState.LeftButton == ButtonState.Released)

                || (CurrentGamePadState.IsConnected && (CurrentGamePadState.IsButtonDown(Buttons.LeftTrigger) && PreviousGamePadState.IsButtonUp(Buttons.LeftTrigger)))
                || (CurrentGamePadState.IsConnected && (CurrentGamePadState.IsButtonDown(Buttons.LeftShoulder) && PreviousGamePadState.IsButtonUp(Buttons.LeftShoulder)))
                )
            {
                PlayerHeart.HandleLeftPump();
            }

            if ((CurrentKeyboardState.IsKeyDown(Keys.Enter) && PreviousKeyboardState.IsKeyUp(Keys.Enter))
                || (CurrentKeyboardState.IsKeyDown(Keys.RightShift) && PreviousKeyboardState.IsKeyUp(Keys.RightShift))
                || (CurrentKeyboardState.IsKeyDown(Keys.RightControl) && PreviousKeyboardState.IsKeyUp(Keys.RightControl))
                || (CurrentKeyboardState.IsKeyDown(Keys.RightAlt) && PreviousKeyboardState.IsKeyUp(Keys.RightAlt))
                || (CurrentKeyboardState.IsKeyDown(Keys.Right) && PreviousKeyboardState.IsKeyUp(Keys.Right))

                //|| (CurrentMouseState.RightButton == ButtonState.Pressed && PreviousMouseState.RightButton == ButtonState.Released)

                || (CurrentGamePadState.IsConnected && (CurrentGamePadState.IsButtonDown(Buttons.RightTrigger) && PreviousGamePadState.IsButtonUp(Buttons.RightTrigger)))
                || (CurrentGamePadState.IsConnected && (CurrentGamePadState.IsButtonDown(Buttons.RightShoulder) && PreviousGamePadState.IsButtonUp(Buttons.RightShoulder)))
                )
            {
                PlayerHeart.HandleRightPump();
            }

            if ((CurrentKeyboardState.IsKeyUp(Keys.CapsLock) && PreviousKeyboardState.IsKeyDown(Keys.CapsLock))
                || (CurrentKeyboardState.IsKeyUp(Keys.LeftShift) && PreviousKeyboardState.IsKeyDown(Keys.LeftShift))
                || (CurrentKeyboardState.IsKeyUp(Keys.LeftControl) && PreviousKeyboardState.IsKeyDown(Keys.LeftControl))
                || (CurrentKeyboardState.IsKeyUp(Keys.LeftAlt) && PreviousKeyboardState.IsKeyDown(Keys.LeftAlt))
                || (CurrentKeyboardState.IsKeyUp(Keys.Left) && PreviousKeyboardState.IsKeyDown(Keys.Left))

                //|| (CurrentMouseState.LeftButton == ButtonState.Released && PreviousMouseState.LeftButton == ButtonState.Pressed)

                || (CurrentGamePadState.IsConnected && (CurrentGamePadState.IsButtonUp(Buttons.LeftTrigger) && PreviousGamePadState.IsButtonDown(Buttons.LeftTrigger)))
                || (CurrentGamePadState.IsConnected && (CurrentGamePadState.IsButtonUp(Buttons.LeftShoulder) && PreviousGamePadState.IsButtonDown(Buttons.LeftShoulder)))
                )
            {
                PlayerHeart.HandleLeftRelease();
            }

            if ((CurrentKeyboardState.IsKeyUp(Keys.Enter) && PreviousKeyboardState.IsKeyDown(Keys.Enter))
                || (CurrentKeyboardState.IsKeyUp(Keys.RightShift) && PreviousKeyboardState.IsKeyDown(Keys.RightShift))
                || (CurrentKeyboardState.IsKeyUp(Keys.RightControl) && PreviousKeyboardState.IsKeyDown(Keys.RightControl))
                || (CurrentKeyboardState.IsKeyUp(Keys.RightAlt) && PreviousKeyboardState.IsKeyDown(Keys.RightAlt))
                || (CurrentKeyboardState.IsKeyUp(Keys.Right) && PreviousKeyboardState.IsKeyDown(Keys.Right))

                //|| (CurrentMouseState.RightButton == ButtonState.Released && PreviousMouseState.RightButton == ButtonState.Pressed)

                || (CurrentGamePadState.IsConnected && (CurrentGamePadState.IsButtonUp(Buttons.RightTrigger) && PreviousGamePadState.IsButtonDown(Buttons.RightTrigger)))
                || (CurrentGamePadState.IsConnected && (CurrentGamePadState.IsButtonUp(Buttons.RightShoulder) && PreviousGamePadState.IsButtonDown(Buttons.RightShoulder)))
                )
            {
                PlayerHeart.HandleRightRelease();
            }

            // Set Previous State
            PreviousKeyboardState = CurrentKeyboardState;
        }
    }
}
