using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCollectible : MonoBehaviour, InterfaceCollectible
{
    public int ExpGranted;

    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.expIncrement(ExpGranted);
        Destroy(gameObject);
    }
}
