using UnityEngine;

public class EnemiesStats : MonoBehaviour
{
    public EnemyScriptable enemyStats;

    //Current Stats
    private float currentSpeed;
    private float currentHealth;
    private float currentDmg;

    private void Awake()
    {
        currentSpeed = enemyStats.speed;
        currentHealth = enemyStats.maxHealth;
        currentDmg = enemyStats.dmg;
    }

    public void TakeDmg(float dmg)
    {
        currentHealth -= dmg;

        if(currentHealth <= 0 ) 
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
    
    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            PlayerStats player = col.gameObject.GetComponent<PlayerStats>();
            player.TakeDmg(currentDmg);
        }
    }
}
