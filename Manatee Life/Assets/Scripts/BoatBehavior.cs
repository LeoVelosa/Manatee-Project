using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehavior : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> locations;
    public Transform currLocation;
    public GameBehavior gameManager;

    void Start()
    {
        InitializePatrolRoute();
        MoveToNextLocation();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    void Update()
    {
        if (this.transform.position == currLocation.position)
        {
            MoveToNextLocation();
        }
        else
        {
            this.transform.LookAt(currLocation);
            this.transform.position = Vector3.MoveTowards(this.transform.position, currLocation.position, 5);
        }
    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    void MoveToNextLocation()
    {
        int lIndex = UnityEngine.Random.Range(0, 4);
        if (locations.Count == 0) return;
        currLocation = locations[lIndex];
        this.transform.position = Vector3.MoveTowards(this.transform.position, currLocation.position, 100);
        //locationIndex = (locationIndex + 1) % locations.Count;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MainCamera")
        {
            gameManager.lives -= 1;
        }
    }
}
