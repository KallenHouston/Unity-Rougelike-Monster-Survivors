using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private CharScriptable charStats;  

    //Current Stats
    [HideInInspector]
    public float currentMaxHealth;
    [HideInInspector]
    public float currentMovementSpeed;   
    [HideInInspector]     
    public float currentRecovery;
    [HideInInspector]        
    public float currentPower;
    [HideInInspector]          
    public float currentProjectileSpeed; 
    [HideInInspector]          
    public float currentMagnet; 

    //Spawn Weapon
    public List<GameObject> weaponSpawned;


    //Exp and level of player.
    [Header("Exp/Level")]
    public int exp = 0;      
    public int level = 1;    
    public int expCap;      

    //Defining level range and incrementation of the exp cap for that range
    [Serializable]
    public class LvRange
    {
        public int startPointLvl;       
        public int endPointLvl;         
        public int expCapIncrement;  
    }

    public List<LvRange> lvRanges;     

    //Iframes
    [Header("Iframes")]
    public float iframeDuration;
    private float iframeTimer;
    private bool isIframe;

    private void Awake()
    {
        charStats = CharSelect.getStats();
        CharSelect.instance.DestroySingleton();

        // Initialize the character's current stats to their base stats.
        currentMovementSpeed = charStats.MovementSpeed;
        currentMaxHealth = charStats.MaxHealth;
        currentRecovery = charStats.Recovery;
        currentPower = charStats.power;
        currentProjectileSpeed = charStats.ProjectileSpeed;
        currentMagnet = charStats.Magnet;

        //Spawn the starting weapon.
        SpawnWeapon(charStats.startWeapon);
    }

    private void Start()
    {
        // Set the initial experience point cap to the first increment in the level range list.
        expCap = lvRanges[0].expCapIncrement;
    }

    private void Update()
    {
        if(iframeTimer > 0)
        {
            iframeTimer -= Time.deltaTime;
        }
        else if(isIframe)
        {
            isIframe = false;
        }

        naturalRecover();
    }

    public void expIncrement(int amount)
    {
        // Add the given amount of experience points to the character's current experience points.
        exp += amount;

        // Check if the character has enough experience points to level up.
        lvlUpCheck();
    }

    private void lvlUpCheck()
    {
        // If the character has enough experience points to level up:
        if (exp >= expCap)
        {
            // Increase the character's level by one.
            level++;

            // Subtract the experience point cap from the character's current experience points.
            exp -= expCap;

            // Look through the level range list to find the range that the character's new level falls within.
            int expCapIncrementing = 0;
            foreach (LvRange range in lvRanges)
            {
                if (range.startPointLvl <= level && range.endPointLvl >= level)
                {
                    expCapIncrementing = range.expCapIncrement;
                    break;
                }
            }

            // Increase the experience point cap by the amount specified in the level range that the character's new level falls within.
            expCap += expCapIncrementing;
        }
    }


    public void TakeDmg(float dmg)
    {
        if(!isIframe)
        {
            currentMaxHealth -= dmg;

            iframeTimer = iframeDuration;
            isIframe = true;

            if(currentMaxHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        Debug.Log("Dead");
    }
    
    public void RestoringHealth(float amount)
    {
        if(currentMaxHealth < charStats.MaxHealth)
        {
            currentMaxHealth += amount;

            if(currentMaxHealth > charStats.MaxHealth)
            {
                currentMaxHealth = charStats.MaxHealth;
            }
        }
    }

    private void naturalRecover()
    {
        if(currentMaxHealth < charStats.MaxHealth)
        {
            currentMaxHealth += currentRecovery * Time.deltaTime;
        }
    }

    public void SpawnWeapon(GameObject weap)
    {
        // Spawn the start weapon
        GameObject spawnedWeapon = Instantiate(weap, transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
        
        // Add the spawned weapon to the weaponSpawned list
        weaponSpawned.Add(spawnedWeapon);
    }
}