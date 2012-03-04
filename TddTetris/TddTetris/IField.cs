using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace TddTetris
{
    public interface IField
    {
        int Width { get; }
        int Height{ get; }

        bool CanMoveLeft();
        void MoveBlockLeft();

        bool CanMoveRight();
        void MoveBlockRight();

        void RotateBlock();

        bool CanAdvance();
        void AdvanceBlock();

        Color? ColorAt(Point position);
        List<List<Color?>> Grid { get; }
        Point Position { get; }
        OverlapChecker Checker { get; set; }

        void SetBlock(IBlock block, Point position);
        void FixBlock();
    }
}
