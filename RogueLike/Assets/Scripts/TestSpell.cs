using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour {

    public GameObject projectile;
    public float damage;
    public float force;
    public float delay;
    private float timer;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        if(timer > 0)
        {
            timer--;
        }

        if(Input.GetMouseButton(0) && timer == 0)
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = (mousepos - (Vector2)transform.position).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = dir * force;
            spell.GetComponent<Projectile>().damage = damage;
            spell.GetComponent<Projectile>().origin = gameObject;
            timer = delay;
        }
    }
}
