
using DTWorld.Interfaces;
namespace DTWorld.Engines.Input
{
    using UnityEngine;
    public class KeyboardMovementInput : IMovementInput
    {
        public float GetXAxis()
        {
            return Input.GetAxis("Horizontal");
        }

        public float GetYAxis()
        {
            return Input.GetAxis("Vertical");
        }
    }
}

