using DTWorld.Core.Mobiles.Humans;
using DTWorld.Interfaces;

namespace DTWorld.Core.Mobiles
{
    public class Player : BaseHuman
    {
        public Player(float health, float speed, IMovementType movementType) : base(health, speed, movementType)
        {
        }
    }
}