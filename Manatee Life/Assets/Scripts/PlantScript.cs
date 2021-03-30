using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public GameBehavior gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MainCamera")
        {
            Destroy(this.transform.gameObject);
            gameManager.foodSeconds = 30.0f;
        }
    }
}