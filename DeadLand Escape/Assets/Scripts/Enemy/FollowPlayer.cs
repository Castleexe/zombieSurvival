using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject player;

    bool colided = false;
    public float speed = 2f;

    GameObject spawner;
    EnemySpawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawner = GameObject.Find("GameManager");
        enemySpawner = spawner.GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = player.transform.position;

        if (colided == false)
        {
            moveTowards();
        }

    }

    void moveTowards()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        float dist = (player.transform.position - transform.position).sqrMagnitude;

        if (dist > 250)
        {
            transform.position = enemySpawner.spawnPoints[Random.Range(0, enemySpawner.spawnPoints.Length)].transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            colided = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            colided = false;
        }
    }
}
