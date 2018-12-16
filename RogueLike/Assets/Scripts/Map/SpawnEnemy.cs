using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public List<DamageableEntity> enemies;
    private EnemyTemplates templates;
    private RoomInfo room;

    public void Spawn(RoomInfo r)
    {
        room = r;
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<EnemyTemplates>();
        int numE = Random.Range(1, 4);
        for (int i = 0; i < numE; i++)
        {
            int xOffset = Random.Range(-1, 2);
            int yOffset = Random.Range(-1, 2);
            int rand = Random.Range(0, templates.enemies.Length);
            GameObject enemy = Instantiate(templates.enemies[rand], (Vector2)transform.position + new Vector2(xOffset, yOffset), Quaternion.identity);
            DamageableEntity de = enemy.GetComponent<DamageableEntity>();
            if (de != null)
            {
                de.spawnlist = this;
                enemies.Add(de);
            }
        }
    }

    public void Kill(DamageableEntity e)
    {
        if(enemies.Contains(e))
        {
            enemies.Remove(e);
            checkDestroy();
        }
    }

    public void checkDestroy()
    {
        if(enemies.Count == 0)
        {
            room.Clear();
        }
    }
}
