using DTWorld.Core.Mobiles.Humans;
using DTWorld.Interfaces;

namespace DTWorld.Core.Mobiles
{
    public class Player : Human
    {
        public Player(float speed, IMovementType movementType) : base(speed, movementType)
        {
        }
    }
}