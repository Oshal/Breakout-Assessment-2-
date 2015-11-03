using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game4
{
     class Block
    {
        #region Fields

        private bool mActive = true;

        // Drawing stuff
        private Texture2D mSprite;
        private Rectangle mDrawRectangle;

        #endregion

        #region Constructors

    
        public Block(Texture2D sprite, int x, int y)
        {
           
            mSprite = sprite;

            InitializeDrawRectangle(sprite, x, y);
	}

        #endregion

        #region Properties

        /// <summary>
        /// Gets and set whether or not the Block is active
        /// </summary>
        public bool Active
        {
            get { return mActive; }
            set { mActive = value; }
        }

        /// <summary>
        /// Gets the collision rectangle for the Block
        /// </summary>
        public Rectangle CollisionRectangle
        {
            get { return mDrawRectangle; }
        }

        #endregion

        #region Public methods

    
        /// <summary>
        /// Draws the Block
        /// </summary>
        /// <param name="spriteBatch">the sprite batch to use</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (mActive)
            {
                spriteBatch.Draw(mSprite, mDrawRectangle, Color.White);
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Initializes the draw rectangle
        /// </summary>
        /// <param name="sprite">the sprite for the block</param>
        /// <param name="x">the x location of the center of the block</param>
        /// <param name="y">the y location of the center of the block</param>
        private void InitializeDrawRectangle(Texture2D sprite, int x, int y)
        {
            mDrawRectangle = new Rectangle(x - sprite.Width / 2,
                y - sprite.Height / 2, sprite.Width,
                sprite.Height);
        }

        #endregion
    }
}

