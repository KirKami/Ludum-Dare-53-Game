using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EngineEquip : EquipmentBase
{
    public float maxMoveSpeed;
    public float boostFactor = 2f;
    public float reverseMaxMoveSpeed;
    public float acceleration;

    public Color baseExhaustColor;
    public Color boostExhaustColor;

    public float thrusterPower;

    public ParticleSystem exhaustParticles;
    public Light exhaustLight;
    public AudioSource exhaustSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void UseEquipment()
    {
        var mover = controller.mover;

        useDurabilityLossTimer = mover.boostState;
        base.UseEquipment();

        float forwardVector = mover.moveVector.y;
        float rotateVector = mover.moveVector.x;

        float resultMoveSpeed = mover.boostState ? maxMoveSpeed * boostFactor : maxMoveSpeed;

        thrusterPower = forwardVector >= 0 ? resultMoveSpeed * forwardVector : reverseMaxMoveSpeed * forwardVector; // now it's only "forward" part of vector

        // x, y, z acceleration limits
        float maxDriftCompens = mover.drift;
        float maxFloatCompens = 0;
        float maxAcc = acceleration;

        Vector3 localVelocity = mover.rigid.transform.InverseTransformDirection(mover.rigid.velocity);

        mover.rigid.AddRelativeForce(
            // Limit change for each component separately 
            x: Mathf.Clamp(-localVelocity.x, -maxDriftCompens, maxDriftCompens),
            y: Mathf.Clamp(-localVelocity.y, -maxFloatCompens, maxFloatCompens),
            z: Mathf.Clamp(thrusterPower - localVelocity.z, -maxAcc, maxAcc),
            mode: ForceMode.Force
        );

        var main = exhaustParticles.main;
        main.startColor = controller.mover.boostState ? boostExhaustColor : baseExhaustColor;

        var emission = exhaustParticles.emission;
        emission.rateOverTime = thrusterPower > 1f ? thrusterPower * 10 : 10;

        exhaustLight.intensity = thrusterPower > 1f ? thrusterPower * 0.1f : 0.1f;

        exhaustSound.pitch = thrusterPower > 1f ? thrusterPower * 0.1f : 0.1f;
    }
}
