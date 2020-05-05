using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DTWorld.Interfaces
{
    public interface ISkill
    {
        void Gain(float val);
        float GainFactor { get; set; }
        string Name { get; set; }
        float CurrentValue { get; set; }
    }
}