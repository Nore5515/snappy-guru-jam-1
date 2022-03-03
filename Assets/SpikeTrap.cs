using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public bool enabled = true;
    public float rechargeDelay = 3.0f;

    private Color baseColor;

    private void Start()
    {
        baseColor = this.GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (enabled)
        {
            Destroy(other.transform.parent.gameObject);
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
