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
        public List<List<Color?>> Grid { get; private set; }

        public OverlapChecker Checker { get; set; }

        public Field( int width, int height )
        {
            this.Width = width;
            this.Height = height;
            Checker = new OverlapChecker();
            Grid = new List<List<Color?>>( height );
            for ( int i = 0; i < height; i++ )
            {
                Grid.Add( new List<Color?>( width ) );
                for ( int j = 0; j < width; j++ )
                {
                    Grid [ i ].Add( null );
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

            //position is position in Grid, Position is position of Block
            Point p = new Point( ( position.X - Position.X ), ( position.Y - Position.Y ) );
            if ( Block != null && Block.ColorAt( p ) != null )
            {
                return Block.ColorAt( p );
            }

            return Grid [ y ] [ x ];
        }


        public void SetBlock( IBlock block, Point position )
        {
            if ( !this.Checker.Check(this,block, position.X, position.Y ) )
            {
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
            return this.Checker.Check( this, this.Block, Position.X - 1, Position.Y );
        }

        public void MoveBlockLeft()
        {
            Position = new Point( Position.X - 1, Position.Y );
        }

        public bool CanMoveRight()
        {
            return this.Checker.Check( this, this.Block, Position.X + 1, Position.Y );
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
            return Checker.Check(this, Block, Position.X, Position.Y + 1);
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
            for ( int i = 0; i < Block.Grid.Count; i++ )
            {
                for ( int j = 0; j < Block.Grid.Count; j++ )
                {
                    Color? color = Block.ColorAt( new Point( j, i ) );
                    if ( color != null )
                    {
                        Grid [ Position.Y + i ] [ Position.X + j ] = color;
                    }
                }
            }
        }
    }
}
