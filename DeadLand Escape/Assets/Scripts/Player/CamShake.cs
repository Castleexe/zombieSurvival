using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public Animator camAnim;

    public void shakeCam()
    {
        camAnim.SetTrigger("Shake");
    }
}
