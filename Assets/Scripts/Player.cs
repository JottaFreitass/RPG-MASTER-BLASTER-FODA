using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;

    Animator animator;

    SpriteRenderer SR;

    BoxCollider2D box;

    [SerializeField] [Range(1,10)] private int speed;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        rig = GetComponent<Rigidbody2D>();

        box = GetComponent<BoxCollider2D>();
        
        SR = GetComponent<SpriteRenderer>();

        transform.position = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if(Input.GetKeyDown("q"))
        {
            speed = speed * 2;
        }
        else if (Input.GetKeyUp("q"))
        {
            speed = 5;
        }

        rig.velocity= new Vector2(Input.GetAxis("Horizontal") * speed, rig.velocity.y);

        if (Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("idle", true);
            animator.SetBool("run", false);
        }

         if(Input.GetAxis("Horizontal") > 0)
        {
            SR.flipX = false;
            animator.SetBool("run", true);
        }

        if(Input.GetAxis("Horizontal") < 0)
        {
            SR.flipX = true;
            animator.SetBool("run", true);
        }

    }
}
