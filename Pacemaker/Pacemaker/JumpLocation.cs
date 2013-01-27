using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacemaker.GameSpecific
{
    public class JumpLocation
    {
        public float Position;
        public bool hasJumped;
        public float Velocity;

        public JumpLocation(float _Position, float _Velocity)
        {
            Position = _Position;
            Velocity = _Velocity;
            hasJumped = false;
        }
    }
}
