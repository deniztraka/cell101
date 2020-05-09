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
        playerProps.OnAttributePointsGainedEvent += new PropsBehaviour.OnAttributePointsGainedEventHandler(AddAttributePointsGainedText);

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
}
