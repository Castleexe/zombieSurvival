using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public Text CoinText;
    public static int score = 0;

    bool devMode;
    public int giveCoinsAmount = 100;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "0"; //score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        addCoins();

        if (Input.GetKeyDown(KeyCode.M))
        {
            Coin.Coins += giveCoinsAmount;
        }
    }

    public void addScore()
    {
        score++;
        ScoreText.text = score.ToString();
    }

    public void addCoins()
    {
        CoinText.text = Coin.Coins.ToString();
    }

}
