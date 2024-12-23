using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Bu nesneyi sahneler arasında koru
        }
        else
        {
            Destroy(gameObject); // Eğer başka bir instance varsa, yok et
        }
    }

    void Update()
    {
        // Eğer sahne "MainMenu" veya "ControlsMenu" değilse, müziği durdur ve nesneyi yok et
        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (currentScene != "MainMenu" && currentScene != "ControlsMenu")
        {
            Destroy(gameObject); // Müzik nesnesini yok et
        }
    }
}
