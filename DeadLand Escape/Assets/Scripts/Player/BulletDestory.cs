using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestory : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destoryBullet());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator destoryBullet()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
