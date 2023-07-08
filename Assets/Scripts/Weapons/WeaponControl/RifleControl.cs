using UnityEngine;

public class RifleControl : WeaponControl
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject rifleBullet = Instantiate(weaponStats.prefab);
        rifleBullet.transform.position = transform.position; //Assign position to be the same as this object which is parented to the player
        rifleBullet.GetComponent<RifleBehaviour>().DirectionCheck(movement.lastMovementVect);
    }
}
