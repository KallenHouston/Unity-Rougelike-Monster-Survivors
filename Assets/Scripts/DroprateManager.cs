using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroprateManager : MonoBehaviour
{
    // Define a serializable class to represent a drop
    [System.Serializable]
    public class Drop
    {
        public string name; // Name of the drop
        public GameObject itemPrefab; // Prefab of the dropped item
        public float rate; // Drop rate (percentage)
    }

    public List<Drop> drops; // List of drops

    private void OnDestroy()
    {
        float randomNum = UnityEngine.Random.Range(0f, 100f); // Generate a random number between 0 and 100
        List<Drop> possibleDrops = new List<Drop>();

        // Iterate through each drop in the list
        foreach (Drop droprate in drops)
        {
            if (randomNum <= droprate.rate) // Check if the random number is less than or equal to the drop rate
            {
                possibleDrops.Add(droprate);
            }

            if(possibleDrops.Count > 0)
            {
                Drop drops = possibleDrops[UnityEngine.Random.Range(0, possibleDrops.Count)];
                // Instantiate the item prefab at the current object's position with no rotation
                Instantiate(drops.itemPrefab, transform.position, Quaternion.identity);
            }

        }
    }
}