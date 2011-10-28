using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusAgentGame.Entities
{
    class EntityWumpus : Entity
    {
        String ASSETNAME = "Wumpus";

        private const bool Kill = true;

        private const bool Pickup = false;

        private bool visible = false;

        public EntityWumpus(int x, int y, bool vis)
        {
            base._posX = x;
            base._posY = y;
            base.ENTITY_ASSETNAME = ASSETNAME;
            visible = vis;
            setEntity(Kill, Pickup, visible);
        }
    }
}
