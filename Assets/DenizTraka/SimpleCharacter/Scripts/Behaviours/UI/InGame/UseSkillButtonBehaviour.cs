using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
using UnityEngine.UI;

public class UseSkillButtonBehaviour : MonoBehaviour
{
    private Button useSkillButton;
    private BaseMobileBehaviour mobile;
    // Start is called before the first frame update
    void Start()
    {
        useSkillButton = GetComponent<Button>();
        useSkillButton.onClick.AddListener(OnClick);
        mobile = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseMobileBehaviour>();
    }

    public void OnClick()
    {
        mobile.UseSkill();
    }
}
