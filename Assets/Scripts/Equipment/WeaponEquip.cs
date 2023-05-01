using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquip : EquipmentBase
{
    public int baseDamage = 1;
    public float useInterval = 0.5f;
    public float useTimer;

    public float shootForce;

    public AttackProjectile projectilePrefab;
    public Transform projectileSpawn;

    public ParticleSystem muzzleFlash;
    public Light muzzleLight;
    public AudioSource muzzleSound;

    public bool holdUse;
    public bool holdUseInput;

    public override void UseEquipment()
    {
        var mover = controller.mover;

        useDurabilityLossTimer = false;
        base.UseEquipment();

        AttackProjectile projectileInstance = Instantiate(projectilePrefab, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        projectileInstance.shooter = this;

        muzzleFlash.Play(true);
        //muzzleLight.gameObject.SetActive(true);
        muzzleSound.PlayOneShot(muzzleSound.clip);

        useTimer = useInterval;
    }
    private void FixedUpdate()
    {
        useTimer = useTimer > 0 ? useTimer - Time.fixedDeltaTime : 0;

        if (holdUse)
        {
            if (holdUseInput && useTimer <= 0) UseEquipment(); 
        }
        else
        {
            if (holdUseInput && useTimer <= 0)
            {
                UseEquipment();
                holdUseInput = false;
            }
        }
    }
}
