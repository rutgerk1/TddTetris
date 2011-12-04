using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace TddTetris
{
    public interface IBlock
    {
        public List<List<Color?>> Grid { get; set; }
        void RotateLeft();
        void RotateRight();

        Color? ColorAt( Point position );
    }
}
