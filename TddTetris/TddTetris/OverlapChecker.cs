using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TddTetris
{
    public class OverlapChecker
    {
        public bool Check( IField field, IBlock block, int x, int y )
        {


            return PositionOk( block, x, y, field );
        }

        private bool PositionOk( IBlock block, int x, int y, IField field )
        {
            // check for running outside field
            if ( x + block.RightMost >= field.Width ||
                x + block.LeftMost < 0 )
            {
                return false;
            }
            // check for other blocks
            for ( int i = 0; i < block.Grid.Count; i++ )
            {
                for ( int j = 0; j < block.Grid [ i ].Count; j++ )
                {
                    if ( y + i < field.Height &&
                        x + j < field.Width &&
                        ( y + i > 0 && block.Grid [ i ] [ j ] != null && field.Grid [ y + i ] [ x + j ] != null ) )
                    {
                        return false;
                    }
                }
            }
            for ( int i = 0; i < block.Grid.Count; i++ )
            {
                for ( int j = 0; j < block.Grid [ i ].Count; j++ )
                {
                    if ( block.Grid [ i ] [ j ] != null )
                    {
                        if ( y + i >= field.Height ||
                            ( y + i + 1 >= 0 && field.Grid [ y + i ] [ x + j ] != null ) )
                        {
                            return false;
                        }
                    }
                }
            }
            return true;

        }

    }
}
