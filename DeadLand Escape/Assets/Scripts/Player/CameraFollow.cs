using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    float smoothSpeed = 0.125f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 disiredPosition = new Vector3(player.position.x, player.position.y, -10);
        Vector3 smoothedPosion = Vector3.Lerp(transform.position, disiredPosition, smoothSpeed);
        transform.position = smoothedPosion;
    }
}
