using System.Collections;
using System.Collections.Generic;
using DTWorld.Engines.AI.Mobiles.EnemyAI;
using DTWorld.Engines.Movement;
using UnityEngine;
namespace DTWorld.Engines.AI.EnemyAI.Bandits
{
    public class BanditAI : BaseEnemyAI
    {        
        public BanditAI() : base()
        {
        }

        internal override float GetXAxis()
        {
            return 0.1f;
        }

        internal override float GetYAxis()
        {
            return 0.1f;
        }
    }
}
