using System.Collections.Generic;
using UnityEngine;

public class EMPbehaviour : MeleeBehaviour
{
    List<GameObject> markedEnemies;
    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && !markedEnemies.Contains(col.gameObject))
        {
            EnemiesStats enemy = col.GetComponent<EnemiesStats>();
            enemy.TakeDmg(currentDmg);

            markedEnemies.Add(col.gameObject);//Mark the enemy so it doesn't take another dmg instance from this melee.
        }
        else if (col.CompareTag("Prop"))
        {
            if (col.gameObject.TryGetComponent(out BreakableProps breakable) && !markedEnemies.Contains(col.gameObject))
            {
                breakable.TakeDmg(currentDmg);

                markedEnemies.Add(col.gameObject);
            }
        }
    }
}
