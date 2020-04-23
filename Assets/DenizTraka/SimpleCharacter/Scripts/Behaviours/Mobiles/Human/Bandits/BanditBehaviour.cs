using DTWorld.Core.Mobiles.Humans.Bandits;
using DTWorld.Engines.AI;
using DTWorld.Engines.AI.States;
using DTWorld.Engines.Input;
using DTWorld.Engines.Movement;

namespace DTWorld.Behaviours.Mobiles.Human
{

    public class BanditBehaviour : HumanBehaviour
    {
        private MobileAI banditAI;
        
        public override void Awake()
        {
            base.Awake();
            banditAI = new MobileAI(new MobileWanderState(1, 5, IsAggressive, ChaseDistance));
        }

        public override void Start()
        {
            base.Start();
            this.Mobile = new Bandit(this.Speed, new FreeFormMovement(this.Rigidbody2D, new HumanMovementInput(banditAI)));
            banditAI.SetMobile(this);
        }

        public override void Update()
        {
            base.Update();
            banditAI.Update();
        }

        public override void FixedUpdate()
        {
            banditAI.FixedUpdate();
            base.FixedUpdate();
        }
    }
}
