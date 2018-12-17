using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterAtk : MonoBehaviour
{
    public GameObject[] traps;
    public GameObject projectile;
    public Transform player;
    public float damage;
    public float force;
    public float cooldown;
    public bool isAggro;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Shoot());
    }

    public void setAggro(bool aggro)
    {
        if (aggro && !isAggro)
        {
            StartCoroutine(Shoot());
        }
        else if (!aggro && isAggro)
        {
            StopCoroutine(Shoot());
        }
        isAggro = aggro;
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(cooldown);
        if (player != null && isAggro)
        {
            int whatatk = Random.Range(1, 3);
            if(whatatk < 3)
            {
                GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
                Vector2 dir = (Vector2)(player.position - transform.position).normalized;
                spell.GetComponent<Rigidbody2D>().velocity = dir * force;
                spell.GetComponent<Projectile>().damage = damage;
                spell.GetComponent<Projectile>().origin = gameObject;
                StartCoroutine(Shoot());
            } else
            {

            }
        }
    }
}
