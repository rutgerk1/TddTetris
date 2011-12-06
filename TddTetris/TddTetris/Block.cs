using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TddTetris
{
    public class Block : IBlock
    {
        public List<List<Color?>> Grid { get; set; }
        private int gridsize = 5;   // bad: magic number

        private List<List<Color?>> createGrid()
        {
            List<List<Color?>> grid = new List<List<Color?>>();
            for ( int i = 0; i < gridsize; i++ )
            {
                grid.Add( new List<Color?>() );
                for ( int j = 0; j < gridsize; j++ )
                {
                    grid [ i ].Add( null );
                }
            }
            return grid;
        }


        public Block()
        {
            Grid = createGrid();
        }

        public void RotateLeft()
        {
            List<List<Color?>> newGrid = createGrid();

            for ( int i = 0; i < gridsize; i++ )
            {
                for ( int j = 0; j < gridsize; j++ )
                {
                    newGrid [ i ] [ j ] = Grid [ j ] [ Math.Abs( i - ( gridsize - 1 ) ) ];
                }
            }
            Grid = newGrid;
        }

        public void RotateRight()
        {
            RotateLeft();
            RotateLeft();
            RotateLeft();
        }

        public Color? ColorAt( Point position )
        {
            if ( position.X >= 0 && position.Y >= 0 &&
                position.X < gridsize && position.Y < gridsize )
            {
                return Grid [ position.Y ] [ position.X ];
            }
            return null;
        }
    }
}
