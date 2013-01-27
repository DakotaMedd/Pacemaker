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
    public class ObjectManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        List<Microsoft.Xna.Framework.GameComponent> GameObjects;
        List<PhysicsComponent> collisionObjects;

        public ObjectManager(Game _Game)
            : base(_Game)
        {
            GameObjects = new List<GameComponent>();
            collisionObjects = new List<PhysicsComponent>();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public void Register(PacemakerComponent _GameComponent)
        {
            GameObjects.Add(_GameComponent);
            if(_GameComponent.getCollisonObject() != null)
                collisionObjects.Add(_GameComponent.getCollisonObject());
            _GameComponent.Initialize();
        }

        public void Unregister(PacemakerComponent _GameComponent)
        {
            GameObjects.Remove(_GameComponent);
            if (_GameComponent.getCollisonObject() != null)
            collisionObjects.Remove(_GameComponent.getCollisonObject());
        }

        public void Register(GameComponent _GameComponent)
        {
            GameObjects.Add(_GameComponent);
            _GameComponent.Initialize();
        }

        public void Unregister(GameComponent _GameComponent)
        {
            GameObjects.Remove(_GameComponent);
        }

        public override void Update(GameTime _GameTime)
        {
            base.Update(_GameTime);

            foreach (GameComponent Component in GameObjects)
            {
                Component.Update(_GameTime);
            }
        }

        public override void Draw(GameTime _GameTime)
        {
            foreach (GameComponent Component in GameObjects)
            {
                if(Component is DrawableGameComponent)
                    ((DrawableGameComponent)Component).Draw(_GameTime);
            }

            base.Draw(_GameTime);
        }

        public List<PhysicsComponent> getCollisionObjects()
        {
            return collisionObjects;
        }
    }
}
