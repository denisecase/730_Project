using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusAgentGame
{
    class Action
    {
        public enum Command
        {
            Left, Right, Up, Down, PickUp, ShootLeft, ShootRight, ShootUp, ShootDown, Climb, None
        }

        public Command CurrentCommand = Command.None;
    }
}
