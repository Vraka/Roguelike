using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemySpell : MonoBehaviour {

    public GameObject projectile;
    public Transform player;
    public float damage;
    public float force;
    public float cooldown;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(cooldown);
        if(player != null) {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 dir = (Vector2)(player.position - transform.position).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = dir * force;
            spell.GetComponent<Projectile>().damage = damage;
            spell.GetComponent<Projectile>().origin = gameObject;
            StartCoroutine(Shoot());
        }
    }
}
