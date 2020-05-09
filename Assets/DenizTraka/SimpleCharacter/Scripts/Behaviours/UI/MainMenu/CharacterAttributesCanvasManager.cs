using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.AI;
using DTWorld.Behaviours.Interfacelike;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
using UnityEngine.UI;

namespace DTWorld.Behaviours.UI.CharacterSelectionMenu
{

    public class CharacterAttributesCanvasManager : MonoBehaviour
    {
        //private bool isChanged;
        private int tempTotalAvaliableAttributePoints;
        private int tempStr;
        private int tempDex;
        public Text StrengthValue;
        public Text DexterityValue;
        public Text MeleeValue;
        public Text RangedValue;
        public Text TotalAttributePointsText;

        public GameObject StrPlusButton;
        public GameObject StrMinusButton;
        public GameObject DexPlusButton;
        public GameObject DexMinusButton;
        public MenuCharacterBehaviour menuCharacterBehaviour;
        private PropsBehaviour PropsBehaviour;
        public CharacterBookBehaviour BookBehaviour;

        public void Start()
        {
            menuCharacterBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<MenuCharacterBehaviour>();
            PropsBehaviour = menuCharacterBehaviour.GetComponent<PropsBehaviour>();
            StrengthValue.text = PropsBehaviour.Strength.CurrentValue.ToString();
            DexterityValue.text = PropsBehaviour.Dexterity.CurrentValue.ToString();
            MeleeValue.text = String.Format("{0:0.0}", PropsBehaviour.Melee.CurrentValue);
            RangedValue.text = String.Format("{0:0.0}", PropsBehaviour.Ranged.CurrentValue);
            TotalAttributePointsText.text = PropsBehaviour.TotalAvaliableAttributePoints.ToString();
            if (PropsBehaviour.TotalAvaliableAttributePoints <= 0)
            {
                StrPlusButton.SetActive(false);
                StrMinusButton.SetActive(false);
                DexPlusButton.SetActive(false);
                DexMinusButton.SetActive(false);
            }

            tempStr = PropsBehaviour.Strength.CurrentValue;
            tempDex = PropsBehaviour.Dexterity.CurrentValue;
            tempTotalAvaliableAttributePoints = PropsBehaviour.TotalAvaliableAttributePoints;
            RecalculateBasicAttributesPanel();
            //isChanged = false;
        }
        public void CloseBook()
        {
            BookBehaviour.SetIsOpen(false);
            gameObject.SetActive(false);
        }

        public void SaveBasicPoints()
        {
            PropsBehaviour.Strength.CurrentValue = tempStr;
            PropsBehaviour.Dexterity.CurrentValue = tempDex;
            PropsBehaviour.TotalAvaliableAttributePoints = tempTotalAvaliableAttributePoints;
            PlayerPrefs.SetInt("Strength", PropsBehaviour.Strength.CurrentValue);
            PlayerPrefs.SetInt("Dexterity", PropsBehaviour.Dexterity.CurrentValue);
            PlayerPrefs.SetInt("TotalAvaliableAttributePoints", PropsBehaviour.TotalAvaliableAttributePoints);
            RecalculateBasicAttributesPanel();
            CloseBook();
        }

        public void ResetBasicPoints()
        {
            tempStr = PropsBehaviour.Strength.CurrentValue;
            tempDex = PropsBehaviour.Dexterity.CurrentValue;
            tempTotalAvaliableAttributePoints = PropsBehaviour.TotalAvaliableAttributePoints;
            StrengthValue.text = PropsBehaviour.Strength.CurrentValue.ToString();
            DexterityValue.text = PropsBehaviour.Dexterity.CurrentValue.ToString();
            RecalculateBasicAttributesPanel();
        }

        public void PlusStr()
        {
            tempStr++;
            StrengthValue.text = tempStr.ToString();
            tempTotalAvaliableAttributePoints--;
            RecalculateBasicAttributesPanel();
        }

        public void MinusStr()
        {
            tempStr--;
            StrengthValue.text = tempStr.ToString();
            tempTotalAvaliableAttributePoints++;
            RecalculateBasicAttributesPanel();
        }

        public void PlusDex()
        {
            tempDex++;
            DexterityValue.text = tempDex.ToString();
            tempTotalAvaliableAttributePoints--;
            RecalculateBasicAttributesPanel();
        }

        public void MinusDex()
        {
            tempDex--;
            DexterityValue.text = tempDex.ToString();
            tempTotalAvaliableAttributePoints++;
            RecalculateBasicAttributesPanel();
        }

        public void RecalculateBasicAttributesPanel()
        {
            TotalAttributePointsText.text = tempTotalAvaliableAttributePoints.ToString();
            StrMinusButton.SetActive(tempStr > 0 && PropsBehaviour.Strength.CurrentValue < tempStr);
            StrPlusButton.SetActive(tempTotalAvaliableAttributePoints > 0);
            DexMinusButton.SetActive(tempDex > 0 && PropsBehaviour.Dexterity.CurrentValue < tempDex);
            DexPlusButton.SetActive(tempTotalAvaliableAttributePoints > 0);
        }
    }
}