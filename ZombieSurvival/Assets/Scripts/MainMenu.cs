using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject helpMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void loadSettings()
    {
        Debug.Log("loading settings");
    }

    public void closeGame()
    {
        Debug.Log("closing game");
        Application.Quit();
    }

    public void openHelpMenu()
    {
        helpMenu.SetActive(true);
    }

    public void closeHelpMenu()
    {
        helpMenu.SetActive(false);
    }
}
