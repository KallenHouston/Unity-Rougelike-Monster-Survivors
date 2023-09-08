using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCollectible : Pickups, InterfaceCollectible
{
    public int ExpGranted;

    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.expIncrement(ExpGranted);
    }
}
