using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Items.Ammo;
using UnityEngine;

namespace DTWorld.Behaviours.Items.Weapons.Ranged
{
    public class BaseRangedWeaponBehaviour : BaseWeaponBehaviour
    {
        private Queue<GameObject> ammoList;
        public float AmmoSpeed = 100f;
        public int AmmoCount;
        public GameObject Ammo;
        public override void Start()
        {
            base.Start();
            IsRanged = true;
            PrepareAmmoPool();
        }

        private void PrepareAmmoPool()
        {
            ammoList = new Queue<GameObject>();
            for (int i = 0; i < 50; i++)
            {
                var ammo = Instantiate(Ammo).GetComponent<BaseAmmoBehaviour>();
                //var ammo = instantiatedAmmo
                ammo.OwnerWeaponBehaviour = this;
                ammo.gameObject.SetActive(false);
                ammoList.Enqueue(ammo.gameObject);
            }
        }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            //ranged weapon attackes does not collide
            return;
        }

        public override void Attack(float swingRate)
        {
            StartCoroutine(ExecuteAfterTime(swingRate, () =>
            {
                Shoot();
            }));
        }

        public void Shoot()
        {
            if (AmmoCount > 0)
            {
                //Debug.Log("Swing");
                AudioManager.Play("Swing");

                var dequedObject = ammoList.Dequeue();
                dequedObject.SetActive(true);
                dequedObject.transform.position = transform.position;
                dequedObject.transform.eulerAngles = new Vector3(0, 0, GetRotation());//Quaternion.Angle()
                var ammoRigidBody = dequedObject.GetComponent<Rigidbody2D>();
                ammoRigidBody.AddForce(GetDirection() * AmmoSpeed);
                ammoList.Enqueue(dequedObject);

                AmmoCount--;
            }
        }

        private float GetRotation()
        {
            float z = 0f;
            switch (OwnerMobileBehaviour.GetLastDirectionIndex())
            {
                case 0:
                    //Debug.Log("asd");
                    z = -90f;
                    break;
                case 1:
                    z = 0f;
                    break;
                case 2:
                    z = 90f;
                    break;
                case 3:
                    z = 180f;
                    break;
            }

            return z;
        }

        private Vector2 GetDirection()
        {
            switch (OwnerMobileBehaviour.GetLastDirectionIndex())
            {
                case 0:
                    return Vector2.right;
                case 1:
                    return Vector2.up;
                case 2:
                    return Vector2.left;
                case 3:
                    return Vector2.down;
            }
            return Vector2.right;
        }
    }
}