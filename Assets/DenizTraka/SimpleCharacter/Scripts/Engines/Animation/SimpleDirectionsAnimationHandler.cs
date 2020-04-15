using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace DTWorld.Engines.Animation
{
    public class SimpleDirectionsAnimationHandler : AnimationHandler
    {
        SortingGroup rightHandleSortingGroup;
        SortingGroup leftHandleSortingGroup;
        public SimpleDirectionsAnimationHandler(Animator animator) : base(animator)
        {

        }

        public SimpleDirectionsAnimationHandler(Animator animator, GameObject rightHandle, GameObject leftHandle) : base(animator)
        {

            this.rightHandleSortingGroup = rightHandle.GetComponent<SortingGroup>();
            this.leftHandleSortingGroup = leftHandle.GetComponent<SortingGroup>();
        }

        protected override int DirectionToIndex(Vector2 dir, int sliceCount)
        {
            if (dir.x > 0)
            {
                return 0;
            }
            else if (dir.x < 0)
            {
                return 2;
            }
            else if (dir.x == 0 && dir.y < 0)
            {
                return 3;
            }
            else if (dir.x == 0 && dir.y > 0)
            {
                return 1;
            }
            return -1;
        }

        protected override void SetHandleSortIndex(int directionIndex)
        {            
            if (rightHandleSortingGroup != null && leftHandleSortingGroup != null)
            {
                if (directionIndex == 0)
                {
                    rightHandleSortingGroup.sortingOrder = 3;
                    leftHandleSortingGroup.sortingOrder = -1;
                }
                else if (directionIndex == 2)
                {
                    rightHandleSortingGroup.sortingOrder = -1;
                    leftHandleSortingGroup.sortingOrder = 3;
                }
                else if (directionIndex == 3)
                {
                    rightHandleSortingGroup.sortingOrder = 3;
                    leftHandleSortingGroup.sortingOrder = 3;
                }
                else if (directionIndex == 1)
                {
                    rightHandleSortingGroup.sortingOrder = -1;
                    leftHandleSortingGroup.sortingOrder = -1;
                }
            }
        }
    }
}
