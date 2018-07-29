using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class AICharacterControl : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
    public ThirdPersonCharacter character { get; private set; } // the character we are controlling
    public Transform target;                                    // target to aim for

    public Player playerCharacter;

    private void Start()
    {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();

        agent.updateRotation = false;
        agent.updatePosition = true;

        playerCharacter = FindObjectOfType<Player>();
        target = playerCharacter.transform;
    }


    private void Update()
    {
        if (target != null)
            agent.SetDestination(target.position);

        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);
    }


    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
