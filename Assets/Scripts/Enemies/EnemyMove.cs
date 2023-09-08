using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    EnemiesStats enemies;
    Transform player;

    void Start()
    {
        enemies = GetComponent<EnemiesStats>();
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemies.currentSpeed * Time.deltaTime); //Follows the player
    }
}
