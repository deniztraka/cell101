using System.Collections;
using System.Collections.Generic;
using DTWorld.Core.Mobiles;
using UnityEngine;

namespace DTWorld.Engines.Animation
{
    public class AnimationHandler
    {
        protected static readonly string[] idleAnimations = { "HumanIdleEast", "HumanIdleNorth", "HumanIdleWest", "HumanIdleSouth" };
        protected static readonly string[] walkingAnimations = { "HumanWalkingEast", "HumanWalkingNorth", "HumanWalkingWest", "HumanWalkingSouth" };
        protected static readonly string[] attackingAnimations = { "HumanAttackingEast", "HumanAttackingNorth", "HumanAttackingWest", "HumanAttackingSouth" };
        protected static readonly string[] defendingAnimations = { "HumanDefendEast", "HumanDefendNorth", "HumanDefendWest", "HumanDefendSouth" };
        protected static readonly string[] deadAnimations = { "HumanDeadEast", "HumanDeadNorth", "HumanDeadWest", "HumanDeadSouth" };
        private Animator animator;
        private int lastDirectionIndex;
        private string lastAnimationName = "";

        private Vector2 lastDirection;

        public AnimationHandler(Animator animator)
        {
            this.animator = animator;
        }

        public void SetCurrentAnimationSpeedMultiplier(float speed)
        {
            //Debug.Log(Mathf.(speed));
            this.animator.SetFloat("SpeedMultiplier", speed / 2);
            //this.animator.speed = speed;
        }

        public int SetCurrentAnimation(Vector2 direction, BaseMobile mobile)
        {
            //use the Run states by default
            string[] directionArray = null;

            if (mobile.IsAttacking)
            {
                directionArray = attackingAnimations;
            }
            else if (mobile.IsDefending)
            {
                directionArray = defendingAnimations;
            }
            else if (direction.magnitude < .01f)   //measure the magnitude of the input.
            {
                //if we are basically standing still, we'll use the Static states
                //we won't be able to calculate a direction if the user isn't pressing one, anyway!
                directionArray = idleAnimations;
            }
            else
            {
                //we can calculate which direction we are going in
                //use DirectionToIndex to get the index of the slice from the direction vector
                //save the answer to lastDirection
                directionArray = walkingAnimations;

                lastDirectionIndex = DirectionToIndex(direction, 4);
            }            
            if (mobile.Health <= 0)
            {
                directionArray = deadAnimations;
            }

            //tell the animator to play the requested state
            var animationName = directionArray[lastDirectionIndex];

            if (lastAnimationName == animationName)
            {
                return lastDirectionIndex;
            }

            lastDirection = direction;
            //play base character animation            
            animator.Play(animationName, -1, 0);
            SetHandleSortIndex(lastDirectionIndex, mobile.IsAttacking);
            lastAnimationName = animationName;
            return lastDirectionIndex;
        }

        //helper functions

        protected virtual void SetHandleSortIndex(int directionIndex, bool isAttacking)
        {

        }

        public void SetLastDirection(Vector2 lastDirection)
        {
            this.lastDirection = lastDirection;
        }

        public Vector2 GetLastDirection()
        {
            return lastDirection;
        }

        //this function converts a Vector2 direction to an index to a slice around a circle
        //this goes in a counter-clockwise direction.
        protected virtual int DirectionToIndex(Vector2 dir, int sliceCount)
        {
            //get the normalized direction
            Vector2 normDir = dir.normalized;
            //calculate how many degrees one slice is
            float step = 360f / sliceCount;
            //calculate how many degress half a slice is.
            //we need this to offset the pie, so that the North (UP) slice is aligned in the center
            float halfstep = step / 2;
            //get the angle from -180 to 180 of the direction vector relative to the Up vector.
            //this will return the angle between dir and North.
            float angle = Vector2.SignedAngle(Vector2.up, normDir);
            //add the halfslice offset
            angle += halfstep;
            //if angle is negative, then let's make it positive by adding 360 to wrap it around.
            if (angle < 0)
            {
                angle += 360;
            }
            //calculate the amount of steps required to reach this angle
            float stepCount = angle / step;
            //round it, and we have the answer!
            //we are adding 1 to make it same as ultima online map
            var result = Mathf.FloorToInt(stepCount + 1);
            if (result == sliceCount)
            {
                result = 0;
            }
            return result;
        }

        // //this function converts a string array to a int (animator hash) array.
        // public static int[] AnimatorStringArrayToHashArray(string[] animationArray)
        // {
        //     //allocate the same array length for our hash array
        //     int[] hashArray = new int[animationArray.Length];
        //     //loop through the string array
        //     for (int i = 0; i < animationArray.Length; i++)
        //     {
        //         //do the hash and save it to our hash array
        //         hashArray[i] = Animator.StringToHash(animationArray[i]);
        //     }
        //     //we're done!
        //     return hashArray;
        // }
    }
}

