using System.Collections.Generic;
using UnityEngine;

public class PropRandom : MonoBehaviour
{
    //ref
    public List<GameObject> propSpawn;
    public List<GameObject> propSpawnPrefabs;

    void Start()
    {
        PropsSpawn();
    }


    void Update()
    {
        
    }

    void PropsSpawn()
    {
        foreach (GameObject sp in propSpawn)
        {
            int rand = Random.Range(0,propSpawnPrefabs.Count);
            GameObject props = Instantiate(propSpawnPrefabs[rand], sp.transform.position, Quaternion.identity);
            props.transform.parent = sp.transform;
        }
    }
}
