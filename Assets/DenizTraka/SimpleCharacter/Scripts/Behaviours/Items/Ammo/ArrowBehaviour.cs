using System.Collections;
using System.Collections.Generic;
using DTWorld.Core.Items.Ammo;
using UnityEngine;
namespace DTWorld.Behaviours.Items.Ammo
{
    public class ArrowBehaviour : BaseAmmoBehaviour
    {
        public float Damage;
        // Start is called before the first frame update
        public override void Start()
        {
            base.Start();
            
            Item = new Arrow(Damage);
        }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();
        }
    }
}