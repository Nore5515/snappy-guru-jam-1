using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy e;
    public bool isPath;

    public bool getIsPath()
    {
        return isPath;
    }
    public void setIsPath(bool _isPath)
    {
        isPath = _isPath;
    }

    // Called Once
    void Start()
    {
        InvokeRepeating("TrySpawnEnemy", 1.0f, 1.0f);
    }

    void TrySpawnEnemy()
    {
        if (isPath)
        {
            // Spawn Enemy
            Instantiate(e, this.transform.position, Quaternion.identity);
        }
    }

}
