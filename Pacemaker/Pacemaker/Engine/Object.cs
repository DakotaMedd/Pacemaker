using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacemaker.Engine
{
    public class Object : IUpdateable, IObject
    {
        protected Game GameInstance;

        public Object(Game _Game)
        {
            GameInstance = _Game;
        }

        public virtual void Initialize()
        {

        }

        public virtual void Update(GameTime _GameTime)
        {

        }
    }
}
