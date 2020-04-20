using DTWorld.Interfaces;

namespace DTWorld.Core.Mobiles.Humans
{
    public abstract class BaseHuman : BaseMobile
    {
        public BaseHuman(float Speed, IMovementType movementType) : base(Speed, movementType)
        {
        }
    }
}