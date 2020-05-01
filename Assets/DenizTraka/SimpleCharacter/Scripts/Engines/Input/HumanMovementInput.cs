using DTWorld.Behaviours.AI;
namespace DTWorld.Engines.Input
{
    public class HumanMovementInput : MobileMovementInput
    {
        public HumanMovementInput(AIMovementBehaviour aiBehaviour) : base(aiBehaviour)
        {
        }

        public override float GetXAxis()
        {
            return MobileAI.GetXAxis();
        }

        public override float GetYAxis()
        {
            return MobileAI.GetYAxis();
        }
    }
}