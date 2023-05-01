using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavMeshControl : NavMeshControl
{
    public float dotFiring;

    public EquipmentController equipmentController;
    public SpaceshipEntity entity;
    public DamagableEntity damagable;
    protected override void AIStep()
    {
        base.AIStep();

        if (followTarget)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 toOther = followTarget.position - transform.position;

            if (Vector3.Dot(transform.forward, toOther) >= dotFiring)
            {
                //equipmentController.UseWeapons();
                equipmentController.weapons[0].holdUseInput = true;
            }
            else
            {
                equipmentController.weapons[0].holdUseInput = false;
            }

            //if (Vector3.Dot(forward, toOther) < 0)
            //{
            //    print("The other transform is behind me!");
            //}
        }
    }
}
