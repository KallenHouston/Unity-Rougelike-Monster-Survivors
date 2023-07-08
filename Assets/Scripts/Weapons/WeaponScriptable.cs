using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptable", menuName ="ScriptableObjects/weapons")]
public class WeaponScriptable : ScriptableObject
{
    [SerializeField]
    private GameObject weaponPrefab;
    public GameObject prefab { get => weaponPrefab; private set => prefab = value; }
    //base stats
    [SerializeField]
    private float wpDamage;
    public float WeaponDamage { get => wpDamage; private set => wpDamage = value; }

    [SerializeField]
    private float wpSpeed;
    public float WeaponSpeed { get => wpSpeed; private set => wpSpeed = value; }

    [SerializeField]
    private float CDduration;
    public float CooldownDuration { get => CDduration; private set => CDduration = value; }

    [SerializeField]
    private int pierce;
    public int Pierce { get => pierce; private set => pierce = value; }
}
