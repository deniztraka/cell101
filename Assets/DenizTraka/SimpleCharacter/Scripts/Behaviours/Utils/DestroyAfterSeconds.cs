using UnityEngine;
namespace DTWorld.Behaviours.Utils
{
    public class DestroyAfterSeconds : MonoBehaviour
    {
        public float AfterSeconds = 1f;
        //public Vector3 offset = new Vector3(0, 2f, 0f);
        void Start()
        {
            //    transform.localPosition += offset;
            Destroy(gameObject, AfterSeconds);

        }
    }
}