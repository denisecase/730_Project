using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WumpusAgentGame
{
    class Sprite
    {
        public Rectangle Size;
        public float Scale = 1.0f;
        public Vector2 Position = new Vector2(0, 0);
        private Texture2D mSpriteTexture;


        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            mSpriteTexture = theContentManager.Load<Texture2D>(theAssetName);
            Size = new Rectangle(0, 0, (int)(mSpriteTexture.Width * Scale), (int)(mSpriteTexture.Height * Scale));
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(mSpriteTexture, Position,
                new Rectangle(0, 0, mSpriteTexture.Width, mSpriteTexture.Height),
                Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

        public void Draw(SpriteBatch theSpriteBatch, bool visible, Color _tint)
        {
            if (visible == false) _tint = Color.Black;
            theSpriteBatch.Draw(mSpriteTexture, Position,
                new Rectangle(0, 0, mSpriteTexture.Width, mSpriteTexture.Height), _tint,
                0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

        public void Update(GameTime theGameTime, Vector2 theSpeed, Vector2 theDirection)
        {
            Position += theDirection * theSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
        }
        public void Update(GameTime theGameTime, Vector2 theSpeed, Vector2 theDirection, int step)
        {
            double millisecondsPerFrame = 2000; //Update every 2 seconds
            double timeSinceLastUpdate = 0; //Accumulate the elapsed time

            timeSinceLastUpdate += theGameTime.ElapsedGameTime.TotalMilliseconds;
            if(timeSinceLastUpdate >= millisecondsPerFrame)
            {
                 timeSinceLastUpdate = 0;

                   Position += theDirection * theSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
            }
          
        }

    }
}
