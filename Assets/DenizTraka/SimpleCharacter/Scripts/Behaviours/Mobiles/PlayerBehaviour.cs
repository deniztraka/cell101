﻿using System;
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

        public override void Start()
        {
            base.Start();
            IMovementType playerMovement = null;

            var joyStickObj = GameObject.FindGameObjectWithTag("Joystick");
            if (joyStickObj != null)
            {
                var joyStick = joyStickObj.GetComponent<Joystick>();
                playerMovement = new FreeFormMovement(this.Rigidbody2D, new JoyStickMovementInput(joyStick));
            }
            else
            {
                playerMovement = new FreeFormMovement(this.Rigidbody2D, new KeyboardMovementInput());
            }

            //playerMovement = new FreeFormMovement(this.Rigidbody2D, new KeyboardMovementInput());

            this.Mobile = new Player(this.Speed, playerMovement);
        }

        public override void Update()
        {
            base.Update();
            if (Input.GetKeyDown(KeyCode.Space))//if mobile can attack / timing is okey?
            {
                Attack();
            } else if (Input.GetKeyDown(KeyCode.E)){
                Defend();
            }
        }

        

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
    }
}