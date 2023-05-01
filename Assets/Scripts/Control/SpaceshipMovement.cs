using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipMovement : MonoBehaviour
{
    //public float maxMoveSpeed;
    //public float boostFactor = 2f;
    //public float reverseMaxMoveSpeed;
    //public float acceleration;
    public float drift;
    public float rotateSpeed;

    public float shipVelocity;
    
    public bool boostState;
    //public Color baseExhaustColor;
    //public Color boostExhaustColor;

    public Rigidbody rigid;
    public EquipmentController equipmentController;
    //public ParticleSystem[] exhaustParticles;

    public Vector2 moveVector;
    public void OnMovement(InputAction.CallbackContext context)
    {
        SetMoveVector(context.ReadValue<Vector2>());   
    }
    public void SetMoveVector(Vector2 vector)
    {
        //Debug.Log(vector);
        moveVector = vector;
    }
    public void OnForwardVectorChange(InputAction.CallbackContext context)
    {
        moveVector.y = context.ReadValue<float>();
    }
    public void OnSideVectorChange(InputAction.CallbackContext context)
    {
        moveVector.x = context.ReadValue<float>();
    }
    public void OnBoost(InputAction.CallbackContext context)
    {
        boostState = context.ReadValue<float>() > 0.5f ? true : false;
    }

    private void FixedUpdate()
    {
        float forwardVector = moveVector.y;
        float rotateVector = moveVector.x;

        float rotationStep = rotateVector * rotateSpeed * Time.fixedDeltaTime;
        rigid.MoveRotation(Quaternion.Euler(0, rigid.rotation.eulerAngles.y + rotationStep , 0));

        //rigid.AddRelativeTorque(0, rotationStep, 0, ForceMode.Force);

        //float resultMoveSpeed = boostState ? maxMoveSpeed * boostFactor : maxMoveSpeed;

        //float shipVelocity = forwardVector >= 0 ? resultMoveSpeed * forwardVector : reverseMaxMoveSpeed * forwardVector; // now it's only "forward" part of vector

        //// x, y, z acceleration limits
        //float maxDriftCompens = drift;
        //float maxFloatCompens = 0;
        //float maxAcc = acceleration;

        //Vector3 localVelocity = rigid.transform.InverseTransformDirection(rigid.velocity);

        //rigid.AddRelativeForce(
        //    // Limit change for each component separately 
        //    x: Mathf.Clamp(-localVelocity.x, -maxDriftCompens, maxDriftCompens),
        //    y: Mathf.Clamp(-localVelocity.y, -maxFloatCompens, maxFloatCompens),
        //    z: Mathf.Clamp(shipVelocity - localVelocity.z, -maxAcc, maxAcc),
        //    mode: ForceMode.Force
        //);

        equipmentController.UseEngine();

        var localTransformVelocity = transform.InverseTransformDirection(rigid.velocity);
        shipVelocity = localTransformVelocity.z;

        //foreach (var particle in exhaustParticles)
        //{
        //    var main = particle.main;
        //    main.startColor = boostState ? boostExhaustColor : baseExhaustColor; 

        //    var emission = particle.emission;
        //    emission.rateOverTime = shipVelocity * 10;
        //}


    }
}
