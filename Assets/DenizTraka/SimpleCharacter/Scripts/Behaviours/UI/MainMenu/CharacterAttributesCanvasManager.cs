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

        public Text LevelText;
        public Text XpText;

        public GameObject StrPlusButton;
        public GameObject StrMinusButton;
        public GameObject DexPlusButton;
        public GameObject DexMinusButton;
        public MenuCharacterBehaviour menuCharacterBehaviour;
        private PropsBehaviour propsBehaviour;
        private MobileLevel mobileLevel;
        public CharacterBookBehaviour BookBehaviour;

        public void Start()
        {
            menuCharacterBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<MenuCharacterBehaviour>();
            propsBehaviour = menuCharacterBehaviour.GetComponent<PropsBehaviour>();
            mobileLevel = menuCharacterBehaviour.GetComponent<MobileLevel>();
            LevelText.text = String.Format("Level: {0}", mobileLevel.CurrentLevel);
            XpText.text = String.Format("Current Experience: {0} \n( Required xp for next level :{1})", mobileLevel.TotalExperienceGained, mobileLevel.GetRequiredExpAmountForNextLevel());
            StrengthValue.text = propsBehaviour.Strength.CurrentValue.ToString();
            DexterityValue.text = propsBehaviour.Dexterity.CurrentValue.ToString();
            MeleeValue.text = String.Format("{0:0.0}", propsBehaviour.Melee.CurrentValue);
            RangedValue.text = String.Format("{0:0.0}", propsBehaviour.Ranged.CurrentValue);
            TotalAttributePointsText.text = propsBehaviour.TotalAvaliableAttributePoints.ToString();
            if (propsBehaviour.TotalAvaliableAttributePoints <= 0)
            {
                StrPlusButton.SetActive(false);
                StrMinusButton.SetActive(false);
                DexPlusButton.SetActive(false);
                DexMinusButton.SetActive(false);
            }

            tempStr = propsBehaviour.Strength.CurrentValue;
            tempDex = propsBehaviour.Dexterity.CurrentValue;
            tempTotalAvaliableAttributePoints = propsBehaviour.TotalAvaliableAttributePoints;
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
            propsBehaviour.Strength.CurrentValue = tempStr;
            propsBehaviour.Dexterity.CurrentValue = tempDex;
            propsBehaviour.TotalAvaliableAttributePoints = tempTotalAvaliableAttributePoints;
            PlayerPrefs.SetInt("Strength", propsBehaviour.Strength.CurrentValue);
            PlayerPrefs.SetInt("Dexterity", propsBehaviour.Dexterity.CurrentValue);
            PlayerPrefs.SetInt("TotalAvaliableAttributePoints", propsBehaviour.TotalAvaliableAttributePoints);
            RecalculateBasicAttributesPanel();
            CloseBook();
        }

        public void ResetBasicPoints()
        {
            tempStr = propsBehaviour.Strength.CurrentValue;
            tempDex = propsBehaviour.Dexterity.CurrentValue;
            tempTotalAvaliableAttributePoints = propsBehaviour.TotalAvaliableAttributePoints;
            StrengthValue.text = propsBehaviour.Strength.CurrentValue.ToString();
            DexterityValue.text = propsBehaviour.Dexterity.CurrentValue.ToString();
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
            StrMinusButton.SetActive(tempStr > 0 && propsBehaviour.Strength.CurrentValue < tempStr);
            StrPlusButton.SetActive(tempTotalAvaliableAttributePoints > 0);
            DexMinusButton.SetActive(tempDex > 0 && propsBehaviour.Dexterity.CurrentValue < tempDex);
            DexPlusButton.SetActive(tempTotalAvaliableAttributePoints > 0);
        }
    }
}