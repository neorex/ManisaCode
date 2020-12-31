using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Config
{
    public static class Enums
    {
        public enum SlicerType
        {
            Cura,
            Simplify3D,
            PrusaSlicer
        }
        public enum EndStop
        {
            Minimum,
            Maximum
        }
        public enum PurgingDirectionType
        {
            X,
            Y
        }
        public enum MoveAxisAfterEndType
        {
            홈,
            지정위치,
            이동안함
        }
    }
 
}
