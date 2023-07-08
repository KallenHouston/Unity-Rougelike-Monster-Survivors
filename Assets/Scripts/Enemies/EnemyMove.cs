using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public EnemyScriptable enemyStats;
    Transform player;

    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyStats.speed * Time.deltaTime); //Follows the player
    }
}
