using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Timers;
using Microsoft.Xna.Framework;

namespace WumpusAgentGame
{
    class Agent
    {

        //public Action Receptor()
        //{

        //}

        List<Tile> closedList;
        List<Tile> openList;  // prioritized queue of tiles to search (lower f gets higher priority)
        Stack<Tile> pathStack;

        Dictionary<Tile, Tile> cameFrom;
        Dictionary<Tile, int> gDic;
        Dictionary<Tile, int> hDic;
        Dictionary<Tile, int> fDic;


        public int
            hEstimate(Tile curTile, Tile goal)
        {
            return Math.Abs(goal._posY - curTile._posY) + Math.Abs(goal._posX - curTile._posX);
        }

        public Agent()
        {

            closedList = new List<Tile>();
            openList = new List<Tile>();
            pathStack = new Stack<Tile>();

            cameFrom = new Dictionary<Tile, Tile>();

            gDic = new Dictionary<Tile, int>();  // path cost by tile.  right now I'm not using g, but I have it in there in case.
            hDic = new Dictionary<Tile, int>();  // heuristic estimate h by tile
            fDic = new Dictionary<Tile, int>();  // est total distance + cost function by tile ( f = g + h)

        }


        /// <summary>
        ///  A* search. At each step, we pick the best option (lowest f) and add that tile's neighbors to the search.
        /// </summary>
        /// <param name="startTile">curTile</param>
        /// <param name="goalTile">goalTile</param>
        /// <param name="player">player</param>
        /// <param name="theGameTime">theGameTime</param>
        /// <returns>List<Action>List of actions</Action></returns>
        public List<Action> AStarSearchForGoal(Tile startTile, Tile goalTile, Player player, GameTime theGameTime)
        {
            Action currentAction = new Action();
            var actions = new List<Action>();


            var aInit = new Action();
            aInit.CurrentCommand = Action.Command.None;
            player.playerLog.Add("Adding initial action to our list: " + aInit.CurrentCommand.ToString());
            actions.Add(aInit);

            openList.Add(startTile);  // start search with current location

            gDic[startTile] = 0;  // total cost along best path so far
            hDic[startTile] = hEstimate(startTile, goalTile);
            fDic[startTile] = gDic[startTile] + hDic[startTile];

            bool isPossiblePathCostGBetter = false;

            while (openList.Count > 0)
            {
                player.playerLog.Add("Open list count is: " + openList.Count);
                int bestScore = int.MaxValue;  // want a low best score
                Tile bestTile = startTile;
                foreach (KeyValuePair<Tile, int> fPair in fDic)
                {
                    if (fPair.Value < bestScore)  // if better, use
                    {
                        bestScore = fPair.Value;
                        bestTile = fPair.Key;
                    }
                }
                if (bestTile == goalTile)  // we've reached the goal. Return this list of actions.
                {

                    player.playerLog.Add("Agent has found the goal at " + bestTile._posX + "," + bestTile._posX + ".");
                    closedList.Add(bestTile);
                    player.playerLog.Add("Adding best tile " + bestTile._posX + "," + bestTile._posY + " to CLOSED LIST (ct now " + closedList.Count + ")");


                    pathStack.Push(bestTile);
                    pathStack = reconstructPath(pathStack, bestTile);
                    player.playerLog.Add("Created path stack with " + pathStack.Count + " items.");

                    Action a = new Action();
                    a.CurrentCommand = Action.Command.Climb;
                    player.playerLog.Add("Adding final action to our path: " + a.CurrentCommand.ToString() + " for a path of length " + actions.Count + " ");
                    actions.Add(a);
                    return actions;
                }

                // move the best tile to the closed list
                openList.Remove(bestTile);
                player.playerLog.Add("Removing best tile " + bestTile._posX + "," + bestTile._posY + " from open list (ct now " + openList.Count + ")");

                closedList.Add(bestTile);
                player.playerLog.Add("Adding best tile " + bestTile._posX + "," + bestTile._posY + " to CLOSED LIST (ct now " + closedList.Count + ")");


                // initialize score to worst possible
                int tentativegscore = int.MaxValue;

                // get the best locations neighbors
                List<Tile> neighbors = Game.Instance.GetNeighbors(bestTile);
                foreach (Tile t in neighbors)
                {
                    player.playerLog.Add("Found " + neighbors.Count + " possible moves from " + bestTile._posX + "," + bestTile._posY + ": " + t._posX + "," + t._posY);
                }

                // for each neighboring tile
                int count = 1;
                foreach (Tile t in neighbors)
                {
                    player.playerLog.Add("Considering option " + count++ + " of " + neighbors.Count);
                    if (!closedList.Contains(t))  // if not already in the closed queue...
                    {
                        // assume a tentative path cost of 1 more than the best
                        tentativegscore = gDic[bestTile] + 1;
                        player.playerLog.Add("tentative g score is " + tentativegscore);

                        // if not already on open list, add it
                        if (!openList.Contains(t))
                        {
                            openList.Add(t);
                            isPossiblePathCostGBetter = true;
                        }
                        // if its new or has a lower path, then our tentative score is better
                        else if (tentativegscore < gDic[t]) { isPossiblePathCostGBetter = true; }

                        // otherwise it's not
                        else { isPossiblePathCostGBetter = false; }

                        // if this is tentatively better (lower)
                        if (isPossiblePathCostGBetter)
                        {
                            // keep our parent
                            cameFrom[t] = bestTile;

                            // then update the path cost g, h, and f

                            gDic[t] = tentativegscore;
                            hDic[t] = hEstimate(t, goalTile);
                            fDic[t] = hDic[t];

                            // add this action to our list 
                            Action a = Game.Instance.GetAction(bestTile, t);
                            player.playerLog.Add("Adding action to list: " + a.CurrentCommand.ToString() + " (list count is " + actions.Count + ")");
                            actions.Add(a);


                        }
                    }  // end closed check
                }
            }

            return null;
        }

        private Stack<Tile> reconstructPath(Stack<Tile> priorPath, Tile newTile)
        {

            if (priorPath.Contains(newTile))
            {
                priorPath.Push(cameFrom[newTile]);
                return priorPath;
            }

            else
            {
                var newPath = new Stack<Tile>();
                newPath.Push(newTile);
                return newPath;
            }
        }


    }
}
