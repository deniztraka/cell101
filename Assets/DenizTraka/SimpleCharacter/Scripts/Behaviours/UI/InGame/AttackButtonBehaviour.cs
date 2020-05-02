using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
using UnityEngine.UI;

namespace DTWorld.Behaviours.UI.InGame
{
    public class AttackButtonBehaviour : MonoBehaviour
    {
        private Button attackButton;
        private PlayerBehaviour player;
        // Start is called before the first frame update
        void Start()
        {
            attackButton = GetComponent<Button>();
            attackButton.onClick.AddListener(OnClick);
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        }

        public void OnClick(){
            player.Attack();
        }

    }
}