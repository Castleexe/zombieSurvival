using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Gun gun;
    [SerializeField] GameObject midPoint;

    CamShake camShake;
    GameObject camHolder;

    ParticleSystem particleSys;

    public float Health = 100;

    Score score;
    GameObject gameManager;
    public GameObject exp;

    void Awake()
    {
        gun = midPoint.GetComponent<Gun>();
        camHolder = GameObject.FindGameObjectWithTag("MainCamera");
        camShake = camHolder.GetComponent<CamShake>();
    }

    void Start()
    {
        particleSys = GetComponent<ParticleSystem>();
        gameManager = GameObject.Find("GameManager");
        score = gameManager.GetComponent<Score>();
    }

    void Update()
    {
        
    }

    void TakeDamage()
    {
        Health = Health - gun.bulletDmg;
        
        if (Health <= 0)
        {
            score.addScore();
            dropExp();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            particleSys.Play();
            TakeDamage();
        }
    }

    void dropExp()
    {
        int randomInt = Random.Range(0, 2);

        if(randomInt == 1)
        {
            Instantiate(exp, transform.position, Quaternion.identity);
        }
    }
}
