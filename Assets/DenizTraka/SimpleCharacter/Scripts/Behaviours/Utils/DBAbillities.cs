using System.Collections;
using System.Collections.Generic;
using DTWorld.Engines.SkillSystem.Abillities;
using UnityEngine;
namespace DTWorld.Behaviours.Utils
{
    public class DBAbillities : MonoBehaviour
    {
        public static DBAbillities Instance { get; private set; }
        public List<BaseAbillity> Abillities;

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
    }
}