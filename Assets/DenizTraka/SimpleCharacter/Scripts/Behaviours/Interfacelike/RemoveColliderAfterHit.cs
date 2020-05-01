using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DTWorld.Behaviours.Interfacelike
{
    public class RemoveColliderAfterHit : MonoBehaviour
    {
        private Collider2D coll;
        // Start is called before the first frame update
        void Start()
        {
            coll = gameObject.GetComponent<Collider2D>();
        }     

        void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(coll);
        }   
    }
}