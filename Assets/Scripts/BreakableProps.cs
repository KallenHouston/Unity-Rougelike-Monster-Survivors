using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableProps : MonoBehaviour
{
    public float health;

    public void TakeDmg(float dmg)
    {
        health -= dmg;
        
        if(health <= 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
