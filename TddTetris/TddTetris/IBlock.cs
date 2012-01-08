using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace TddTetris
{
    public interface IBlock
    {
        List<List<Color?>> Grid { get; set; }
        void RotateLeft();
        void RotateRight();
        int RightMost { get; }
        int LeftMost { get; }

        Color? ColorAt( Point position );
    }
}
