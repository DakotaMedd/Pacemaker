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
    /// This is the main type for your game
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager Graphics;
        public SpriteBatch SpriteBatch;
        public ObjectManager ObjectManager;
        public Point Camera;
        public Heart Heart;
        Input GameInput;

        public Player PlayerOne;

        public Game()
        {
            Rectangle playerrec = new Rectangle(-300, -100,64,128);
            Graphics = new GraphicsDeviceManager(this);
            Graphics.PreferredBackBufferHeight  = 720;
            Graphics.PreferredBackBufferWidth   = 1280;

            Content.RootDirectory = "Content";
            ObjectManager = new Pacemaker.ObjectManager(this);

            PlayerOne = new Player(this, playerrec);
            Camera = new Point(1280 / 2, 720 / 2);
            Heart = new Heart(this);
            GameInput = new Input(this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ObjectManager.Initialize();
            ObjectManager.Register(GameInput);
            
            ObjectManager.Register(new StaticSprite(this, new Rectangle(0, 150, 1024, 670), "FadeOut"));
            ObjectManager.Register(new StaticSprite(this, new Rectangle(670, 150, 1024, 670), "FadeOut"));
            ObjectManager.Register(new StaticSprite(this, new Rectangle(670 + 670, 150, 1024, 670), "FadeOut"));

            Rectangle groundrec1 = new Rectangle(-700, 100, 500,200);
            Rectangle groundrec2 = new Rectangle(-200, 75, 500, 200);
            Rectangle groundrec3 = new Rectangle(100, 90, 500, 200);
            Rectangle groundrec4 = new Rectangle(300, 60, 500, 200);

            //ObjectManager.Register(new Ground(new Point(-700, 100), groundrec1,this));
            ObjectManager.Register(new Ground(new Point(groundrec2.X, groundrec2.Y), groundrec2, this));
            //ObjectManager.Register(new Ground(new Point(100, 90), groundrec3, this));
            //ObjectManager.Register(new Ground(new Point(300, 60), groundrec4, this));
            ObjectManager.Register(PlayerOne);
            ObjectManager.Register(Heart);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            ObjectManager.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            SpriteBatch.Begin();
            // TODO: Add your drawing code here
            ObjectManager.Draw(gameTime);

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
