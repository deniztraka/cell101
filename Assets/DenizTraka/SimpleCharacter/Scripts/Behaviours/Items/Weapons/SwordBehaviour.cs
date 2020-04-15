using System.Collections;
using System.Collections.Generic;
using DTWorld.Core.Items.Weapons;
using UnityEngine;
namespace DTWorld.Behaviours.Items.Weapons
{
    public class SwordBehaviour : BaseWeaponBehaviour
    {
        public override void Awake()
        {
            base.Awake();
            Item = new Sword("Sword");            
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