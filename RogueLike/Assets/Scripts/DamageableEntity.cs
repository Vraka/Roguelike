using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableEntity : MonoBehaviour {

    public float health;
    public float maxHealth;

	// Use this for initialization
	void Start () {
        health = maxHealth;
	}
	
	public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
    }

    public void Heal(float heal)
    {
        health += heal;
        CheckOverHeal();
    }

    private void CheckOverHeal()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void CheckDeath()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
