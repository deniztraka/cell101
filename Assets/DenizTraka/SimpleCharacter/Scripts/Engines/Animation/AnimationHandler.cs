using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTWorld.Engines.Animation
{
    public class AnimationHandler
    {
        protected static readonly string[] idleAnimations = { "HumanIdleEast", "HumanIdleNorth", "HumanIdleWest", "HumanIdleSouth" };
        protected static readonly string[] walkingAnimations = { "HumanWalkingEast", "HumanWalkingNorth", "HumanWalkingWest", "HumanWalkingSouth" };
        protected static readonly string[] attackingAnimations = { "HumanAttackingEast", "HumanAttackingNorth", "HumanAttackingWest", "HumanAttackingSouth" };
        private Animator animator;
        private int lastDirection;
        private string lastAnimationName = "";

        public AnimationHandler(Animator animator)
        {
            this.animator = animator;
        }

        public void SetCurrentAnimationSpeedMultiplier(float speed){
            this.animator.SetFloat("SpeedMultiplier", speed);
        }

        public int SetCurrentAnimation(Vector2 direction, bool isAttacking)
        {
            //use the Run states by default
            string[] directionArray = null;

            if (isAttacking)
            {
                directionArray = attackingAnimations;
            }
            else
            //measure the magnitude of the input.
            if (direction.magnitude < .01f)
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

                lastDirection = DirectionToIndex(direction, 4);
            }

            //tell the animator to play the requested state
            var animationName = directionArray[lastDirection];


            if (lastAnimationName == animationName)
            {
                return lastDirection;
            }

            //play base character animation
            animator.Play(animationName, -1, 0);
            //SetHandleSortIndex(lastDirection);
            lastAnimationName = animationName;
            return lastDirection;
        }

        //helper functions

        protected virtual void SetHandleSortIndex(int directionIndex)
        {

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

