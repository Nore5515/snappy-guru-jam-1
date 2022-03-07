using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDetection : MonoBehaviour
{

    public Skeleton s;
    private GameObject nearestEnemy;
    private List<GameObject> detectedEnemies = new List<GameObject>();

    private void Update()
    {
        if (nearestEnemy != null)
        {
            s.MovetoTarget(nearestEnemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.GetComponent<Enemy>() != null)
        {
            detectedEnemies.Add(other.transform.parent.gameObject);
        }
        GetNearestEnemy();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.parent.GetComponent<Enemy>() != null)
        {
            detectedEnemies.Remove(other.transform.parent.gameObject);
        }
        GetNearestEnemy();
    }

    private GameObject GetNearestEnemy()
    {
        if (detectedEnemies.Count > 0)
        {

            nearestEnemy = detectedEnemies[0];
            foreach (GameObject enemy in detectedEnemies)
            {
                float nearestDistance = Vector3.Distance(nearestEnemy.transform.position, transform.position);
                float challengerDistance = Vector3.Distance(enemy.transform.position, transform.position);
                if (challengerDistance > nearestDistance)
                {
                    nearestEnemy = enemy;
                }
            }
        }
        else
        {
            nearestEnemy = null;
        }
        return nearestEnemy;
    }
}
