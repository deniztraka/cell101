using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DTWorld.Engines.SkillSystem.Abillities
{
    public abstract class BaseAbillityEffect : MonoBehaviour
    {
        internal abstract void OnBeforeDestroy();
    }
}