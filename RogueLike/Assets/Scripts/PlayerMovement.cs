using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private Vector2 dir;
    private Animator animator;
    public bool canMove;

    void Start()
    {
        animator = GetComponent<Animator>();
        canMove = true;
    }

	void Update () {
        if(canMove)
        {
            TakeInput();
            Move();
        }
	}

    private void TakeInput()
    {
        dir = Vector2.zero;

        if(Input.GetKey(KeyCode.W))
        {
            dir += Vector2.up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dir += Vector2.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            dir += Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            dir += Vector2.right;
        }
    }

    private void Move()
    {
        transform.Translate(dir * speed * Time.deltaTime);
        animate();
    }

    private void animate()
    {
        animator.SetInteger("xDir", (int)dir.x);
        animator.SetInteger("yDir", (int)dir.y); 
    }
}
