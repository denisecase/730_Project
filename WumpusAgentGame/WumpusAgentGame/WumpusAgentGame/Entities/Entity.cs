using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WumpusAgentGame.Entities
{
    class Entity : Sprite
    {
        public String ENTITY_ASSETNAME;
        public int _posX;
        public int _posY;

        public bool Kill;
        bool Pickup;
        public bool visible;

        public void DrawEntity(SpriteBatch theSpriteBatch)
        {
            int zA = _posX / 5;
            int zB = _posY / 5;
            Position.X = (_posX - (5 * zA)) * 100;
            Position.Y = (_posY - (5 * zB)) * 100;

            Draw(theSpriteBatch,visible,Color.White);
        }

        public void setEntity (bool K, bool P, bool V)
        {
            Kill = K;
            Pickup = P;
            visible = V;
        }

        public void LoadContent(ContentManager theContentManager)
        {
            Position = new Vector2(_posX * 100, _posY * 100);
            base.LoadContent(theContentManager, ENTITY_ASSETNAME);
        }
    }
}
