using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : Pickups, InterfaceCollectible
{
    public int RestoredHealth;

    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.RestoringHealth(RestoredHealth);
    }
}
