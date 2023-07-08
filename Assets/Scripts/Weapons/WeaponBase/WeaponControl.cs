
using UnityEngine;

//BASE SCRIPT FOR WEAPONS
public class WeaponControl : MonoBehaviour
{
    [Header("Weapon Statistics:")]
    public WeaponScriptable weaponStats;
    float currentCD;

    protected PlayerMovement movement;

    protected virtual void Start()
    {
        movement = FindObjectOfType<PlayerMovement>();
        currentCD = weaponStats.CooldownDuration; //Set the current cooldown to be the cooldown duration
    }


    protected virtual void Update()
    {
        currentCD -= Time.deltaTime;
        if (currentCD <= 0f) //when cooldown reaches 0, the weapon can attack
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCD = weaponStats.CooldownDuration;
    }
}
