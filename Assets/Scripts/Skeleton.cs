using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{

    public Player player;

    public int dmg = 3;

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
    }
}
