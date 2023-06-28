using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    public GameObject gun;
    public GameObject bulletPrebaf;
    public SpriteRenderer gunSpriteRen;

    public float bulletDmg = 50f;
    public bool enemiesAlive; 

    Rigidbody2D rb;
    Vector2 mousePos;
    Vector3 bulletDefaultScale = new Vector3(0.3f, 0.3f, 1);

    public Score scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        bulletPrebaf.transform.localScale = bulletDefaultScale;
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = player.transform.position;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); 

        gunLook();

    }

    void findEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject[] allEnemies;
        GameObject closestEnemy = null;
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (allEnemies.Count() > 0)
        {
            enemiesAlive = true;
            foreach (GameObject currentenemy in allEnemies)
            {
                float distanceToEnemy = (currentenemy.transform.position - player.transform.position).sqrMagnitude;

                if (distanceToEnemy < distanceToClosestEnemy)
                {
                    distanceToClosestEnemy = distanceToEnemy;
                    closestEnemy = currentenemy;
                }
            }

            Debug.DrawLine(player.transform.position, closestEnemy.transform.position);

            Vector2 lookDir = new Vector2(closestEnemy.transform.position.x, closestEnemy.transform.position.y) - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            rb.rotation = angle;

            if (angle > -90 && angle < 90)
            {
                gunSpriteRen.flipY = false;
            }
            else
            {
                gunSpriteRen.flipY = true;
            }
        }
        else
        {
            enemiesAlive = false;
        }
    }

    void gunLook()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (angle > -90 && angle < 90)
        {
            gunSpriteRen.flipY = false;
        }
        else
        {
            gunSpriteRen.flipY = true;
        }
    }


    int previousScore = 0;
    void gunBigger()
    {
        
        int currentScore = Score.score;
        if(Score.score > previousScore)
        {
            bulletPrebaf.transform.localScale += new Vector3(1, 1, 0);
            previousScore++;
        }
    }

}
