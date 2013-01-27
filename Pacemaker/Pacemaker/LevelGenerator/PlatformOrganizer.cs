using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacemaker.LevelGenerator
{
    public class PlateformOrganizer
    {
        private static readonly int NUMOFSIZES = 2;
        private static readonly int SIZEWIDTH1 = 256;
        private static readonly int SIZEHEIGHT1 = 128;
        private static readonly string TEXNAME1 = "Platform256x128";

        private static readonly int SIZEWIDTH2 = 512;
        private static readonly int SIZEHEIGHT2 = 256;
        private static readonly string TEXTNAME2 = "Platform512x256";

        private static readonly int WIDTHUPPER = 2;
        private static readonly int WIDTHLOWER = 0;

        private static readonly int HEIGHTUPPER = 2;
        private static readonly int HEIGHTLOWER = 0;

        private int levelline;
        private Random gen;
        private Platform platformHead;
        private Platform platfromCurrent;
        private List<GameSpecific.JumpLocation> jumps;
        private Point[] sizes;

        public PlateformOrganizer(int levelline)
        {
            this.levelline = levelline;
            platformHead = new Platform(0,levelline, TEXNAME1, new Point(SIZEWIDTH1,SIZEHEIGHT1));
            gen = new Random();

        }

        public void generatePlatform()
        {
            platfromCurrent.spaceToNext = gen.Next(WIDTHLOWER, WIDTHUPPER);
            Platform p = new Platform();
        }
    }
}
