using DTWorld.Interfaces;
using UnityEngine;

namespace DTWorld.Engines.Movement
{
    public class FreeFormMovement : BaseMovement
    {
        #region Constructors
        public FreeFormMovement(Rigidbody2D rigidbody, IMovementInput movementInput) : base(rigidbody, movementInput)
        {
            
        }

        public FreeFormMovement(Rigidbody2D rigidbody) : base(rigidbody)
        {

        }
        #endregion
        public override Vector2 Move(float speed)
        {
            Vector2 currentPos = Rigidbody.position;

            float horizontalInput = MovemenetInput.GetXAxis();
            float verticalInput = MovemenetInput.GetYAxis();

            Vector2 inputVector = new Vector2(horizontalInput, verticalInput);

            Vector2 movement = inputVector * speed * 1f;
            Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
            Rigidbody.MovePosition(newPos);
            return movement;
        }
    }
}

