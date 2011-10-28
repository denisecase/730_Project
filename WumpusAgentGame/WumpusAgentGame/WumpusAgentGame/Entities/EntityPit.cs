using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WumpusAgentGame.Entities
{
    class EntityPit : Entity
    {

        String ASSETNAME = "Pit";

        private const bool Kill = true;

        private const bool Pickup = false;

        private bool visible = false;


        public EntityPit(int x, int y, bool vis)
        {
            base._posX = x;
            base._posY = y;
            base.ENTITY_ASSETNAME = ASSETNAME;
            visible = vis;
            setEntity(Kill, Pickup, visible);
        }

    }
}
