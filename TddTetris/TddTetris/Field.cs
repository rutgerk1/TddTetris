using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TddTetris
{
    public class Field : IField
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public IBlock Block { get; private set; }
        public Point Position { get; private set; }
        private List<List<Color?>> grid;

        public Field( int width, int height )
        {
            this.Width = width;
            this.Height = height;
            grid = new List<List<Color?>>( height );
            for ( int i = 0; i < height; i++ )
            {
                grid.Add( new List<Color?>( width ) );
                for ( int j = 0; j < width; j++ )
                {
                    grid [ i ].Add( null );
                }
            }
        }

        public Color? ColorAt( Point position )
        {
            int x = position.X;
            int y = position.Y;

            if ( x < 0 || x >= Width || y < 0 || y >= Height )
            {
                throw new IndexOutOfRangeException();
            }

            //position is position in grid, Position is position of Block
            Point p = new Point( ( position.X - Position.X ), ( position.Y - Position.Y ) );
            if ( Block != null && Block.ColorAt( p ) != null )
            {
                return Color.White;
            }

            return grid [ y ] [ x ];
        }


        private bool PositionOk(IBlock block, int x, int y)
        {
            if ( x + block.RightMost >= grid [ 0 ].Capacity ||
                x + block.LeftMost < 0 )
            {
                return false;
            }
            return true;

        }
        public void SetBlock( IBlock block, Point position )
        {
            if (!PositionOk(block,position.X,position.Y)){
                throw new FieldException() {
                    Code = FieldExceptionCode.BadBlockPlacement
                };
            }
            this.Block = block;
            this.Position = position;
        }

        public void AdvanceBlock()
        {
            Position = new Point( Position.X, Position.Y + 1 );
        }

        public bool CanMoveLeft()
        {
            return PositionOk( this.Block, Position.X - 1, Position.Y );
        }

        public void MoveBlockLeft()
        {
            Position = new Point( Position.X - 1, Position.Y );
        }

        public bool CanMoveRight()
        {
            return PositionOk( this.Block, Position.X + 1, Position.Y );
        }

        public void MoveBlockRight()
        {
            Position = new Point( Position.X + 1, Position.Y );
        }

        public void RotateBlock()
        {
            Block.RotateLeft();
        }

        public bool CanAdvance()
        {
            return Position.Y < Height - 1;//&& grid [ Position.Y + 1 ] [ Position.X ] == null;
        }

        /// <summary>
        /// freezes a block when hitting bottom
        /// </summary>
        public void FixBlock()
        {
            while ( CanAdvance() )
            {
                AdvanceBlock();
            }
            grid [ Position.Y ] [ Position.X ] = Color.White;
        }
    }
}
