using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using WumpusAgentGame.Entities;

namespace WumpusAgentGame
{
    class Game   //  singleton dmc
    {
        //XNA Content Manager
        private ContentManager _content;

        //Player
        private Player _player;

        //The Game Board, each title is unique
        private Tile[,] mBoard;

        //Size of the Screen (5 = 500 pixels)
        private const int SCREEN = 5;

        //Size of the board, gets from settings
        private int boardX;
        private int boardY;

        //Used to transition the screen when you move off of it
        private bool boardTransition = false;
        private int viewX;
        private int viewY;

        //Manages Entities (Wumpus,Pits,Gold)
        private Entity[,] entityMap;

        //Game Settings
        private Settings settingMenu;

        //Info on what has been done
        private GameControl gameInfo;

        //Fonts (not used yet)
        SpriteFont header1;

        // make a static   
        private static Game instance;
        private Game() { }

        public bool AutoPlay
        {
            get { return settingMenu.autoPlay; }
            set { settingMenu.autoPlay = value; }
        }


        public static Game Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new Game();
                }
                return instance;
            }

        }
        public int BoardX { get { return boardX; } }
        public int BoardY { get { return boardY; } }


        public Game(Settings setmenu, ContentManager cm, int x, int y)
        {


            settingMenu = setmenu;
            _content = cm;
            boardX = x;
            boardY = y;

            viewX = 0;
            //Sets the view to the bottom left corner
            viewY = y - SCREEN;

            mBoard = new Tile[x, y];
            entityMap = new Entity[x, y];
            instance = this;

        }



        public void LoadGame()
        {
            //Loads Font
            header1 = _content.Load<SpriteFont>("Header1");

            //Loads the Player
            _player = new Player(boardY - 1, SCREEN);
            _player.LoadContent(_content);

            //Load Game Control
            gameInfo = new GameControl();
            gameInfo.setSeed(settingMenu.seed);
            gameInfo.SetOutputList(_player.playerLog);
            gameInfo.UpdateScore(_player.Score);
            gameInfo.SetStatus("");
            gameInfo.Show();

            //Loads the Board
            Sprite mRoom = new Sprite();
            bool visible = settingMenu.allVisible;
            bool autoPlay = settingMenu.autoPlay;
            Random rand = new Random(settingMenu.seed);

            //Gets the # of pits, wumpus, and gold
            double pitLow = (((double)boardX * (double)boardY) / 100) * settingMenu.pitLower;
            double pitHigh = (((double)boardX * (double)boardY) / 100) * settingMenu.pitHigher;
            int pits = rand.Next((int)pitLow, (int)pitHigh);
            int wumpus = settingMenu.wumpus;
            int gold = settingMenu.gold;

            bool top = false;
            bool bottom = false;
            bool left = false;
            bool right = false;
            //Prepares the tiles
            for (int x = 0; x < boardX; x++)
            {
                for (int y = 0; y < boardY; y++)
                {
                    string _resource;
                    if (x == 0 & y == 0)
                    {
                        _resource = "RoomTileLeftTop";
                        left = true;
                        top = true;
                        bottom = false;
                        right = false;
                    }
                    else if (x == 0 & y == boardY - 1)
                    {
                        _resource = "RoomTileLeftBot";
                        bottom = true;
                        left = true;
                        right = false;
                        top = false;
                    }
                    else if (x == boardX - 1 && y == 0)
                    {
                        _resource = "RoomTileRightTop";
                        right = true;
                        top = true;
                        left = false;
                        bottom = false;
                    }
                    else if (x == boardX - 1 && y == boardY - 1)
                    {
                        _resource = "RoomTileRightBot";
                        right = true;
                        bottom = true;
                        left = false;
                        top = false;
                    }
                    else if (x == 0)
                    {
                        _resource = "RoomTileLeft";
                        left = true;
                        top = false;
                        bottom = false;
                        right = false;

                    }
                    else if (y == 0)
                    {
                        _resource = "RoomTileTop";
                        top = true;
                        bottom = false;
                        left = false;
                        right = false;

                    }
                    else if (y == boardY - 1)
                    {
                        _resource = "RoomTileBot";
                        bottom = true;
                        top = false;
                        left = false;
                        right = false;

                    }
                    else if (x == boardX - 1)
                    {
                        _resource = "RoomTileRight";
                        right = true;
                        top = false;
                        bottom = false;
                        left = false;

                    }
                    else
                    {
                        _resource = "RoomTile";
                        top = false;
                        bottom = false;
                        left = false;
                        right = false;
                    }
                    mBoard[x, y] = new Tile(x, y, visible, top, bottom, right, left);
                    mBoard[x, y].LoadContent(_content, _resource);
                    if (y == boardY - 1 && x == 0)
                    {
                        mBoard[x, y]._explored = true;
                    }
                }
            }

            //Prepares the Pits
            while (pits != 0)
            {
                int x = rand.Next(0, boardX);
                int y = rand.Next(0, boardY);
                if (entityMap[x, y] == null && !(x == 0 && y == boardY - 1))
                {
                    EntityPit ep = new EntityPit(x, y, visible);
                    ep.LoadContent(_content);
                    entityMap[x, y] = ep;
                    if (x - 1 >= 0) mBoard[x - 1, y]._breeze = true;
                    if (y - 1 >= 0) mBoard[x, y - 1]._breeze = true;
                    if (x + 1 < boardX) mBoard[x + 1, y]._breeze = true;
                    if (y + 1 < boardY) mBoard[x, y + 1]._breeze = true;
                    pits--;
                }
            }

            //Prepares the Gold
            while (gold != 0)
            {
                int x = rand.Next(0, boardX);
                int y = rand.Next(0, boardY);
                if (entityMap[x, y] == null && !(x == 0 && y == boardY - 1))
                {
                    EntityGold eg = new EntityGold(x, y, visible);
                    eg.LoadContent(_content);
                    entityMap[x, y] = eg;
                    gold--;
                }
            }

            //Prepares the Wumpus
            while (wumpus != 0)
            {
                int x = rand.Next(0, boardX);
                int y = rand.Next(0, boardY);
                if (entityMap[x, y] == null && !(x == 0 && y == boardY - 1))
                {
                    EntityWumpus ep = new EntityWumpus(x, y, visible);
                    ep.LoadContent(_content);
                    entityMap[x, y] = ep;
                    if (x - 1 >= 0) mBoard[x - 1, y]._stench = true;
                    if (y - 1 >= 0) mBoard[x, y - 1]._stench = true;
                    if (x + 1 < boardX) mBoard[x + 1, y]._stench = true;
                    if (y + 1 < boardY) mBoard[x, y + 1]._stench = true;
                    wumpus--;
                }
            }
        }

        public void UpdateGame(GameTime gametime)
        {
            //Updates the player
            _player.Update(gametime);
            this.gameInfo.SetStatus(_player.playerLoc);

            //Checks if a Transition was just made, if so prepares for the next transition
            if (boardTransition == false && _player.transition == false)
            {
                boardTransition = true;
            }
            screenTransition();
            //Checks if a player is between tiles, currently also manages if a player is moving into a tile that they would die in
            if (_player.isBetweenTiles())
            {
                try
                {
                    mBoard[(int)_player.DestinationX, _player.DestinationY]._explored = true;
                    if (entityMap[(int)_player.DestinationX, _player.DestinationY] != null && _player.goingToDie == false)
                    {
                        entityMap[(int)_player.DestinationX, _player.DestinationY].visible = true;
                        if (entityMap[(int)_player.DestinationX, _player.DestinationY].Kill == true)
                        {
                            _player.goingToDie = true;
                            if (entityMap[(int)_player.DestinationX, _player.DestinationY].ENTITY_ASSETNAME == "Wumpus")
                            {
                                _player.playerLog.Add("Player Killed by Wumpus!");
                            }
                            else _player.playerLog.Add("Player killed by Pit!");
                            _player.listUpdated = true;
                            _player.Score = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _player.playerLog.Add("Error: " + ex.Message);
                }


            }
            //If the player fired an arrow, check which direction it was fired, then check if a wumpus was
            // within 5ish blocks in that direction (might make an infinite arrow range option later, on larger maps it could make searching
            // for many wumpus' more reasonable)
            if (_player.firedArrow == true)
            {
                if (_player.lastAction.CurrentCommand == Action.Command.ShootLeft)
                {
                    int check;
                    if (_player.PosX - 5 >= 0) check = _player.PosX - 5;
                    else check = 0;
                    for (int x = _player.PosX; x >= check; x--)
                    {
                        checkWumpus(x, true);
                    }
                }
                else if (_player.lastAction.CurrentCommand == Action.Command.ShootRight)
                {
                    int check;
                    if (_player.PosX + 5 <= boardX) check = _player.PosX + 5;
                    else check = boardX;
                    for (int x = _player.PosX; x < check; x++)
                    {
                        checkWumpus(x, true);
                    }
                }
                else if (_player.lastAction.CurrentCommand == Action.Command.ShootUp)
                {
                    int check;
                    if (_player.PosY - 5 >= 0) check = _player.PosY - 5;
                    else check = 0;
                    for (int y = _player.PosY; y >= check; y--)
                    {
                        checkWumpus(y, false);
                    }
                }
                else if (_player.lastAction.CurrentCommand == Action.Command.ShootDown)
                {
                    int check;
                    if (_player.PosY + 5 <= boardY) check = _player.PosY + 5;
                    else check = boardY;
                    for (int y = _player.PosY; y < boardY; y++)
                    {
                        checkWumpus(y, false);
                    }
                }
                _player.ArrowReset();
            }
            //If picking_up and there is treasure, pick it up
            if (_player.picking_up == true && entityMap[_player.PosX, _player.PosY] != null && entityMap[_player.PosX, _player.PosY].ENTITY_ASSETNAME == "Treasure")
            {
                entityMap[_player.PosX, _player.PosY] = null;
                _player.Score += boardX * boardY * 2;
                _player.playerLog.Add("Player picked up the Gold! +" + boardX * boardY * 2 + " Points");
                _player.listUpdated = true;
            }
            else
            {
                _player.picking_up = false;
            }
            //If player is going to die, and they are at destination (wumpus or pit), Kill them
            if (_player.goingToDie == true && _player.DestinationX == _player.PosX && _player.DestinationY == _player.PosY)
            {
                _player.dead();
            }
            //If player's score < 0 kill them
            if (_player.Score < 0)
            {
                _player.dead();
                _player.goingToDie = true;
                _player.playerLog.Add("Player Starved to Death!");
                _player.listUpdated = true;
            }
            //Updates the List and score!
            if (_player.listUpdated == true)
            {
                gameInfo.UpdateList();
                gameInfo.UpdateScore(_player.Score);
                _player.listUpdated = false;
            }
            //Calculates the lighting
            calcLight();
        }

        public void GameDraw(SpriteBatch sb)
        {
            for (int x = viewX; x < viewX + SCREEN; x++)
            {
                for (int y = viewY; y < viewY + SCREEN; y++)
                {
                    try
                    {
                        //Draws the Tiles
                        mBoard[x, y].DrawTile(sb);
                        //Draws the entities (needs a lighting fix?)
                        if (entityMap[x, y] != null) entityMap[x, y].DrawEntity(sb);
                        //Draws the tile effects
                        mBoard[x, y].DrawEffect(sb);
                    }
                    catch (Exception ex) // try catch dmc
                    {
                        _player.playerLog.Add("Error:  " + ex.Message);
                    }
                }
            }
            //Draws the Player
            _player.Draw(sb);
            if (_player.goingToDie == true)
            {
                sb.DrawString(header1, "You Lose!", new Vector2(0, 0), Color.White);
            }
            if (_player.escaped == true)
            {
                sb.DrawString(header1, "You Escaped! Score: " + _player.Score + " Points", new Vector2(0, 0), Color.White);
            }
        }

        //Adjusts Tiles brightness around current tile
        private void calcLight()
        {
            double x = _player.Position.X / 100;
            double y = _player.Position.Y / 100;
            double _bright = 0;
            for (int i = 0; i < SCREEN; i++)
            {
                for (int j = 0; j < SCREEN; j++)
                {
                    _bright = Math.Abs(10 - (Math.Abs(x - i) + Math.Abs(y - j)));
                    if (_bright < 0 || _bright > 20) _bright = 0;
                    try
                    {
                        mBoard[i + viewX, j + viewY].Brightness = _bright;
                    }
                    catch (Exception ex)  // try catch added dmc
                    {
                        _player.playerLog.Add("Error in calc brightness:  " + ex.Message);
                    }
                }
            }
        }

        private void screenTransition()
        {
            if (_player.transition == true && _player.PosY > _player.DestinationY && boardTransition)
            {
                viewY -= SCREEN;
                boardTransition = false;
            }
            else if (_player.transition == true && _player.PosY < _player.DestinationY && boardTransition)
            {
                viewY += SCREEN;
                boardTransition = false;
            }
            else if (_player.transition == true && _player.PosX > _player.DestinationX && boardTransition)
            {
                viewX -= SCREEN;
                boardTransition = false;
            }
            else if (_player.transition == true && _player.PosX < _player.DestinationX && boardTransition)
            {
                viewX += SCREEN;
                boardTransition = false;
            }
        }

        //If b == true then you are shooting along X
        // if false, you are shooting along Y
        private void checkWumpus(int i, bool b)
        {
            if (b == true)
            {
                if (entityMap[i, _player.PosY] != null && entityMap[i, _player.PosY].ENTITY_ASSETNAME == "Wumpus")
                {
                    entityMap[i, _player.PosY] = null;
                    _player.Score += boardX * boardY * 4;
                    _player.playerLog.Add("Player slayed the Wumpus! +" + boardX * boardY * 4 + " Points");
                    _player.listUpdated = true;
                }
            }
            else
            {
                if (entityMap[_player.PosX, i] != null && entityMap[_player.PosX, i].ENTITY_ASSETNAME == "Wumpus")
                {
                    entityMap[_player.PosX, i] = null;
                    _player.Score += boardX * boardY * 4;
                    _player.playerLog.Add("Player slayed the Wumpus! +" + boardX * boardY * 4 + " Points");
                    _player.listUpdated = true;
                }
            }
        }

        // dmc - add error checking / walls....
        public List<Tile> GetNeighbors(Tile curTile)
        {
            var lst = new List<Tile>();
            Tile t;

            if (curTile._posX == 0)
            {
                t = mBoard[curTile._posX + 1, curTile._posY];
                lst.Add(t);
            }
            else if (curTile._posX == this.boardX - 1)
            {
                t = mBoard[curTile._posX - 1, curTile._posY];
                lst.Add(t);
            }
            else
            {
                t = mBoard[curTile._posX + 1, curTile._posY];
                lst.Add(t);
                t = mBoard[curTile._posX - 1, curTile._posY];
                lst.Add(t);
            }
            if (curTile._posY == 0)
            {
                t = mBoard[curTile._posX, curTile._posY + 1];
                lst.Add(t);
            }
            else if (curTile._posY == this.boardY - 1)
            {
                t = mBoard[curTile._posX, curTile._posY - 1];
                lst.Add(t);
            }
            else
            {
                t = mBoard[curTile._posX, curTile._posY + 1];
                lst.Add(t);
                t = mBoard[curTile._posX, curTile._posY - 1];
                lst.Add(t);
            }



            return lst;
        }


        public Tile GetTile(int x, int y)
        {
            return mBoard[x, y];
        }



        /// <summary>
        /// Get the action given start tile and end tile.
        /// </summary>
        /// <param name="startTile"></param>
        /// <param name="endTile"></param>
        /// <returns></returns>
        internal Action GetAction(Tile startTile, Tile endTile)
        {
            Action a = new Action();
            if (startTile._posX > endTile._posX) { a.CurrentCommand = Action.Command.Left; }
            else if (startTile._posX < endTile._posX) { a.CurrentCommand = Action.Command.Right; }
            else if (startTile._posY > endTile._posY) { a.CurrentCommand = Action.Command.Up; }
            else if (startTile._posY < endTile._posY) { a.CurrentCommand = Action.Command.Down; }
            return a;

        }



    }
}
