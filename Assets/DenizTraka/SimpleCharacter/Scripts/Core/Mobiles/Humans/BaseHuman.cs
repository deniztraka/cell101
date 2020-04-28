using DTWorld.Interfaces;

namespace DTWorld.Core.Mobiles.Humans
{
    public abstract class BaseHuman : BaseMobile
    {
        public BaseHuman(float speed, IMovementType movementType) : base(speed, movementType)
        {
        }

        public BaseHuman(float speed) : base(speed)
        {
        }

    }
}