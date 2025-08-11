using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float armor = 100f;
    [SerializeField] private ArmorType armorType;





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


    public bool IsDead() => health <= 0;

    public void TakeDamage(float damage, DamageType damageType)
    {
        float finalDamage = CalculateDamage(damage, damageType);
        if (armor > finalDamage) armor -= finalDamage;
        else
        {
            health -= finalDamage - armor;
            armor = 0;
        }


        if (IsDead())
        {
            Die();
        }
    }


    private void Die()
    {
        print("Enemy dead :(");
    }


    private float CalculateDamage(float damage, DamageType damageType) => damage * MultiplierDamage(damageType);



    private float MultiplierDamage(DamageType damageType)
    {
        (ArmorType, DamageType) key = (armorType, damageType);
        return DamageMultipliers.TryGetValue(key, out float multiplier) ? multiplier : 1.0f;
    }

}
