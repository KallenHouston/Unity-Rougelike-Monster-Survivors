using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> TerrainChunks;
    public GameObject Player;
    public float checkRadius;
    public Vector3 noTerrainPos;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    PlayerMovement movement;

    [Header("Optimization")]
    public List<GameObject> chunksSpawned;
    GameObject latestChunk;
    public float maxOpDistance; //must be greater than length, width of the map
    float opDist;
    float optimizedCD;
    public float optimizedCDdur;

    void Start()
    {
        movement = FindAnyObjectByType<PlayerMovement>();
    }


    void Update()
    {
        ChunkChecker();
        OptimizedChunk();
    }

    void ChunkChecker()
    {
        if (!currentChunk)
        {
            return;
        }

        if (movement.direction.x > 0 && movement.direction.y == 0) //right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkRadius, terrainMask))
            {
                noTerrainPos = currentChunk.transform.Find("Right").position;
                ChunkSpawn();
            }
        }
        else if (movement.direction.x < 0 && movement.direction.y == 0) //left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkRadius, terrainMask))
            {
                noTerrainPos = currentChunk.transform.Find("Left").position;
                ChunkSpawn();
            }
        }
        else if (movement.direction.x == 0 && movement.direction.y > 0) //up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkRadius, terrainMask))
            {
                noTerrainPos = currentChunk.transform.Find("Up").position;
                ChunkSpawn();
            }
        }
        else if (movement.direction.x == 0 && movement.direction.y < 0) //down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkRadius, terrainMask))
            {
                noTerrainPos = currentChunk.transform.Find("Down").position;
                ChunkSpawn();
            }
        }
        else if (movement.direction.x > 0 && movement.direction.y > 0) //right up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightUp").position, checkRadius, terrainMask))
            {
                noTerrainPos = currentChunk.transform.Find("RightUp").position;
                ChunkSpawn();
            }
        }
        else if (movement.direction.x > 0 && movement.direction.y < 0) //right down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightDown").position, checkRadius, terrainMask))
            {
                noTerrainPos = currentChunk.transform.Find("RightDown").position;
                ChunkSpawn();
            }
        }
        else if (movement.direction.x < 0 && movement.direction.y > 0) //left up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LeftUp").position, checkRadius, terrainMask))
            {
                noTerrainPos = currentChunk.transform.Find("LeftUp").position;
                ChunkSpawn();
            }
        }
        else if (movement.direction.x < 0 && movement.direction.y < 0) //left down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LeftDown").position, checkRadius, terrainMask))
            {
                noTerrainPos = currentChunk.transform.Find("LeftDown").position;
                ChunkSpawn();
            }
        }
    }

    void ChunkSpawn()
    {
        int rand = Random.Range(0, TerrainChunks.Count);
        latestChunk = Instantiate(TerrainChunks[rand], noTerrainPos, Quaternion.identity);
        chunksSpawned.Add(latestChunk);
    }

    void OptimizedChunk()
    {
        optimizedCD -= Time.deltaTime;

        if (optimizedCD <= 0f)
        {
            optimizedCD = optimizedCDdur;
        }

        foreach (GameObject chunk in chunksSpawned)
        {
            opDist = Vector3.Distance(Player.transform.position, chunk.transform.position);
            if (opDist > maxOpDistance)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}