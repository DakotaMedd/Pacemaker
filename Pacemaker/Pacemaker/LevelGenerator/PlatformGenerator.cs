using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacemaker.LevelGenerator
{
    public class PlatformGenerator
    {
        private static readonly int NUMOFSIZES = 2;
        private static readonly int SIZEWIDTH1 = 256;
        private static readonly int SIZEHEIGHT1 = 128;
        private static readonly string TEXNAME1 = "Platform256x128";

        private static readonly int SIZEWIDTH2 = 512;
        private static readonly int SIZEHEIGHT2 = 256;
        private static readonly string TEXNAME2 = "Platform512x256";

        private static readonly int WIDTHUPPER = 500;
        private static readonly int WIDTHLOWER = 500;

        private static readonly int HEIGHTUPPER = 40;
        private static readonly int HEIGHTLOWER = 40;

        private int levelline;
        private Random gen;
        private Platform platformHead;
        public Platform platfromCurrent { get; set; }
        public List<GameSpecific.JumpLocation> jumps { get; set; }
        private Point[] sizes;
        private string[] textures;

        public PlatformGenerator(int levelline, int start)
        {
            this.levelline = levelline;
            sizes = new Point[NUMOFSIZES];
            textures = new string[NUMOFSIZES];
            sizes[0] = new Point(SIZEWIDTH1, SIZEHEIGHT1);
            sizes[1] = new Point(SIZEWIDTH2, SIZEHEIGHT2);
            textures[0] = TEXNAME1;
            textures[1] = TEXNAME2;

            platformHead = new Platform(start,levelline, TEXNAME2, new Point(SIZEWIDTH2,SIZEHEIGHT2));
            platfromCurrent = platformHead;
            gen = new Random();
            jumps = new List<GameSpecific.JumpLocation>();
        }

        public void generatePlatform()
        {
            platfromCurrent.spaceToNext = gen.Next(WIDTHLOWER, WIDTHUPPER);
            int sizeChoice = gen.Next(NUMOFSIZES);
            int nextHeight = gen.Next(HEIGHTLOWER, HEIGHTUPPER);
            int currentPlatformEnd = platfromCurrent.startLocation + platfromCurrent.size.X;
            generateJump(platfromCurrent, nextHeight, currentPlatformEnd);
            Platform p = new Platform(currentPlatformEnd + platfromCurrent.spaceToNext, nextHeight, textures[sizeChoice], sizes[sizeChoice]);
            platfromCurrent.next = p;
            platfromCurrent = p;
        }

        private void generateJump(Platform platfromCurrent, int nextHeight, int currentPlatformEnd)
        {
            float alpha = 4f;
            float beta = 5f;
            int constant = 0;
            GameSpecific.JumpLocation jump = new GameSpecific.JumpLocation(new Point(0,0));
            jump.position.X = currentPlatformEnd-5;
            jump.velocity = (int)Math.Sqrt((Math.Pow(alpha,2) + Math.Pow(beta, 2)))+constant;
            jumps.Add(jump);
        }

        public List<Platform> getPlatforms()
        {
            List<Platform> f = new List<Platform>();
            platfromCurrent = platformHead;
            if (platfromCurrent != null)
            {
                while (platfromCurrent.next != null)
                {
                    f.Add(platfromCurrent);
                    platfromCurrent = platfromCurrent.next;
                }
            }
            return f;
        }
    }
}
