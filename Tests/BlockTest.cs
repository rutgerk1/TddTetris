using Microsoft.Xna.Framework;
using NUnit.Framework;
using TddTetris;

namespace Tests
{
    [TestFixture]
    public class BlockTest
    {

        [Test]
        public void RotateLeftTest()
        {
            var block = new Block();

            block.Grid [ 0 ] [ 0 ] = Color.Tomato;

            block.RotateLeft();
            Assert.AreEqual( Color.Tomato, block.Grid [ 4 ] [ 0 ] );
            Assert.AreEqual( null, block.Grid [ 0 ] [ 0 ] );

            block.RotateLeft();
            Assert.AreEqual( Color.Tomato, block.Grid [ 4 ] [ 4 ] );
            Assert.AreEqual( null, block.Grid [ 0 ] [ 0 ] );

            block.RotateLeft();
            Assert.AreEqual( Color.Tomato, block.Grid [ 0 ] [ 4 ] );
            Assert.AreEqual( null, block.Grid [ 0 ] [ 0 ] );

            block.RotateLeft();
            Assert.AreEqual( Color.Tomato, block.Grid [ 0 ] [ 0 ] );
        }


        /*
         * Problemen zijn hier de gridconstructie en mogelijke index-out-of-range-excepties
         */
        [Test]
        public void RotateRightTest()
        {
            Block block = new Block();

            block.Grid [ 0 ] [ 0 ] = Color.Tomato;

            block.RotateRight();
            Assert.AreEqual( Color.Tomato, block.Grid [ 0 ] [ 4 ] );

            block.RotateRight();
            Assert.AreEqual( Color.Tomato, block.Grid [ 4 ] [ 4 ] );

            block.RotateRight();
            Assert.AreEqual( Color.Tomato, block.Grid [ 4 ] [ 0 ] );

            block.RotateRight();
            Assert.AreEqual( Color.Tomato, block.Grid [ 0 ] [ 0 ] );
        }

        [TestCase( 0, 0 )]
        [TestCase( 1, 1 )]
        [TestCase( 2, 0 )]
        [TestCase( 0, 2 )]
        public void ColorAtPositionTest( int x, int y )
        {
            Point position = new Point( x, y );
            Block block = new Block();

            block.Grid [ position.Y ] [ position.X ] = Color.Tomato;
            Assert.AreEqual( Color.Tomato, block.ColorAt( position ) );
        }


        // based on found bug
        // when the block position is not in the field yet, 
        // it should always return null and not throw an exception
        [TestCase( 0, -5 )]
        public void ColorAtPositionNegativeTest( int x, int y )
        {
            Point position = new Point( x, y );
            Block block = new Block();

            Assert.AreEqual( null, block.ColorAt( position ) );
        }

        // based on found bug
        // when the block position is in the field, but further than the block 
        // it should always return null and not throw an exception
        [TestCase( 0, 5 )]
        public void ColorAtPositionFurtherThanBlockTest( int x, int y )
        {
            Point position = new Point( x, y );
            Block block = new Block();

            Assert.AreEqual( null, block.ColorAt( position ) );
        }

    }
}
