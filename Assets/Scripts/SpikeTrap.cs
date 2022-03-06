using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public bool enabled = true;
    public float rechargeDelay = 3.0f;

    public int dmg = 5;

    private Color baseColor;

    public Player player;

    private void Start()
    {
        baseColor = this.GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (enabled)
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
            enabled = false;
            this.GetComponent<SpriteRenderer>().color = Color.grey;
            Invoke("toggledEnabled", rechargeDelay);
        }
    }

    private void toggledEnabled()
    {
        enabled = !enabled;
        this.GetComponent<SpriteRenderer>().color = baseColor;
    }
}
