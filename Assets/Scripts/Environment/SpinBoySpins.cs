using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBoySpins : MonoBehaviour
{
    public float spinSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, spinSpeed);
        transform.Rotate(Vector3.forward, spinSpeed);
        transform.Rotate(Vector3.up, spinSpeed);
    }
}
