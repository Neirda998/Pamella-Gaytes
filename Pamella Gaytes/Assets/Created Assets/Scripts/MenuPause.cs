using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class MenuPause : MonoBehaviour
{
    public Transform canvas;
    public Transform player;
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
                player.GetComponent<Controll2D>().enabled = false;
            }
            else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
                player.GetComponent<Controll2D>().enabled = true;
            }
        }
    }
    public void GoToHub()
    {
        Application.LoadLevel(0);
        player.GetComponent<Controll2D>().enabled = true;
        Time.timeScale = 1;
    }
    public void IQuit()
    {
        Application.Quit();
    }
}
