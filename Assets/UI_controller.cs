using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_controller : MonoBehaviour
{

    public Text hpText;

    public string getHPText()
    {
        return hpText.text;
    }

    public void setHPText(string _hpText)
    {
        hpText.text = _hpText;
    }

}
