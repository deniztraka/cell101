using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Interfacelike;
using UnityEngine;
using UnityEngine.UI;

public class EventTextCanvasBehaviour : MonoBehaviour
{
    public GameObject EventTextPrefab;
    public Transform WrapperPanel;

    private PropsBehaviour playerProps;
    private MobileLevel playerLevel;

    public void Start()
    {
        var playerObj = GameObject.FindGameObjectWithTag("Player");
        playerProps = playerObj.GetComponent<PropsBehaviour>();
        playerProps.Ranged.OnSkillChangedEvent += new DTWorld.Engines.SkillSystem.Skills.BaseSkill.OnSkillChangedEventHandler(RangedSkillChanged);
        playerProps.Melee.OnSkillChangedEvent += new DTWorld.Engines.SkillSystem.Skills.BaseSkill.OnSkillChangedEventHandler(MeleeSkillChanged);
        playerProps.OnAttributePointsGainedEvent += new PropsBehaviour.OnAttributePointsGainedEventHandler(AddAttributePointsGainedText);

        playerLevel = playerObj.GetComponent<MobileLevel>();
        playerLevel.OnLevelChangedEvent += new MobileLevel.OnLevelChangedEventHandler(OnLevelChanged);
        playerLevel.OnExperienceGainedEvent += new MobileLevel.OnExperienceGainedEventHandler(OnXPGained);
    }

    

    public void AddEventText(string text, Color color)
    {
        var eventTextGameObject = Instantiate(EventTextPrefab, Vector3.zero, Quaternion.identity, WrapperPanel);
        var eventText = eventTextGameObject.GetComponent<Text>();
        eventText.text = text;
        eventText.color = color;
    }

    private void AddSkillChangedText(string skillName, float gainedVal)
    {
        AddEventText(skillName + " skill is increased by " + gainedVal.ToString(), Color.yellow);
    }

    private void AddAttributePointsGainedText()
    {
        AddEventText("Attribute points gained +1", Color.green);
    }

    private void RangedSkillChanged(float gainedVal)
    {
        AddSkillChangedText("Ranged", gainedVal);
    }

    private void MeleeSkillChanged(float gainedVal)
    {
        AddSkillChangedText("Melee", gainedVal);
    }

     private void OnLevelChanged(int earnedAttrPoints, int currentLevel)
    {
        AddLevelChangedText(currentLevel);
    }

    private void AddLevelChangedText(int currentLevel)
    {
        AddEventText(String.Format("You just leveled up to {0}", currentLevel), Color.magenta);
    }

    private void OnXPGained(int val, int currentLevel)
    {
        AddEventText(String.Format("You gained {0} xp", val), Color.gray);
    }
}
