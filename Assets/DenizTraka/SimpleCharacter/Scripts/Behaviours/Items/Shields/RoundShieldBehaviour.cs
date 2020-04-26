using System.Collections;
using System.Collections.Generic;
using DTWorld.Core.Items.Shields;
using UnityEngine;

namespace DTWorld.Behaviours.Items.Shields
{
    public class RoundShieldBehaviour : BaseShieldBehaviour
    {
        public override void Awake()
        {
            base.Awake();
            Item = new RoundShield("RoundShield", DefendRate, SwingSpeed);
        }
    }
}