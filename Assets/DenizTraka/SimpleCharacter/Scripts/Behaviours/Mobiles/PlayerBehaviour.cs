using System;
using DTWorld.Behaviours.Items.Weapons;
using DTWorld.Behaviours.Mobiles.Human;
using DTWorld.Core.Mobiles;
using DTWorld.Engines.Input;
using DTWorld.Engines.Movement;
using DTWorld.Interfaces;
using UnityEngine;

namespace DTWorld.Behaviours.Mobiles
{
    public class PlayerBehaviour : HumanBehaviour
    {
        public GameObject HealthBarCanvas;
        

        public override void Start()
        {
            base.Start();
            IMovementType playerMovement = null;

            var joyStickObj = GameObject.FindGameObjectWithTag("Joystick");
            if (joyStickObj != null)
            {
                var joyStick = joyStickObj.GetComponent<Joystick>();
                playerMovement = new FreeFormMovement(this.Rigidbody2D, new KeyboardMovementInput());
#if UNITY_ANDROID || UNITY_IOS
                if (!Application.isEditor)
                {
                    playerMovement = new FreeFormMovement(this.Rigidbody2D, new JoyStickMovementInput(joyStick));
                }
#endif

            }
            else
            {
                playerMovement = new FreeFormMovement(this.Rigidbody2D, new KeyboardMovementInput());
            }




            this.Mobile = new Player(HealthBehaviour.MaxHealth, this.Speed, playerMovement);
            

            HealthBarCanvas.SetActive(true);
        }

        public override void Update()
        {
            base.Update();
            if (Input.GetKeyDown(KeyCode.Space))//if mobile can attack / timing is okey?
            {
                Attack();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Defend();
            }
        }



        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
    }
}