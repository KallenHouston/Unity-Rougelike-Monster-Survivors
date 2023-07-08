using UnityEngine;

//BASE SCRIPT FOR MELEE BEHAVIOURS [TO BE PLACED ON THE MELEE WEAPON PREFAB]
public class MeleeBehaviour : MonoBehaviour
{
    public WeaponScriptable weaponStats;

    public float destroyAfterSecs;

    //Current Stats
    protected float currentDmg;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    private void Awake()
    {
        currentDmg = weaponStats.WeaponDamage;
        currentSpeed = weaponStats.WeaponSpeed;
        currentCooldownDuration = weaponStats.CooldownDuration;
        currentPierce = weaponStats.Pierce;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSecs);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemiesStats enemy = col.GetComponent<EnemiesStats>();
            enemy.TakeDmg(currentDmg);
        }
    }
}
