using Microsoft.Xna.Framework;

namespace TddTetris
{
    public interface IField
    {
        int Width { get; }

        bool CanMoveLeft();
        void MoveBlockLeft();

        bool CanMoveRight();
        void MoveBlockRight();

        void RotateBlock();

        bool CanAdvance();
        void AdvanceBlock();

        Color? ColorAt(Point position);

        void SetBlock(IBlock block, Point position);
        void FixBlock();
    }
}
