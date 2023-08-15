using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.TryGetComponent(out InterfaceCollectible collectible))
        {
            collectible.Collect();
        }
    }

}
