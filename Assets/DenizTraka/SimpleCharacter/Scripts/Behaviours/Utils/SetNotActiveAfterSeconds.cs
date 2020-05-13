using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DTWorld.Behaviours.Utils
{
    public class SetNotActiveAfterSeconds : MonoBehaviour
    {
        public float AfterSeconds = 3f;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SetStatusAfterTime());
        }

        // Update is called once per frame
        private IEnumerator SetStatusAfterTime(){

            yield return new WaitForSeconds(AfterSeconds);

            gameObject.SetActive(false);
        }
    }
}