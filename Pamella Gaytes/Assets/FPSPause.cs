using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FPSPause : MonoBehaviour {

    public Transform canvas;
    public GameObject player;

    
    [SerializeField]
    string scene = SceneManager.GetActiveScene().ToString();


    void Update()
    {
        Pause();
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                player.GetComponent<FirstPersonController>().enabled = false;
                player.GetComponent<AudioSource>().enabled = false;

            }
           
            else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
                player.GetComponent<FirstPersonController>().enabled = true;
                player.GetComponent<AudioSource>().enabled = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            GoToHub();
        }
    }
    public void GoToHub()
    {
        SceneManager.LoadScene(0);
        player.GetComponent<FirstPersonController>().enabled = true;
        player.GetComponent<AudioSource>().enabled = true;
        Time.timeScale = 1;
    }

    public void Retry()
    {
        SceneManager.LoadScene(scene);
        player.GetComponent<FirstPersonController>().enabled = true;
        player.GetComponent<AudioSource>().enabled = true;
        Time.timeScale = 1;
    }
    public void IQuit()
    {
        Application.Quit();
    }
}
