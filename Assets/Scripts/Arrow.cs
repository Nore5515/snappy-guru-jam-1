using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float m_Speed = 10f;   // this is the projectile's speed
    public float m_Lifespan = 3f; // this is the projectile's lifespan (in seconds)

    public int dmg = 4;

    public Player player;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.GetComponent<Enemy>() != null)
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
        Destroy(this.gameObject);
    }

    private void Update()
    {
        float step = m_Speed * Time.deltaTime; // calculate distance to move
        // transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
}
