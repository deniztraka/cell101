using System.Collections;
using System.Collections.Generic;
using DTWorld.Core.Mobiles;
using DTWorld.Engines.Movement;
using UnityEngine;

namespace DTWorld.Engines.AI.Mobiles.EnemyAI
{
    public abstract class BaseEnemyAI : BaseMobileAI
    {
        public BaseEnemyAI() : base()
        {

        }
        public BaseEnemyAI(BaseMobile mobile) : base(mobile)
        {

        }

    }
}