using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusAgentGame.Entities
{
    class EntityGold : Entity
    {
        String ASSETNAME = "Treasure";

        private const bool Kill = false;

        private const bool Pickup = true;

        private bool visible = false;

        public EntityGold(int x, int y, bool vis)
        {
            base._posX = x;
            base._posY = y;
            base.ENTITY_ASSETNAME = ASSETNAME;
            visible = vis;
            setEntity(Kill, Pickup, visible);
        }
    }
}
