using Nevelson.Topdown2DPitfall.Assets.Scripts.Utils;
using UnityEngine;

public class Enemy : MonoBehaviour, IPitfallCheck, IPitfallObject
{
    public float speed = 4f;
    private Rigidbody2D rb;
    private bool isMovable = true;
    private Vector2 moveVelocity;

    public GameObject dest;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, dest.transform.position, step);

        // Check 
    }

    void FixedUpdate()
    {
        // rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void MovementInput(Vector2 moveInput)
    {
        // moveVelocity = moveInput.normalized * speed;
    }

    public bool PitfallConditionCheck()
    {
        return true;
    }

    public void PitfallActionsBefore()
    {
        isMovable = false;
    }

    public void PitfallResultingAfter()
    {
        isMovable = true;
    }
}
