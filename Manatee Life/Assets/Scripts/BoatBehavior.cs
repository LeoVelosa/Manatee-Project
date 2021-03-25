﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehavior : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> locations;
    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    void Update()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    void InitializePatrolRoute()
    {
        Debug.Log("Yes");
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        Debug.Log("Ye");
        int lIndex = UnityEngine.Random.Range(0, 4);
        Debug.Log(lIndex);
        if (locations.Count == 0) return;
        agent.destination = locations[lIndex].position;
        //locationIndex = (locationIndex + 1) % locations.Count;
    }
}
