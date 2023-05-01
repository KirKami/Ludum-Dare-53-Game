using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.EventSystems.EventTrigger;

public class DamagableEntity : MonoBehaviour
{
    public int maxHealth;
    public int health;

    public int damageAbsorb;

    public UnityEvent damageEvent;
    public UnityEvent healEvent;
    public UnityEvent deathEvent;
    public UnityEvent startEvent;

    public GameObject destroyObject;

    private void Start()
    {
        startEvent.Invoke();
    }

    public void CalculateDamage(int baseDamage)
    {
        int damage = baseDamage;
        void DoDirectDamage()
        {
            if (health - damage > 0) DamageToHealth();
            else Kill();
        }
        void DamageToHealth()
        {
            Debug.Log("PerformDamageToHealth: " + damage);
            health -= damage;
            damageEvent.Invoke();
        }
        void Kill()
        {
            health = 0;
            deathEvent.Invoke();
            //Kill();
        }

        Debug.Log("Base Damage: " + baseDamage);
        damage = baseDamage - damageAbsorb;
        if (damage < 0) damage = 0;
        DoDirectDamage();
    }
    public void ApplyHeal(int amount)
    {
        if ((health + amount) < maxHealth)
        {
            health += amount;
            healEvent.Invoke();
        }
        else
        {
            health = maxHealth;
            healEvent.Invoke();
        }
    }

    public virtual void Kill()
    {
        Debug.Log("DAMAGABLE ENTITY: Entity " + gameObject.name + " is destroyed.");
        Instantiate(destroyObject, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
