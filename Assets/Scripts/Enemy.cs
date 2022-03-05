using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4f;
    private Rigidbody2D rb;
    private bool isMovable = true;
    private Vector2 moveVelocity;

    // public GameObject dest;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
