using DTWorld.Behaviours.AI;
using DTWorld.Core.Mobiles.Humans.Bandits;
using DTWorld.Engines.AI;
using DTWorld.Engines.AI.States;
using DTWorld.Engines.Input;
using DTWorld.Engines.Movement;
using UnityEngine;

namespace DTWorld.Behaviours.Mobiles.Human
{

    [RequireComponent(typeof(AIMovementBehaviour))]
    public class BanditBehaviour : HumanBehaviour
    {
        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            base.Start();                     
            this.Mobile = new Bandit(this.Speed, new FreeFormMovement(Rigidbody2D, GetComponent<AIMovementBehaviour>()));
        }

        public override void Update()
        {
            base.Update();
            //banditAI.Update();
        }

        public override void FixedUpdate()
        {
            //banditAI.FixedUpdate();
            base.FixedUpdate();
        }
    }
}
