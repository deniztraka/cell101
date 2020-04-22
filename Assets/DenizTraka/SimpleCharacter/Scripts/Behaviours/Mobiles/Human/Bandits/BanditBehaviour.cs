using System.Collections;
using System.Collections.Generic;
using DTWorld.Core.Mobiles.Humans.Bandits;
using DTWorld.Engines.AI.EnemyAI.Bandits;
using DTWorld.Engines.Input;
using DTWorld.Engines.Movement;
using UnityEngine;

namespace DTWorld.Behaviours.Mobiles.Human
{

    public class BanditBehaviour : HumanBehaviour
    {
        private BanditAI banditAI;
        public override void Awake()
        {
            base.Awake();
            banditAI = new BanditAI();
        }
        
        public override void Start()
        {
            base.Start();
            this.Mobile = new Bandit(this.Speed, new FreeFormMovement(this.Rigidbody2D, new HumanMovementInput(banditAI)));
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
    }
}
