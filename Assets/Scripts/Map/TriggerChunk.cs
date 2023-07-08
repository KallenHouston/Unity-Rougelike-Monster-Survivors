using UnityEngine;

public class TriggerChunk : MonoBehaviour
{
    MapController controller;
    public GameObject mapTarget;

    void Start()
    {
        controller = FindObjectOfType<MapController>();
    }


    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            controller.currentChunk = mapTarget;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if(controller.currentChunk == mapTarget) 
            {
               controller.currentChunk = null;
            }
        }
    }
}
