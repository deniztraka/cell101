using System.Collections;
using System.Collections.Generic;
using DTWorld.Interfaces;
namespace DTWorld.Engines.Input
{
    public class JoyStickMovementInput : IMovementInput
    {
        private Joystick joystick;

        public JoyStickMovementInput(Joystick joystick)
        {
            this.joystick = joystick;
        }

        public float GetXAxis()
        {            
            return joystick.Direction.x;
        }

        public float GetYAxis()
        {
            return joystick.Direction.y;
        }
    }
}