using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{

    public Player player;

    public int dmg = 4;
    public GameObject arrow;    // this is a reference to your projectile prefab

    void Start()
    {
        InvokeRepeating("FireArrow", 1.0f, 1.0f);
    }

    void FireArrow()
    {
        Instantiate(arrow, this.transform.position, this.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.GetComponent<Enemy>().getHP() > dmg)
        {
            other.transform.parent.GetComponent<Enemy>().setHP(other.transform.parent.GetComponent<Enemy>().getHP() - dmg);
        }
        else
        {
            Destroy(other.transform.parent.gameObject);
            player.setSouls(player.getSouls() + 1);
            player.uicon.addKill();
        }
        Destroy(other.transform.parent.gameObject);
        Destroy(this.gameObject);
    }
}




