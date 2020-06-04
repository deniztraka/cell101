using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DTWorld.Behaviours.LevelSystem
{
     [CreateAssetMenu(fileName = "LevelList", menuName = "DTWorldz/LevelSystem/LevelList", order = 1)]
    public class LevelList : ScriptableObject
    {
        public List<Level> List;
    }
}