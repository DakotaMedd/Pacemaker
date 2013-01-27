using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacemaker.Engine
{
    public interface IDrawable
    {
        void Draw(GameTime _GameTime);
    }

    public interface IPhysical
    {
        Rectangle GetCollisionVolume();
        void HandleCollision(Vector2 _Reaction);
    }

    public interface IUpdateable
    {
        void Update(GameTime _GameTime);
    }

    public interface IObject
    {
        void Initialize();
    }
}
