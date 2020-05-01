using DTWorld.Behaviours.AI;
using DTWorld.Interfaces;
namespace DTWorld.Engines.Input
{
    public abstract class MobileMovementInput : IMovementInput
    {
        protected AIMovementBehaviour MobileAI { get; set; }
        public MobileMovementInput(AIMovementBehaviour mobileAI)
        {
            MobileAI = mobileAI;
        }
        public abstract float GetXAxis();

        public abstract float GetYAxis();        
    }
}