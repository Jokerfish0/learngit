using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public static Bird instance;
    Animator animator;
    Rigidbody2D rigidbody2D;
    //定义委托，添加死亡事件
    public delegate void BirdDied();
    public event BirdDied birdDied;

    public int grade=0;

    public bool isbegin;
    public float jumpSpeed;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.simulated = false;
    }

    
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetMouseButtonDown(0) && isbegin)
        {
            rigidbody2D.simulated = true;
            animator.SetTrigger("fly");
            rigidbody2D.AddForce(new Vector2(0, jumpSpeed));
        }
    }
    public void BeginGame()//开始游戏
    {
        isbegin = true;
        //rigidbody2D.simulated = true;
        //animator.SetTrigger("fall");
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dead();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       grade++;
       UIColl.instance.UpdateGrade(grade);
    }
    void Dead()
    {
        if(birdDied != null)
        {
            birdDied();
            Destroy(gameObject);
        }
    }
}
