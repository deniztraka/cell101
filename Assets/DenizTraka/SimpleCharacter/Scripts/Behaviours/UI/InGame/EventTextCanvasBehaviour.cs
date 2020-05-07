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

    public void Start()
    {
        playerProps = GameObject.FindGameObjectWithTag("Player").GetComponent<PropsBehaviour>();
        playerProps.Ranged.OnSkillChangedEvent += new DTWorld.Engines.SkillSystem.Skills.BaseSkill.OnSkillChangedEventHandler(RangedSkillChanged);
        playerProps.Melee.OnSkillChangedEvent += new DTWorld.Engines.SkillSystem.Skills.BaseSkill.OnSkillChangedEventHandler(MeleeSkillChanged);

    }

    public void AddEventText(string text)
    {
        var eventTextGameObject = Instantiate(EventTextPrefab, Vector3.zero, Quaternion.identity, WrapperPanel);
        var eventText = eventTextGameObject.GetComponent<Text>();
        eventText.text = text;
    }

    private void AddSkillChangedText(string skillName, float gainedVal)
    {
        AddEventText(skillName + " skill is increased by " + gainedVal.ToString());
    }

    private void RangedSkillChanged(float gainedVal)
    {
        AddSkillChangedText("Ranged", gainedVal);
    }

    private void MeleeSkillChanged(float gainedVal)
    {
        AddSkillChangedText("Melee", gainedVal);
    }
}
