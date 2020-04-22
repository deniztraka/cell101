using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Engines.AI.States.Bandits
{

    public class BanditIdleState : MobileIdleState
    {
        public BanditIdleState(float chaseDistance) : base(chaseDistance)
        {

        }
    }
}