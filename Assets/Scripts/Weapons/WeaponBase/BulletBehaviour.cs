using UnityEngine;

//A BASE SCRIPT USED ON ALL PROJECTILES BEHAVIOURS (PLACED ON A PREFAB OF A PROJECTILE WEAP)
public class BulletBehaviour : MonoBehaviour
{
    public WeaponScriptable weaponStats;

    protected Vector3 direction;
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


    public void DirectionCheck(Vector3 dir)
    {
        direction = dir;

        float directionX = direction.x;
        float directionY = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotate = transform.rotation.eulerAngles;

        if (directionX < 0 && directionY == 0) //Left
        {
            scale.x = scale.x * -1f;
            scale.y = scale.y * -1f;
        }
        else if (directionX == 0 && directionY < 0) //Down
        {
            rotate.z = scale.z * -900;
        }
        else if (directionX == 0 && directionY > 0) //Up
        {
            rotate.z = scale.z * 900;
        }
        else if (directionX > 0 && directionY > 0) //Right Up
        {
            rotate.z = scale.z * 450;
        }
        else if (directionX > 0 && directionY < 0) //Right Down
        {
            rotate.z = scale.z * -450;
        }
        else if (directionX < 0 && directionY > 0) //Left Up
        {
            rotate.z = scale.z * -2250;
        }
        else if (directionX < 0 && directionY < 0) //Left Down
        {
            rotate.z = scale.z * -1350;
        }

        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotate);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        //Ref script from the collided collider and deal dmg to the enemy using TakeDmg script.
        if (col.CompareTag("Enemy"))
        {
            EnemiesStats enemy = col.GetComponent<EnemiesStats>();
            enemy.TakeDmg(currentDmg); //Make sure to use currentDmg instead of weaponStats.dmg in case any damage mutipliers in the future.
            PiercingReduce();
        }
    }

    private void PiercingReduce() //Bullet get destroyed once piercing gets to 0
    {
        currentPierce--;
        if(currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }
}
