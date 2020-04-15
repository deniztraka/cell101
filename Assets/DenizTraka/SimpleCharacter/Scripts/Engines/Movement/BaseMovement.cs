using DTWorld.Engines.Input;
using DTWorld.Interfaces;
using UnityEngine;

namespace DTWorld.Engines.Movement
{
    public abstract class BaseMovement : IMovementType
    {
        #region Private Properties
        private Rigidbody2D rigidbody;
        private IMovementInput movementInput;
        #endregion

        #region Public Properties
        public Rigidbody2D Rigidbody
        {
            get { return rigidbody; }
            set { rigidbody = value; }
        }

        public IMovementInput MovemenetInput
        {
            get { return movementInput; }
            set { movementInput = value; }
        }
        #endregion

        #region Contructors
        public BaseMovement(Rigidbody2D rigidbody, IMovementInput movementInput)
        {
            this.rigidbody = rigidbody;
            this.movementInput = movementInput;
        }

        public BaseMovement(Rigidbody2D rigidbody)
        {
            this.rigidbody = rigidbody;
            this.movementInput = new KeyboardMovementInput();
        }
        #endregion

        public abstract Vector2 Move(float speed);
    }
}