using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.AI;
using DTWorld.Behaviours.Mobiles.Human;
using DTWorld.Core.Mobiles;
using DTWorld.Engines.Movement;
using UnityEngine;
namespace DTWorld.Behaviours.Mobiles
{
    public class MenuCharacterBehaviour : HumanBehaviour
    {
        public override void Start()
        {
            base.Start();
            this.Mobile = new Player(this.Speed, new FreeFormMovement(Rigidbody2D, GetComponent<CharacterScreenMovementBehaviour>()));
        }
    }
}