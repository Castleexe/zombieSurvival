using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    [SerializeField] GameObject midPoint;
    Gun gun;

    public float bulletForce = 50f;
    public float coolTime = 0.5f;

    bool isCooling = false;

    void Start()
    {
        gun = midPoint.GetComponent<Gun>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (isCooling == false)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);

            StartCoroutine(cooldown()); 
        }
    }

    IEnumerator cooldown()
    {
        isCooling = true;
        yield return new WaitForSeconds(coolTime);
        isCooling = false;
    }
}
