using UnityEngine;

namespace DTWorld.Interfaces
{
    public interface IMovementType
    {
        Rigidbody2D Rigidbody { set; }
        Vector2 Move(float speed);
    }
}

