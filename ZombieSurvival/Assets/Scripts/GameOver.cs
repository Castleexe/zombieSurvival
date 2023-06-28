using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text gameOverScoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScoreText.text = "Score: " + Score.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        Score.score = 0;
        SceneManager.LoadScene("Main");
    }

}
