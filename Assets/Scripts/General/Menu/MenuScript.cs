using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject selectMode,firstMenu;

    private int pause = 0;

    public void PlayGame()
    {
        firstMenu.SetActive(false);
        selectMode.SetActive(true);
    }

    public void PauseGame()
    {
        if(pause == 0)
        {
            pause = 1;
            Time.timeScale = 0;  
        }
        else
        {
            pause = 0;
            Time.timeScale = 1;
        }
    }

    public void NormalMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HardMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

   public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
