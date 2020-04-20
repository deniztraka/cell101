using System.Collections;
using System.Collections.Generic;
using DTWorld.Core.Mobiles.Humans;
using DTWorld.Interfaces;
using UnityEngine;
namespace DTWorld.Core.Mobiles.Humans.Bandits
{
    public class Bandit : BaseHuman
    {
        public Bandit(float speed, IMovementType movementType) : base(speed, movementType)
        {

        }
    }
}
