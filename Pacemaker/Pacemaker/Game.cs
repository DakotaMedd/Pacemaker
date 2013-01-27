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
using Pacemaker.Engine;
using Pacemaker.GameSpecific;

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
        //Level Level1;

        public Game()
        {
            Graphics = new GraphicsDeviceManager(this);
            Graphics.PreferredBackBufferWidth   = 1280;
            Graphics.PreferredBackBufferHeight  = 720;
            

            Camera = new Point(0, 0);
            ObjectManager = new Engine.ObjectManager(this);

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            //////////////////////////////Level Object//////////////////////////////

            /////////////////////////////Level Layout Begin///////////////////////////////

            /**
            ObjectManager.Register(new WorldPhysicalObject(new Point(512, 256), "Platform512x256", new Vector2(-512.0f, -250.0f), this));
            ObjectManager.Register(new WorldPhysicalObject(new Point(512, 256), "Platform512x256", new Vector2(   0.0f, -250.0f), this));
            ObjectManager.Register(new WorldPhysicalObject(new Point(512, 256), "Platform512x256", new Vector2( 512.0f, -250.0f), this));
            ObjectManager.Register(new WorldPhysicalObject(new Point(512, 256), "Platform512x256", new Vector2(1536.0f, -250.0f), this));
            ObjectManager.Register(new WorldPhysicalObject(new Point(512, 256), "Platform512x256", new Vector2(512.0f * 3.4f, -250.0f), this));
            ObjectManager.Register(new WorldPhysicalObject(new Point(512, 256), "Platform512x256", new Vector2(512.0f * 4.6f, -250.0f), this));
            ObjectManager.Register(new WorldPhysicalObject(new Point(512, 256), "Platform512x256", new Vector2(512.0f * 5.8f, -250.0f), this));

            //ObjectManager.Register(new WorldPhysicalObject(new Point(256, 128), "Platform256x128", new Vector2(512.0f * 4.5f, -50.0f), this));
            **/

            LevelGenerator.PlatformGenerator pg = new LevelGenerator.PlatformGenerator(-10, 0);
            for (int i = 0; i < 12; i++ )
                pg.generatePlatform();
            List<LevelGenerator.Platform> ps = pg.getPlatforms();
            foreach (LevelGenerator.Platform p in ps)
            {
                ObjectManager.Register(new WorldPhysicalObject(p.size, p.texture, new Vector2(p.startLocation + p.size.X/2, p.height + p.size.Y/2), this));
            }

            /////////////////////////////Level Layout End///////////////////////////////
            /**
            int Index = -1;

            ObjectManager.Register(new BackgroundSection("FadeOut", new Vector2(1024.0f * Index, -100.0f), this));
            ObjectManager.Register(new BackgroundSection("Black", new Vector2(1024.0f * Index, -650.0f * 1.0f), this));
            ObjectManager.Register(new BackgroundSection("Black", new Vector2(1024.0f * Index, -650.0f * 2.0f), this));

            Index++;
            ObjectManager.Register(new BackgroundSection("FadeOut", new Vector2(1024.0f * Index, -100.0f), this));
            ObjectManager.Register(new BackgroundSection("Black", new Vector2(1024.0f * Index, -650.0f * 1.0f), this));
            ObjectManager.Register(new BackgroundSection("Black", new Vector2(1024.0f * Index, -650.0f * 2.0f), this));

            Index++;
            ObjectManager.Register(new BackgroundSection("FadeOut", new Vector2(1024.0f * Index, -100.0f), this));
            ObjectManager.Register(new BackgroundSection("Black", new Vector2(1024.0f * Index, -650.0f * 1.0f), this));
            ObjectManager.Register(new BackgroundSection("Black", new Vector2(1024.0f * Index, -650.0f * 2.0f), this));

            /*
            Index++;
            ObjectManager.Register(new WorldSpriteObject("FadeOut", new Vector2(1024.0f * Index, -100.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 1.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 2.0f), this));

            Index++;
            ObjectManager.Register(new WorldSpriteObject("FadeOut", new Vector2(1024.0f * Index, -100.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 1.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 2.0f), this));

            Index++;
            ObjectManager.Register(new WorldSpriteObject("FadeOut", new Vector2(1024.0f * Index, -100.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 1.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 2.0f), this));

            Index++;
            ObjectManager.Register(new WorldSpriteObject("FadeOut", new Vector2(1024.0f * Index, -100.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 1.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 2.0f), this));

            Index++;
            ObjectManager.Register(new WorldSpriteObject("FadeOut", new Vector2(1024.0f * Index, -100.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 1.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 2.0f), this));

            Index++;
            ObjectManager.Register(new WorldSpriteObject("FadeOut", new Vector2(1024.0f * Index, -100.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 1.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 2.0f), this));

            Index++;
            ObjectManager.Register(new WorldSpriteObject("FadeOut", new Vector2(1024.0f * Index, -100.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 1.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 2.0f), this));

            Index++;
            ObjectManager.Register(new WorldSpriteObject("FadeOut", new Vector2(1024.0f * Index, -100.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 1.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 2.0f), this));

            Index++;
            ObjectManager.Register(new WorldSpriteObject("FadeOut", new Vector2(1024.0f * Index, -100.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 1.0f), this));
            ObjectManager.Register(new WorldSpriteObject("Black", new Vector2(1024.0f * Index, -650.0f * 2.0f), this));

            //ObjectManager.Register(new WorldSpriteObject("FadeOut", new Vector2(670.0f * 1.5f, -100.0f), this));
            //ObjectManager.Register(new WorldSpriteObject("FadeOut", new Vector2(670.0f * 3.0f, -100.0f), this));
             */

            ////////////////////////////////////////////////////////////////////////
            //Level1 = new Level(this);
            //Level1.Initialize();

            ObjectManager.Register(new Player(new Vector2(-100.0f, -100.0f), this, pg.jumps));

        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //Level1.Update(gameTime);
            ObjectManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.AnisotropicClamp, DepthStencilState.Default, RasterizerState.CullNone);

            ObjectManager.Draw(gameTime);

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
