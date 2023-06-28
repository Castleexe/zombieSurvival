using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int Coins = 0;

    Score scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        scoreScript = GameObject.Find("GameManager").GetComponent<Score>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Coins++;
            Destroy(gameObject);
        }
    }
}
