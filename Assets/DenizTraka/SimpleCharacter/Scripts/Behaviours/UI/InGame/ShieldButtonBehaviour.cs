using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
using UnityEngine.UI;

namespace DTWorld.Behaviours.UI.InGame
{
    public class ShieldButtonBehaviour : MonoBehaviour
    {
        private Button shieldButton;
        private PlayerBehaviour player;
        // Start is called before the first frame update
        void Start()
        {
            shieldButton = GetComponent<Button>();
            shieldButton.onClick.AddListener(OnClick);
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
            if (player.ShieldBehaviour == null)
            {
                gameObject.SetActive(false);
            }
        }

        public void OnClick()
        {
            player.Defend();
        }

    }
}