using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DTWorld.Interfaces
{
    public interface IAttribute
    {
        void Gain(int val);
        string Name { get; set; }
        int CurrentValue { get; set; }
    }
}