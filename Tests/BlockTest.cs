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
    public class BlockTest
    {

        [Test]
        public void RotateLeftTest(){
            Block block = new Block();

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

        [Test]
        public void ColorAtPositionTest()
        {
            Block block = new Block();

            block.Grid [ 0 ] [ 0 ] = Color.Tomato;
            Assert.AreEqual( null, block.ColorAt( new Point( 0, 0 ) ) );

        }

    }
}
