using DTWorld.Interfaces;

namespace DTWorld.Core.Mobiles.Humans
{
    public class Human : BaseMobile
    {
        public Human(float Speed, IMovementType movementType) : base(Speed, movementType)
        {
        }
    }
}