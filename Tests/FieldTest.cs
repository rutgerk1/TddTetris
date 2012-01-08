using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TddTetris;
using Microsoft.Xna.Framework;

namespace Tests
{
    [TestFixture]
    public class FieldTest
    {

        /* test should have a mock block
         * 
         */
        [TestCase( 0, 5 )]
        public void FixBlockTest( int x, int y )
        {

        }

        [Test]
        public void SingleColumnNoMovesTest()
        {
            Field field = new Field( 1, 10 );
            IBlock block = new Block();
            field.SetBlock( block, new Point( 0, 0 ) );

            block.Grid [ 0 ] [ 0 ] = Color.Tomato;

            bool moveleft = field.CanMoveLeft();
            Assert.AreEqual( false, moveleft );
            bool moveright = field.CanMoveRight();
            Assert.AreEqual( false, moveright );
        }

        [Test]
        public void TwoColumnMoveLeftOkTest()
        {
            Field field = new Field( 2, 10 );
            IBlock block = new Block();
            field.SetBlock( block, new Point( 1, 0 ) );
            block.Grid [ 0 ] [ 0 ] = Color.Tomato;

            bool moveleft = field.CanMoveLeft();
            Assert.AreEqual( true, moveleft );
        }

        [Test]
        public void TwoColumnMoveLeftNotOkTest()
        {
            Field field = new Field( 2, 10 );
            IBlock block = new Block();
            field.SetBlock( block, new Point( 0, 0 ) );
            block.Grid [ 0 ] [ 0 ] = Color.Tomato;

            bool moveleft = field.CanMoveLeft();
            Assert.AreEqual( false, moveleft );
        }

        [Test]
        [ExpectedException(typeof(FieldException))]
        public void BadBlockPlacementTest()
        {
            Field field = new Field( 2, 10 );
            IBlock block = new Block();
            field.SetBlock( block, new Point( 5, 0 ) );
        }

    }
}
