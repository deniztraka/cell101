using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Behaviours.Utils
{
    public class AppManager : MonoBehaviour
    {
        private bool isRanged;
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public bool IsRanged()
        {
            return isRanged;
        }

        public void SetIsRanged(bool val)
        {
            isRanged = val;
        }
    }
}
