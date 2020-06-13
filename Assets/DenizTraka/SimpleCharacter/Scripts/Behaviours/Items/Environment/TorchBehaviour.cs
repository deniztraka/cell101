using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;
namespace DTWorld.Behaviours.Items.Environment
{
    [ExecuteInEditMode]
    public class TorchBehaviour : MonoBehaviour
    {
        public Light2D Light;
        public float MaxIntensity;
        public float MinIntensity;
        public float Frequency = .1f;
        private float timePassed = 0;
        public float yOffset;
        private Transform child;
        void Start()
        {
            child = transform.GetChild(0);
            child.transform.parent = transform;

        }

        void Update()
        {
            child.transform.localPosition = new Vector2(0, yOffset);
        }

        // Update is called once per frame
        void LateUpdate()
        {
            if (timePassed > Frequency)
            {
                timePassed = 0;
                Light.intensity = Random.Range(MinIntensity, MaxIntensity);
            }
            timePassed += Time.deltaTime;
        }
    }
}