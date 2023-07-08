using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyScriptableObjects", menuName = "ScriptableObjects/enemies")]

public class EnemyScriptable : ScriptableObject
{
    //base stats for enemies
    public float speed;
    public float maxHealth;
    public float dmg;
}
