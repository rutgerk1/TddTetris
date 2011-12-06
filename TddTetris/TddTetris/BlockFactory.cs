using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TddTetris
{
    public class BlockFactory : IBlockFactory
    {
        private void insertStraight(Block block)
        {
            List<List<Color?>> grid = block.Grid;
            grid [ 3 ] [ 1 ] = Color.Tomato;
            grid [ 3 ] [ 2 ] = Color.Tomato;
            grid [ 3 ] [ 3 ] = Color.Tomato;
            grid [ 3 ] [ 4 ] = Color.Tomato;
        }

        public IBlock MakeBlock()
        {
            Block block = new Block();
            insertStraight( block );
            return new Block();
        }
    }
}
