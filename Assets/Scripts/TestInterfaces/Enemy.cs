using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private float health = 100f;
    [SerializeField] private ArmorType armor;

    public bool IsDead() => health <= 0;


    private readonly Dictionary<(ArmorType, DamageType), float> DamageMultipliers = new()
    {
        //ArmorType.None
        {(ArmorType.None,DamageType.Normal), 1.0f },
        {(ArmorType.None,DamageType.Magical), 1.0f },
        {(ArmorType.None,DamageType.Chaos), 1.0f },

        //ArmorType.Medium
        {(ArmorType.Medium,DamageType.Normal), 1.0f },
        {(ArmorType.Medium,DamageType.Magical), 0.8f },
        {(ArmorType.Medium,DamageType.Chaos), 1.0f },

        //ArmorType.Fortified
        {(ArmorType.Fortified,DamageType.Normal), 0.5f },
        {(ArmorType.Fortified,DamageType.Magical), 0.5f },
        {(ArmorType.Fortified,DamageType.Chaos), 1.0f },

    };



    public void TakeDamage(float damage, DamageType damageType)
    {
        health -= damage;

        if (IsDead())
        {
            Die();
        }
    }


    private void Die()
    {
        if (IsDead())
        {
            print("Enemy dead :(");
        }
    }


    private float CalculateDamage(float damage, DamageType damageType)
    {

        if (armor != ArmorType.None)
        {
            return 0;
        }
        else
        {
            return damage;
        }
    }

    //private float MultiplierDamage(DamageType damageType) // Тест
    //{
    //    switch (armor)
    //    {
    //        case ArmorType.None:
    //            switch (damageType)
    //            {
    //                case DamageType.Normal:
    //                    return 0;
    //                case DamageType.Magical:
    //                    return 0;
    //                case DamageType.Chaos:
    //                    return 0;
    //                default:
    //                    return 0;
    //            }
    //        case ArmorType.Medium:
    //            switch (damageType)
    //            {
    //                case DamageType.Normal:
    //                    return 0;
    //                case DamageType.Magical:
    //                    return 0;
    //                case DamageType.Chaos:
    //                    return 0;
    //                default:
    //                    return 0;
    //            }
    //        case ArmorType.Fortified:
    //            switch (damageType)
    //            {
    //                case DamageType.Normal:
    //                    return 0;
    //                case DamageType.Magical:
    //                    return 0;
    //                case DamageType.Chaos:
    //                    return 0;
    //                default:
    //                    return 0;
    //            }
    //        default:
    //            return 0;
    //    }

    //} 
    private float MultiplierDamage(DamageType damageType)
    {
        (ArmorType, DamageType) key = (armor, damageType);

        return DamageMultipliers.TryGetValue(key, out float multiplier) ? multiplier : 1.0f;
    }
}
