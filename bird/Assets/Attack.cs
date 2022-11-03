using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Rigidbody2D rb;
    public float speedMove;
    public float speedJump;
    public bool isOnGroud;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

    }
    void Move()
    {
        float a = Input.GetAxis("Horizontal");
        //float b = Input.GetAxis("Vertical");
        if (a != 0 /*|| b != 0*/)
            transform.Translate(new Vector3(a * speedMove * Time.deltaTime, 0));
    }
    void Jump()
    {
        if (isOnGroud)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * speedJump);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "地面")
        {
            isOnGroud = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "地面")
        {
            isOnGroud = false;
        }

    }
}
