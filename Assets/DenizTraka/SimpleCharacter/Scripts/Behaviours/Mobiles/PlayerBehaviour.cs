using DTWorld.Behaviours.Items.Weapons;
using DTWorld.Behaviours.Mobiles.Human;
using DTWorld.Core.Mobiles;
using DTWorld.Engines.Movement;
using UnityEngine;

namespace DTWorld.Behaviours.Mobiles
{
    public class PlayerBehaviour : HumanBehaviour
    {

        public override void Start()
        {
            base.Start();

            this.Mobile = new Player(this.Speed, new FreeFormMovement(this.Rigidbody2D));

            
        }

        public void Update()
        {

            if (Input.GetKeyDown(KeyCode.Space))//if mobile can attack / timing is okey?
            {
                Attack();
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
    }
}