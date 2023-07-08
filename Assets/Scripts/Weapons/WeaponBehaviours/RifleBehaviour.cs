using UnityEngine;

public class RifleBehaviour : BulletBehaviour
{
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * weaponStats.WeaponSpeed * Time.deltaTime; //Set movement of bullet
    }
}
