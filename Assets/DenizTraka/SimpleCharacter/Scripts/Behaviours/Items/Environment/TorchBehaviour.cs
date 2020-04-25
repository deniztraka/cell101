using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;
namespace DTWorld.Behaviours.Items.Environment
{
    public class TorchBehaviour : MonoBehaviour
    {
        public Light2D Light;
        public float MaxIntensity;
        public float MinIntensity;
        public float frequency = .1f;
        public float timePassed = 0;
        void Start()
        {

        }

        // Update is called once per frame
        void LateUpdate()
        {
            if (timePassed > frequency)
            {
                timePassed = 0;
                Light.intensity = Random.Range(MinIntensity, MaxIntensity);
            }
            timePassed += Time.deltaTime;
        }
    }
}