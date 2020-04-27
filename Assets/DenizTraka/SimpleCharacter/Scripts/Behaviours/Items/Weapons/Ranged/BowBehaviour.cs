using System.Collections;
using System.Collections.Generic;
using DTWorld.Core.Items.Weapons.Ranged;
using UnityEngine;
namespace DTWorld.Behaviours.Items.Weapons.Ranged
{
    public class BowBehaviour : BaseRangedWeaponBehaviour
    {
        public override void Awake()
        {
            base.Awake();
            Item = new Bow("Bow", Damage, SwingSpeed);
        }

        public override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();
        }
    }

}