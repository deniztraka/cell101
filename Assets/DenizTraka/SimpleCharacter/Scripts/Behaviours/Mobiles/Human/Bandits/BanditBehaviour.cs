using DTWorld.Core.Mobiles.Humans.Bandits;
using DTWorld.Engines.AI;
using DTWorld.Engines.AI.States.Bandits;
using DTWorld.Engines.Input;
using DTWorld.Engines.Movement;

namespace DTWorld.Behaviours.Mobiles.Human
{

    public class BanditBehaviour : HumanBehaviour
    {
        private MobileAI banditAI;
        //private PlayerBehaviour playerBehaviour;
        public override void Awake()
        {
            base.Awake();
            banditAI = new MobileAI(new BanditIdleState(1));
        }

        public override void Start()
        {
            base.Start();
            this.Mobile = new Bandit(this.Speed, new FreeFormMovement(this.Rigidbody2D, new HumanMovementInput(banditAI)));
            banditAI.SetMobile(this);
        }

        public void Update()
        {
            banditAI.Update();
        }

        public override void FixedUpdate()
        {
            banditAI.FixedUpdate();
            base.FixedUpdate();
        }
    }
}
