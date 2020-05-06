﻿using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Behaviours.Utils
{

    public class AppManager : MonoBehaviour
    {
        public static AppManager Instance { get; private set; }
        public bool IsRanged;
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

        public void SetIsRanged(bool val)
        {
            Debug.Log(val);
            IsRanged = val;
        }
    }
}
