using System.Collections;
using System.Collections.Generic;
using DTWorld.Core.Items;
using UnityEngine;
namespace DTWorld.Behaviours.Items
{
    public abstract class BaseItemBehaviour : MonoBehaviour
    {
        public string Name;

        public BaseItem Item;

        public virtual void Awake()
        {
            
        }

        // Start is called before the first frame update
        public virtual void Start()
        {
            
        }
        

        // Update is called once per frame
        public virtual void Update()
        {

        }
    }
}