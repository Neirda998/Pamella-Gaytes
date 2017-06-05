using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BossPause : MonoBehaviour {

    public Transform canvas;
    public GameObject player;
    public GameObject boss;

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
                boss.GetComponent<AudioSource>().enabled = false;
                boss.GetComponent<AnimationRobot1>().enabled = false;

            }
            else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
                player.GetComponent<FirstPersonController>().enabled = true;
                player.GetComponent<AudioSource>().enabled = true;
                boss.GetComponent<AudioSource>().enabled = true;
                boss.GetComponent<AnimationRobot1>().enabled = true;
            }
        }
    }
    public void GoToHub()
    {

        boss.GetComponent<AudioSource>().enabled = true;
        boss.GetComponent<AnimationRobot1>().enabled = true;
        SceneManager.LoadScene(0);
        player.GetComponent<FirstPersonController>().enabled = true;
        player.GetComponent<AudioSource>().enabled = true;
        Time.timeScale = 1;
    }

    public void Retry()
    {

        boss.GetComponent<AudioSource>().enabled = true;
        boss.GetComponent<AnimationRobot1>().enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        player.GetComponent<FirstPersonController>().enabled = true;
        player.GetComponent<AudioSource>().enabled = true;
        Time.timeScale = 1;
    }
    public void IQuit()
    {
        Application.Quit();
    }
}
