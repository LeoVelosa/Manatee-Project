using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Air : MonoBehaviour
{
    public float currentAir = 0.0f;
    public float maxAir = 30.0f;
    public Underwater underWaterScript;

    public AirBar airBar;

    // Start is called before the first frame update
    void Start()
    {
        underWaterScript = GameObject.Find("MainCamera").GetComponent<Underwater>();
        airBar = GameObject.Find("Air Bar").GetComponent<AirBar>();
        currentAir = maxAir;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < underWaterScript.underwaterLevel)
        {
            currentAir -= Time.deltaTime;

            airBar.setAir(currentAir);
        }
        else
        {
            if(currentAir <= maxAir)
            {
                Debug.Log(currentAir);

                currentAir += Time.deltaTime;

                airBar.setAir(currentAir);
            }
        }
    }
}