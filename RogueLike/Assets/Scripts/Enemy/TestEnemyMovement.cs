using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyMovement : MonoBehaviour {

    public int aggro_dist;
    public int stop_dist;
    public float speed;
    private Vector2 dir;
    private Animator animator;

    public TestEnemySpell spell;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

        spell = gameObject.GetComponent<TestEnemySpell>();
        spell.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float dist = Vector2.Distance(player.transform.position, transform.position);
        if (dist < aggro_dist)
        {
            spell.setAggro(true);
            if(dist > stop_dist)
            {
                dir = (Vector2)(player.transform.position - transform.position).normalized;
            } else
            {
                dir = Vector2.zero;
            }
            Move();
        } else
        {
            spell.setAggro(false);
            dir = Vector2.zero;
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(dir * speed * Time.deltaTime);
        animate();
    }

    private void animate()
    {
        int dirx = 0;
        int diry = 0;
        if(dir.x > 0)
        {
            dirx = Mathf.CeilToInt(dir.x);
        } else
        {
            dirx = Mathf.FloorToInt(dir.x);
        }

        if (dir.y > 0)
        {
            diry = Mathf.CeilToInt(dir.y);
        }
        else
        {
            diry = Mathf.FloorToInt(dir.y);
        }

        if(Mathf.Abs(dir.x) < 0.1)
        {
            dirx = 0;
        }

        if(Mathf.Abs(dir.y) < 0.1)
        {
            diry = 0;
        }
        animator.SetInteger("xDir", dirx);
        animator.SetInteger("yDir", diry);
    }
}
