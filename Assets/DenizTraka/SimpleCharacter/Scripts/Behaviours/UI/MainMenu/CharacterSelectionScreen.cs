using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.AI;
using DTWorld.Behaviours.Mobiles;
using DTWorld.Behaviours.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DTWorld.Behaviours.UI.CharacterSelectionMenu
{
    public class CharacterSelectionScreen : MonoBehaviour
    {
        public BaseMobileBehaviour Archer;
        public BaseMobileBehaviour Melee;
        public GameObject SelectedPosition;
        public GameObject ArcherPosition;
        public GameObject MeleePosition;

        private Rigidbody2D SelectedRigidBody;
        private Rigidbody2D meleeRigidBody;
        private Rigidbody2D archerRigidBody;
        private bool isArcherSelected;
        private bool isMeleeSelected;

        void Start()
        {
            Archer.SetParalyzed(true);
            Melee.SetParalyzed(true);

            archerRigidBody = Archer.GetComponent<Rigidbody2D>();
            meleeRigidBody = Melee.GetComponent<Rigidbody2D>();

            meleeRigidBody.MovePosition(MeleePosition.transform.position);
            archerRigidBody.MovePosition(ArcherPosition.transform.position);
        }

        public void StartGame()
        {
            var appManager = GameObject.FindGameObjectWithTag("AppManager").GetComponent<AppManager>();
            appManager.SetSelectedCharacter(SelectedRigidBody.gameObject.GetComponent<BaseMobileBehaviour>());
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);            
        }

        public void Back()
        {
            SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
        }

        public void FixedUpdate()
        {
            if (SelectedRigidBody != null)
            {
                if (isArcherSelected)
                {
                    meleeRigidBody.MovePosition(MeleePosition.transform.position);
                    archerRigidBody.MovePosition(SelectedPosition.transform.position);
                }
                else

                if (isMeleeSelected)
                {
                    archerRigidBody.MovePosition(ArcherPosition.transform.position);
                    meleeRigidBody.MovePosition(SelectedPosition.transform.position);
                }
            }


        }

        public void ArcherSelected()
        {
            SelectedRigidBody = archerRigidBody;
            isMeleeSelected = false;
            isArcherSelected = true;
        }

        public void MeleeSelected()
        {
            SelectedRigidBody = meleeRigidBody;
            isMeleeSelected = true;
            isArcherSelected = false;
        }
    }
}
