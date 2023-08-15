using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/characters")]
public class CharScriptable : ScriptableObject
{
    [SerializeField]
    private GameObject StartWeapon;
    public GameObject startWeapon { get => StartWeapon; private set => StartWeapon = value; }

    [SerializeField]
    private float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    [SerializeField]
    private float recovery;
    public float Recovery { get => recovery; private set => recovery = value; }

    [SerializeField]
    private float movementSpeed;
    public float MovementSpeed { get => movementSpeed; private set => movementSpeed = value; }

    [SerializeField]
    private float Power;
    public float power { get => Power; private set => Power = value; }

    [SerializeField]
    private float projectileSpeed;
    public float ProjectileSpeed { get => projectileSpeed; private set => projectileSpeed = value; }
}
