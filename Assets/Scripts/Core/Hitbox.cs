using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public DamagableEntity hitboxEntity;

    public float damageMultiplier = 1f;

    public void ApplyDamage(int baseDamage)
    {
        int resultDamage = (int)(baseDamage * damageMultiplier);

        hitboxEntity.CalculateDamage(resultDamage);
    }
}
