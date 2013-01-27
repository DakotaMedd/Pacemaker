using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacemaker
{
    class Input : Microsoft.Xna.Framework.GameComponent
    {
        private KeyboardState PreviousKeyboardState;
        private MouseState PreviousMouseState;
        private GamePadState PreviousGamePadState;
        Game Game;

        public Input(Game _Game)
            : base(_Game)
        {
            Game = _Game;
        }

        public override void Initialize()
        {
            base.Initialize();

            PreviousKeyboardState = Keyboard.GetState();
            PreviousMouseState = Mouse.GetState();
            PreviousGamePadState = GamePad.GetState(PlayerIndex.One);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);

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
                // TODO:: Event Left Pressed
                Game.Heart.HandleLeftPump();
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
                // TODO:: Event Right Pressed
                Game.Heart.HandleRightPump();
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
                // TODO:: Event Left Release
                Game.Heart.HandleLeftRelease();
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
                // TODO:: Event Right Release
                Game.Heart.HandleRightRelease();
            }

            if (CurrentKeyboardState.IsKeyDown(Keys.D))
            {
                Game.PlayerOne.moveRight(Game.ObjectManager.getCollisionObjects());
            }
            // Set Previous State
            PreviousKeyboardState = CurrentKeyboardState;
        }
    }
}
