using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb = default;
    [SerializeField] float speed;
    bool isGrounded = true;
    public int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D)) rb.AddForce(new Vector2(speed, rb.velocity.y));
        if (Input.GetKey(KeyCode.A)) rb.AddForce(new Vector2(-speed, rb.velocity.y));
        if (Input.GetKey(KeyCode.Space))
        {
            if(isGrounded == true) rb.AddForce(new Vector2(0, speed * 35.0f));
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void addScore(int score)
    {
        this.score += score;
    }
}
