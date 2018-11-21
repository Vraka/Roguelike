using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float damage;
    public GameObject origin;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject != origin && collision.tag != "projectile")
        {
            if(collision.tag == "Player" && PlayerStats.instance != null)
            {
                PlayerStats.instance.DealDamage(damage);
            } else if(collision.GetComponent<DamageableEntity>() != null)
            {
                collision.GetComponent<DamageableEntity>().DealDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
