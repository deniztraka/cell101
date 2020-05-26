using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Behaviours.Utils
{

    public class AppManager : MonoBehaviour
    {
        public static AppManager Instance { get; private set; }
        public bool IsRanged;

        public bool HasLeveledUp;


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PrepareRandomFightValues(){

        }
    }
}
