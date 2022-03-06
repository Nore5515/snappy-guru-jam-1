using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int HP = 10;
    public Slider hpBar;

    private void Start()
    {
        hpBar.maxValue = HP;
        hpBar.minValue = 0;
        hpBar.value = HP;
    }

    public void setHP(int _HP)
    {
        HP = _HP;
        hpBar.value = HP;
    }
    public int getHP()
    {
        return HP;
    }
}
