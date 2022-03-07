using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class Player : MonoBehaviour
{
    public float speed = 7f;
    private Rigidbody2D rb;
    private bool isMovable = true;
    private Vector2 moveVelocity;

    public int hp = 10;
    public int souls = 20;
    public UI_controller uicon;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isMovable)
        {
            MovementInput(Vector2.zero);
            return;
        }
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MovementInput(input);
    }

    private void MovementInput(Vector2 moveInput)
    {
        moveVelocity = moveInput.normalized * speed;
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

    public void setSouls(int _souls)
    {
        souls = _souls;
        uicon.setSoulsText(souls);
    }
    public int getSouls()
    {
        return souls;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.transform.parent.gameObject);
        hp -= 1;
        uicon.setHPText("HP: " + hp);
        if (hp <= 0)
        {
            StartCoroutine(LoadYourAsyncScene());
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Title");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
