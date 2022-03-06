using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 10;

    public void setHP(int _HP)
    {
        HP = _HP;
    }
    public int getHP()
    {
        return HP;
    }
}
