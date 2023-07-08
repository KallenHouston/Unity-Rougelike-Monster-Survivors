using UnityEngine;

public class EmpControl : WeaponControl
{

    protected override void Start()
    {
        base.Start();
    }


    protected override void Attack()
    {
        base.Attack();
        GameObject spawnEMP = Instantiate(weaponStats.prefab);
        spawnEMP.transform.position = transform.position; //assign the position of the object to be the same as this object which is parented to the player.
        spawnEMP.transform.parent = transform; //so that is below this object
    }
}
