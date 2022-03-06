using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{

    public Player player;

    public int dmg = 3;

    public float speed = 1f;

    public void MovetoTarget(GameObject target)
    {
        // Only move if the position of the cube and sphere are far enough away.
        if (Vector3.Distance(transform.position, target.transform.position) >= 0.01f)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
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
    }
}
