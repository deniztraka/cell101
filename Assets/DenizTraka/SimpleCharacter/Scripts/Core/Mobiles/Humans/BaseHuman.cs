using DTWorld.Interfaces;

namespace DTWorld.Core.Mobiles.Humans
{
    public abstract class BaseHuman : BaseMobile
    {
        public BaseHuman(float health, float speed, IMovementType movementType) : base(health, speed, movementType)
        {
        }

        public BaseHuman(float speed) : base(speed)
        {
        }

    }
}