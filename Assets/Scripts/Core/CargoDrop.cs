using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoDrop : MonoBehaviour
{
    public ItemEntity itemEntity;

    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.TryGetComponent<SpaceshipEntity>(out var targetEntity);
        if (!targetEntity) return;
        if (targetEntity.transform.root.tag == "Enemy") return;

        targetEntity.AddCargo(itemEntity.cargoType, itemEntity.quantity);

        Destroy(gameObject);
    }
}
