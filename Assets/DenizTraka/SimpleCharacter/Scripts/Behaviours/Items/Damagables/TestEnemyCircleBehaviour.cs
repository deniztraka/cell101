using DTWorld.Core.Items;
using UnityEngine;

namespace DTWorld.Behaviours.Items.Damagables
{
    public class TestEnemyCircleBehaviour : DamagableItemBehaviour
    {
        public override void Awake()
        {
            base.Awake();
            Item = new TestEnemyCircle(Name);
        }

        public override void Start()
        {
            base.Start();
        }
    }
}