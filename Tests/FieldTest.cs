using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TddTetris;
using Microsoft.Xna.Framework;
using Moq;

namespace Tests
{
    [TestFixture]
    public class FieldTest
    {

        [Test]
        public void FixBlockTest()
        {
            Field field = new Field( 1, 10 );
            IBlock block = new Block();
            block.Grid [ 0 ] [ 0 ] = Color.Tomato;
            field.SetBlock( block, new Point( 0, 0 ) );
            Assert.AreEqual( null, field.ColorAt( new Point( 0, 9 ) ) );
            field.FixBlock();
            Assert.AreEqual( Color.Tomato, field.ColorAt( new Point( 0, 9 ) ) );
        }

        [Test]
        public void FixDoubleBlockTest()
        {
            Field field = new Field( 2, 10 );
            IBlock block = new Block();
            block.Grid [ 0 ] [ 0 ] = Color.Tomato;
            block.Grid [ 0 ] [ 1 ] = Color.Tomato;
            field.SetBlock( block, new Point( 0, 0 ) );
            Assert.AreEqual( null, field.ColorAt( new Point( 0, 9 ) ) );
            Assert.AreEqual( null, field.ColorAt( new Point( 1, 9 ) ) );
            field.FixBlock();
            Assert.AreEqual( Color.Tomato, field.ColorAt( new Point( 0, 9 ) ) );
            Assert.AreEqual( Color.Tomato, field.ColorAt( new Point( 1, 9 ) ) );
        }

        [Test]
        public void FixSquareBlockTest()
        {
            Field field = new Field( 2, 10 );
            IBlock block = new Block();
            block.Grid [ 0 ] [ 0 ] = Color.Tomato;
            block.Grid [ 0 ] [ 1 ] = Color.Tomato;
            block.Grid [ 1 ] [ 0 ] = Color.Tomato;
            block.Grid [ 1 ] [ 1 ] = Color.Tomato;
            field.SetBlock( block, new Point( 0, 0 ) );
            Assert.AreEqual( null, field.ColorAt( new Point( 0, 9 ) ) );
            Assert.AreEqual( null, field.ColorAt( new Point( 1, 9 ) ) );
            Assert.AreEqual( null, field.ColorAt( new Point( 0, 8 ) ) );
            Assert.AreEqual( null, field.ColorAt( new Point( 1, 8 ) ) );
            field.FixBlock();
            Assert.AreEqual( Color.Tomato, field.ColorAt( new Point( 0, 9 ) ) );
            Assert.AreEqual( Color.Tomato, field.ColorAt( new Point( 1, 9 ) ) );
            Assert.AreEqual( Color.Tomato, field.ColorAt( new Point( 0, 8 ) ) );
            Assert.AreEqual( Color.Tomato, field.ColorAt( new Point( 1, 8 ) ) );
        }

        [Test]
        public void SingleColumnNoMovesTest()
        {
            Field field = new Field( 1, 10 );
            IBlock block = new Block();
            block.Grid [ 0 ] [ 0 ] = Color.Tomato;

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

        [TestCase( 2, 0 )]
        [TestCase( 5, 0 )]
        [TestCase( -12, 0 )]
        [ExpectedException( typeof( FieldException ) )]
        public void BadBlockPlacementTest( int x, int y )
        {
            Field field = new Field( 2, 10 );
            IBlock block = new Block();
            block.Grid [ 2 ] [ 2 ] = Color.Tomato;
            field.SetBlock( block, new Point( x, y ) );
        }

        [TestCase( -2, 0 )]
        [TestCase( -1, 0 )]
        [TestCase( 0, 0 )]
        [TestCase( 1, 0 )]
        [TestCase( 2, 0 )]
        public void CorrectBlockPlacementTest( int x, int y )
        {
            Field field = new Field( 5, 10 );
            IBlock block = new Block();
            block.Grid [ 2 ] [ 2 ] = Color.Tomato;
            field.SetBlock( block, new Point( x, y ) );
        }

        private void createBigBlock( IBlock block )
        {
            for ( int i = 0; i < 5; i++ )
            {
                for ( int j = 0; j < 5; j++ )
                {
                    block.Grid [ i ] [ j ] = Color.Tomato;
                }
            }
        }

        [TestCase( 0, 0 )]
        public void CorrectBigBlockPlacementTest( int x, int y )
        {
            Field field = new Field( 5, 10 );
            IBlock block = new Block();
            createBigBlock( block );
            field.SetBlock( block, new Point( x, y ) );
        }

        [TestCase( 1, 1 )]
        [TestCase( 11, 1 )]
        [TestCase( -1, 1 )]
        [ExpectedException( typeof( FieldException ) )]
        public void BadBigBlockPlacementTest( int x, int y )
        {
            Field field = new Field( 5, 10 );
            IBlock block = new Block();
            createBigBlock( block );
            field.SetBlock( block, new Point( x, y ) );
        }


        [TestCase( 0, 0 )]
        [TestCase( 1, 1 )]
        [TestCase( 2, 2 )]
        [TestCase( 3, 3 )]
        [TestCase( 4, 4 )]
        [TestCase( 5, 5 )]
        [TestCase( 3, -10 )]
        [TestCase( 4, -2 )]
        [TestCase( 5, -5 )]
        public void PositionTest( int x, int y )
        {
            IField field = new Field( 10, 10 );
            IBlock block = new BlockFactory().MakeBlock();
            field.SetBlock( block, new Point( x, y ) );
            field.Checker.Check( field, block, x, y );
        }

        [TestCase( -10, 6 )]
        [TestCase( 6, 6 )]
        [TestCase( 9, 9 )]
        public void BadPositionTest( int x, int y )
        {
            IField field = new Field( 10, 10 );
            IBlock block = new BlockFactory().MakeBlock();
            field.SetBlock( block, new Point( 5, 5 ) );
            try
            {
                if ( field.Checker.Check( field, block, x, y ) )
                {
                    throw new Exception( string.Format( "bad position has succeeded: x: {0}, y: {1}", x, y ) );
                }
            }
            catch ( FieldException )
            {
            }
        }

        [Test]
        public void CanAdvanceTrue()
        {
            var field = new Field( 10, 10 );
            var checker = new Mock<OverlapChecker>();
            checker.Setup( x => x.Check( field, null, 0, 1 ) ).Returns( true );
            field.Checker = checker.Object;

            Assert.AreEqual( true, field.CanAdvance() );
        }
        [Test]
        public void CanAdvanceFalse()
        {
            var field = new Field( 10, 10 );
            var checker = new Mock<OverlapChecker>();
            checker.Setup( x => x.Check( field, null, 0, 1 ) ).Returns( false );
            field.Checker = checker.Object;
            Assert.AreEqual( false, field.CanAdvance() );
        }

    }
}
