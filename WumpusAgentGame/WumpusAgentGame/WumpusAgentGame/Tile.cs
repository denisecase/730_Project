using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WumpusAgentGame
{
    class Tile : Sprite
    {
        //private Sprite _texture;
        public int _posX;
        public int _posY;

        private double _brightness = 0;

        public bool _stench = false;
        public bool _breeze = false;
        public bool _isTopWall = false;
        public bool _isBottomWall = false;
        public bool _isRightWall = false;
        public bool _isLeftWall = false;
        private Sprite stenchSprite;
        private Sprite breezeSprite;

        //Game Variables
        public bool _explored = false;

        public Tile(int x, int y, bool vis)
        {
            _posX = x;
            _posY = y;
            _explored = vis;
            stenchSprite = new Sprite();
            breezeSprite = new Sprite();
        }

        public Tile(int x, int y, bool vis, bool top, bool bottom, bool right, bool left)
        {
            _posX = x;
            _posY = y;
            _isTopWall = top;
            _isBottomWall = bottom;
            _isRightWall = right;
            _isLeftWall = left;
            _explored = vis;
            stenchSprite = new Sprite();
            breezeSprite = new Sprite();
        }

        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            Position = new Vector2(_posX * 100, _posY * 100);
            base.LoadContent(theContentManager, theAssetName);
            stenchSprite.LoadContent(theContentManager, "Stench");
            breezeSprite.LoadContent(theContentManager, "Breeze");
        }

        public void DrawTile(SpriteBatch theSpriteBatch)
        {
            int zA = _posX / 5;
            int zB = _posY / 5;
            Position.X = (_posX - (5 * zA)) * 100;
            Position.Y = (_posY - (5 * zB)) * 100;

            Draw(theSpriteBatch, _explored, LightLevel());
        }

        public void DrawEffect(SpriteBatch theSpriteBatch)
        {
            if (_stench == true)
            {
                int zA = _posX / 5;
                int zB = _posY / 5;
                stenchSprite.Position.X = (_posX - (5 * zA)) * 100;
                stenchSprite.Position.Y = (_posY - (5 * zB)) * 100;
                stenchSprite.Draw(theSpriteBatch, _explored, LightLevel());
            }
            if (_breeze == true)
            {
                int zA = _posX / 5;
                int zB = _posY / 5;
                breezeSprite.Position.X = (_posX - (5 * zA)) * 100;
                breezeSprite.Position.Y = (_posY - (5 * zB)) * 100;
                breezeSprite.Draw(theSpriteBatch, _explored, LightLevel());
            }
        }

        private Color LightLevel()
        {
            Color _tint = Color.Black;
            if (_explored == true)
            {
                _tint = new Color((int)(50 + _brightness * 20), (int)(50 + _brightness * 20), (int)(50 + _brightness * 20));
            }
            return _tint;
        }

        public double Brightness
        {
            get { return _brightness; }
            set { _brightness = value; }
        }
        
    }
}
