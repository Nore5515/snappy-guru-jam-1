using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_controller : MonoBehaviour
{

    public Text hpText;
    public Text soulsText;
    public Text killsText;

    private int kills = 0;

    /// <summary>
    /// Test test test.
    /// </summary>
    public void setSoulsText(int souls)
    {
        soulsText.text = "Souls: " + souls;
    }

    public string getHPText()
    {
        return hpText.text;
    }

    public void setHPText(string _hpText)
    {
        hpText.text = _hpText;
    }

    public void addKill(){
        kills += 1;
        killsText.text = "Kills: " + kills;
    }

}
