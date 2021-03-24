using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehavior : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> locations;
    //private int locationIndex = 0;
    private UnityEngine.AI.NavMeshAgent agent;
    public int health;
    public GameObject bullet;
    public float bulletSpeed = 100f;
    int tracker = 0;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
        health = 100;
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
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        int lIndex = UnityEngine.Random.Range(0, 4);
        Debug.Log(lIndex);
        if (locations.Count == 0) return;
        agent.destination = locations[lIndex].position;
        //locationIndex = (locationIndex + 1) % locations.Count;
    }

    void OnTriggerEnter(Collider other)
    {

    }
    void OnTriggerExit(Collider other)
    {

    }
}
