using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public string labelText = "Avoid boats to survive!";
    public int lives = 3;
    public float foodSeconds = 30.0f;
    public float gameSeconds = 120.0f;
    public Air airLeft;
    // Start is called before the first frame update
    void Start()
    {
        airLeft = GameObject.Find("Main Camera").GetComponent<Air>();
    }

    // Update is called once per frame
    void Update()
    {
        foodSeconds -= Time.deltaTime;
        gameSeconds -= Time.deltaTime;

        if (gameSeconds <= 0 && SceneManager.GetActiveScene().name == "Level 1")
        {
            SceneManager.LoadScene("Level 2");
            foodSeconds = 30.0f;
            gameSeconds = 120.0f;
            airLeft.currentAir = 20.0f;
        }

    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 170, 25), "Manatee Lives: " + lives);
        GUI.Box(new Rect(20, 50, 170, 25), "Need food in: " + Mathf.Round(foodSeconds) + " seconds");
        GUI.Box(new Rect(350, 2, 170, 25), "Remaining Air");
        GUI.Box(new Rect(650, 20, 200, 25), "Survive for " + Mathf.Round(gameSeconds) + " more seconds");
        GUI.Label(new Rect(Screen.width / 2 - 70, Screen.height - 50, 300, 50), labelText);

        if (foodSeconds <= 0 || airLeft.currentAir <= 0 || lives <= 0)
        {
            GUI.Box(new Rect(Screen.width / 2 - 120, Screen.height / 2, 300, 50), "Game over. I hope " +
                "this experience helps you \nunderstand what a manatees daily life is like");
            Time.timeScale = 0.0f;
        }
        if (gameSeconds <= 0 && SceneManager.GetActiveScene().name == "Level 2")
        {
            GUI.Box(new Rect(Screen.width / 2 - 130, Screen.height / 2, 350, 55), "You did it! You may " +
                "have survived through our \ngame but imagine doing this every day. Manatees are" +
                "\nin constant danger and humans are the problem.");
            Time.timeScale = 0.0f;
        }
    }
}
