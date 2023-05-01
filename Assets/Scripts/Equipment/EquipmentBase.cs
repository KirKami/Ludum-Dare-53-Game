using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentBase : MonoBehaviour
{
    public EquipmentController controller;

    public int maxDurability = 100;
    public int durability = 100;
    public int durabilityLoss = 1;

    protected bool useDurabilityLossTimer;
    protected float timer;

    public virtual void UseEquipment()
    {
        if (useDurabilityLossTimer)
        {
            if (timer >= 1f)
            {
                durability -= durabilityLoss;
                timer -= 1f;
            }
            else
            {
                timer += Time.fixedDeltaTime;
            }
        }
    }
}
