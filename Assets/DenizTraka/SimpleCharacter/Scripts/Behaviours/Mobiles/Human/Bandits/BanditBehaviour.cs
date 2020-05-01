using DTWorld.Behaviours.AI;
using DTWorld.Core.Mobiles.Humans.Bandits;
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

        void OnDrawGizmos()
        {
            if (WeaponBehaviour != null)
            {
                // Draw a yellow sphere at the transform's position
                var chaseDistanceColor = Color.yellow;
                chaseDistanceColor.a = 0.25f;
                Gizmos.color = chaseDistanceColor;
                Gizmos.DrawSphere(transform.position, ChaseDistance);


                var attackRangeColor = Color.red;
                attackRangeColor.a = 0.25f;
                Gizmos.color = attackRangeColor;
                Gizmos.DrawSphere(transform.position, WeaponBehaviour.AttackDistance);

                var fleeRangeColor = Color.white;
                fleeRangeColor.a = 0.25f;
                Gizmos.color = fleeRangeColor;
                Gizmos.DrawSphere(transform.position, FleeDistance);
            }
        }
    }
}
