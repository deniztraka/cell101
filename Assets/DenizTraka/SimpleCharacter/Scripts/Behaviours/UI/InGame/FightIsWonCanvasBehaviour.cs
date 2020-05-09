using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.LevelSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightIsWonCanvasBehaviour : MonoBehaviour
{
    public Text EnemiesText;
    public Text DamageTakenText;
    public Text DamageGivenText;
    public Text CurrentFightText;
    public Text XPGainText;
    Level lastLevel;

    // Start is called before the first frame update
    void Start()
    {
        var fightManager = GameObject.Find("FightManager").GetComponent<LevelManager>();
        lastLevel = fightManager.GetCurrentLevel();
        InitScreen();
    }

    private void InitScreen()
    {
        EnemiesText.text = String.Format("Number of enemies killed: {0}", lastLevel.Enemies.Count);
        XPGainText.text = String.Format("Total number of XP gained in this fight: {0}", lastLevel.XPGain);//todo: get the xps gaiend from pvp
        CurrentFightText.text = String.Format("Fight {0}", PlayerPrefs.GetInt("CurrentFightIndex") - 1);
    }

    public void QuitButtonClicked()
    {
        SceneManager.LoadScene("CharacterScene", LoadSceneMode.Single);
    }
}
