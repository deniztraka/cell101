using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTWorld.Engines.AI.States
{
    public interface IMobileState
    {
        void OnStateEnter();
        BaseMobileState OnStateUpdate();
        void OnStateExit();
        float GetXAxis();
        float GetYAxis();
    }
}