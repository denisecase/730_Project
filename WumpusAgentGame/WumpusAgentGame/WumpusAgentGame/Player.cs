using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace WumpusAgentGame
{
    class Player : Sprite
    {
        const string PLAYER_ASSETNAME = "Player";
        private int START_POSITION_X = 0;
        private int START_POSITION_Y = 400;
        const int PLAYER_SPEED = 160;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;
        private int SCREEN;
        private int startY;

        //Current Positions and Destination Positions
        private int posX = 0;
        private int destPosX = 0;
        private int posY = 0;
        private int destPosY = 0;
        public bool transition = false;

		// dmc - add ask game for goal (outlet) tile

		
        //Human or Agent
        //Currently set to true until agent class is done...
        bool isHuman = true;  
        Agent AI;

        //Log
        public List<string> playerLog;
        public bool listUpdated = false;

        //Win or Lose
        public bool goingToDie = false;
        public bool escaped = false;
        public bool picking_up = false;
        public bool firedArrow = false;
        public Action lastAction;

        //Score
        public int Score;
        private int arrows;

        //Player states
        enum State
        {
            Walking,Stopped,Dead,Escaped,Firing,Fired
        }

        //Current State: Stopped, not moving
        private State CurrentState = State.Stopped;
        Vector2 Direction = Vector2.Zero;
        Vector2 Speed = Vector2.Zero;

        public Player(int y,int _screen)
        {
            SCREEN = _screen;
            startY = y;
            posY = y;
            destPosY = y;
            //START_POSITION_Y = 100 * 4 + 45;
            playerLog = new List<string>();
            AI = new Agent();
            Score = ((y + 1) * (y + 1)) * 2;
            arrows = 1;

			
        }

        //Prepares the Player Sprite
        public void LoadContent(ContentManager theContentManager)
        {
            Position = new Vector2(START_POSITION_X, START_POSITION_Y);
            base.LoadContent(theContentManager, PLAYER_ASSETNAME);
        }

        //Updates the Player
        public void Update(GameTime theGameTime)
        {
            Action newAction;
			//if (isHuman == true)
            if(!Game.Instance.AutoPlay)  // human playable
			{
				KeyboardState aCurrentKeyboardState = Keyboard.GetState();
				if (aCurrentKeyboardState.IsKeyDown(Keys.F) == true && CurrentState == State.Stopped && arrows > 0)
				{
					CurrentState = State.Firing;
					playerLog.Add("Preparing to Fire ARROW");
					listUpdated = true;
				}
				newAction = getInput(aCurrentKeyboardState);
				if (newAction.CurrentCommand == Action.Command.Climb && escaped == false)
				{
					escaped = true;
					CurrentState = State.Escaped;
					playerLog.Add("Player Escaped! Final Score: " + Score + " Points");
					listUpdated = true;
				}
				else if (newAction.CurrentCommand == Action.Command.PickUp)
				{
					picking_up = true;
				}
				UpdateMovement(newAction);
				if (CurrentState == State.Firing) shootArrow(newAction);
				lastAction = newAction;
			}
			else  // dmc......................
			{
				const int GOALX = 4;  // temporary goal assumed up and over 5
				const int GOALY = 0;  

				Tile curTile = Game.Instance.GetTile(this.posX, this.posY);
				Tile exitTile = Game.Instance.GetTile(GOALX, GOALY);

                playerLog.Add("Current x is "+ this.posX);
                playerLog.Add("Current y is " + this.posY);

                playerLog.Add("Goal x is " + GOALX);
                playerLog.Add("Goal y is " + GOALY);
                
                var actions = new List<Action>();

                CurrentState = State.Stopped;

                // get the action sequence
				actions = AI.AStarSearchForGoal(curTile, exitTile, this, theGameTime);

                if (actions == null) return;

                var acts =new List<Action>();
                acts.Add(actions[0]);
                acts.Add(actions[1]);

                playerLog.Add("The search found a path of length " + actions.Count);
                int count = 1;
                foreach (Action a in actions)
                {
                    playerLog.Add("Step " + count++ + ": " + a.CurrentCommand.ToString());
                }

                foreach (Action a in acts)   
                {
                    
                    CurrentState = State.Stopped;  //dmc
                    destPosX = 1;
                    destPosY = 1;
                    
                    if (a.CurrentCommand == Action.Command.Climb && escaped == false)
                    {
                        escaped = true;
                        CurrentState = State.Escaped;
                        playerLog.Add("Player Escaped! Final Score: " + Score + " Points");
                        listUpdated = true;
                    }
                    else if (a.CurrentCommand == Action.Command.PickUp)
                    {
                        picking_up = true;
                    }
                    UpdateMovement(a);
                     base.Update(theGameTime, Speed, Direction, 1);  // hmm....
                     if (CurrentState == State.Firing) shootArrow(a);
                    lastAction = a;
                }
				//mPreviousKeyboardState = aCurrentKeyboardState;
			}
            base.Update(theGameTime, Speed, Direction);
        }

        //Updates the Movement
        public void UpdateMovement(Action curAction)
        {
            //If Moving, check to see if at destination
            if (CurrentState == State.Walking)
            {
                int zA = destPosX / 5;
                int zB = destPosY / 5;
                int newX = (destPosX - (5 * zA)) * 100;
                int newY = (destPosY - (5 * zB)) * 100;
                
                if (zA == posX / 5 && zB == posY / 5 || transition == true)
                {
                    if ((Direction.Y == MOVE_UP || Direction.X == MOVE_LEFT) &&
                        (this.Position.X) <= (newX) && (this.Position.Y) <= (newY))
                    {
                        Speed = Vector2.Zero;
                        Direction = Vector2.Zero;
                        Position.X = newX;
                        Position.Y = newY;
                        posX = destPosX;
                        posY = destPosY;
                        CurrentState = State.Stopped;
                        transition = false;
                    }
                    else if ((Direction.Y == MOVE_DOWN || Direction.X == MOVE_RIGHT) &&
                        (this.Position.X) >= (newX) && (this.Position.Y) >= (newY))
                    {
                        Speed = Vector2.Zero;
                        Direction = Vector2.Zero;
                        Position.X = newX;
                        Position.Y = newY;
                        posX = destPosX;
                        posY = destPosY;
                        CurrentState = State.Stopped;
                        transition = false;
                    }
                }
                else
                {
                    if ((Direction.Y == MOVE_UP) &&
                        (this.Position.Y) <= -40)
                    {
                        Position.Y = (SCREEN * 100-40);
                        transition = true;
                    }
                    else if ((Direction.Y == MOVE_DOWN) &&
                        (this.Position.Y) >= SCREEN*100-40)
                    {
						Position.Y = -40;
						transition = true;
                    }
                    else if ((Direction.X == MOVE_LEFT) &&
                        (this.Position.X) <= -40)
                    {
                        Position.X = (SCREEN * 100-40);
                        transition = true;
                    }
                    else if ((Direction.X == MOVE_RIGHT) &&
                        (this.Position.X) >= SCREEN*100-40)
                    {
                        Position.X = -40;
                        transition = true;
                    }
                }
            }
            //If Stopped, Do X
            if (CurrentState == State.Stopped)
            {
                if (curAction.CurrentCommand == Action.Command.Left)
                {
                    Speed.X = PLAYER_SPEED;
                    Direction.X = MOVE_LEFT;
					// dmc
					if (Position.X < 1)
					{
						CurrentState = State.Walking;
						playerLog.Add("Player attempted to move LEFT but couldn't");
						listUpdated = true;
					}
					else
					{
						destPosX += MOVE_LEFT;
						CurrentState = State.Walking;
						playerLog.Add("Player moved LEFT");
						listUpdated = true;
						Score--;
					}
                }
                else if (curAction.CurrentCommand == Action.Command.Right)
                {
                    Speed.X = PLAYER_SPEED;
                    Direction.X = MOVE_RIGHT;
					// dmc
					if (Position.X >= 400)
					{
						CurrentState = State.Walking;
						playerLog.Add("Player attempted to move RIGHT but couldn't");
						listUpdated = true;
					}
					else
					{
						destPosX += MOVE_RIGHT;
						CurrentState = State.Walking;
						playerLog.Add("Player moved RIGHT");
						listUpdated = true;
						Score--;
					}
                }
                else if (curAction.CurrentCommand == Action.Command.Up)
                {
                    Speed.Y = PLAYER_SPEED;
                    Direction.Y = MOVE_UP;
					// dmc
					if (Position.Y <= 1)
					{
						CurrentState = State.Walking;
						playerLog.Add("Player attempted to move UP but couldn't");
						listUpdated = true;
					}
					else
					{
						destPosY += MOVE_UP;
						CurrentState = State.Walking;
						playerLog.Add("Player moved UP");
						listUpdated = true;
						Score--;
					}
                }
                else if (curAction.CurrentCommand == Action.Command.Down)
                {
                    Speed.Y = PLAYER_SPEED;
                    Direction.Y = MOVE_DOWN;
					
					// dmc
					if (Position.Y >=400) 
					{
						CurrentState = State.Walking;
						playerLog.Add("Player attempted to move DOWN but couldn't");
						listUpdated = true;
					}
					else
					{
	                destPosY += MOVE_DOWN;
                    CurrentState = State.Walking;
                    playerLog.Add("Player moved DOWN");
                    listUpdated = true;
                    Score--;
					}
                }
            }
        }

        //Checks if the player is between 2 tiles
        public bool isBetweenTiles()
        {
            int zA = destPosX / 5;
            int zB = destPosY / 5;
            int newX = (destPosX - (5 * zA)) * 100;
            int newY = (destPosY - (5 * zB)) * 100;
            bool between = false;
            if ((Direction.X == MOVE_UP || Direction.Y == MOVE_LEFT) &&
                (this.Position.X) <= (newX+75) && (this.Position.Y) <= (newY+75))
            {
                between = true;
            }
            else if ((Direction.X == MOVE_DOWN || Direction.Y == MOVE_RIGHT) &&
                (this.Position.X) >= (newX-75) && (this.Position.Y) >= (newY-75))
            {
                between = true;
            }
            return between;
        }
        
        public void setPositionX(int x, GameTime gt)
        {
            posX = x;
        }
        public void setPositionY(int y, GameTime gt)
        {
            posY = y;
        }


        public int PosX
        {
            get { return posX; }
        }
        public int PosY
        {
            get { return posY; }
        }
        public int DestinationX
        {
            get { return destPosX; }
        }
        public int DestinationY
        {
            get { return destPosY; }
        }

        //Quick Death method, needs improvement
        public void dead()
        {
            CurrentState = State.Dead;
            Speed = new Vector2(0, 0);
            Score = 0;
        }

        //Gets the Human Players Input
        private Action getInput(KeyboardState aCurrentKeyboardState)
        {
            Action currentAction = new Action();
            if (CurrentState == State.Firing && aCurrentKeyboardState.IsKeyDown(Keys.Left) == true) currentAction.CurrentCommand = Action.Command.ShootLeft;
            else if (CurrentState == State.Firing == true && aCurrentKeyboardState.IsKeyDown(Keys.Right) == true) currentAction.CurrentCommand = Action.Command.ShootRight;
            else if (CurrentState == State.Firing == true && aCurrentKeyboardState.IsKeyDown(Keys.Up) == true) currentAction.CurrentCommand = Action.Command.ShootUp;
            else if (CurrentState == State.Firing == true && aCurrentKeyboardState.IsKeyDown(Keys.Down) == true) currentAction.CurrentCommand = Action.Command.ShootDown;
            else if (aCurrentKeyboardState.IsKeyDown(Keys.F) == false && aCurrentKeyboardState.IsKeyDown(Keys.Left) == true) currentAction.CurrentCommand = Action.Command.Left;
            else if (aCurrentKeyboardState.IsKeyDown(Keys.F) == false && aCurrentKeyboardState.IsKeyDown(Keys.Right) == true) currentAction.CurrentCommand = Action.Command.Right;//fix this tommorow
            else if (aCurrentKeyboardState.IsKeyDown(Keys.F) == false && aCurrentKeyboardState.IsKeyDown(Keys.Up) == true) currentAction.CurrentCommand = Action.Command.Up;
            else if (aCurrentKeyboardState.IsKeyDown(Keys.F) == false && aCurrentKeyboardState.IsKeyDown(Keys.Down) == true) currentAction.CurrentCommand = Action.Command.Down;
            else if (aCurrentKeyboardState.IsKeyDown(Keys.F) == false && aCurrentKeyboardState.IsKeyDown(Keys.Space) == true && CurrentState != State.Walking)
            {
                if (posX == 0 && posY == startY) currentAction.CurrentCommand = Action.Command.Climb;
                else currentAction.CurrentCommand = Action.Command.PickUp;
            }
            return currentAction;
        }

        private void shootArrow(Action act)
        {
            if (act.CurrentCommand == Action.Command.ShootLeft)
            {
                playerLog.Add("Player Shot Arrow LEFT");
                arrows--;
                listUpdated = true;
                CurrentState = State.Fired;
                firedArrow = true;
            }
            else if (act.CurrentCommand == Action.Command.ShootRight)
            {
                playerLog.Add("Player Shot Arrow RIGHT");
                arrows--;
                listUpdated = true;
                CurrentState = State.Fired;
                firedArrow = true;
            }
            else if (act.CurrentCommand == Action.Command.ShootUp)
            {
                playerLog.Add("Player Shot Arrow UP");
                arrows--;
                listUpdated = true;
                CurrentState = State.Fired;
                firedArrow = true;
            }
            else if (act.CurrentCommand == Action.Command.ShootDown)
            {
                playerLog.Add("Player Shot Arrow DOWN");
                arrows--;
                listUpdated = true;
                CurrentState = State.Fired;
                firedArrow = true;
            }
        }

        public void ArrowReset()
        {
            firedArrow = false;
            CurrentState = State.Stopped;
            System.Threading.Thread.Sleep(100);
        }
		public void CallGameUpdate(GameTime theGameTime)
		{
			base.Update(theGameTime, Speed, Direction);
		}

    }
}
