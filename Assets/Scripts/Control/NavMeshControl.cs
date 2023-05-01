using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class NavMeshControl : MonoBehaviour
{
    public Vector3 targetPosition;
    public Transform followTarget;
    public NavMeshAgent agent;

    public UnityEvent<Vector2> moveEvent;

    private void Awake()
    {
        agent.updatePosition = false;
        //agent.updateRotation = false;
        targetPosition = transform.position;
    }

    void FixedUpdate()
    {
        AIStep();
    }
    protected virtual void AIStep()
    {
        agent.nextPosition = transform.position;

        if (followTarget != null) targetPosition = followTarget.position;

        agent.destination = targetPosition;

        Vector3 normalizedDesiredVelocity = agent.desiredVelocity.normalized;

        var localVelocity = transform.InverseTransformDirection(agent.desiredVelocity);

        Vector3 forwardVelocity = Vector3.Project(normalizedDesiredVelocity, agent.transform.forward);

        moveEvent.Invoke(new Vector2(0, localVelocity.normalized.z));
    }
}
