using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTWorld.Behaviours.UI
{

    public class FloatingDamageTextBehaviour : MonoBehaviour
    {
        public float DestroyAfterSeconds = 1f;
        //public Vector3 offset = new Vector3(0, 2f, 0f);
        void Start()
        {
        //    transform.localPosition += offset;
            Destroy(gameObject, DestroyAfterSeconds);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}