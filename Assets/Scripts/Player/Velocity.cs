using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    Vector3 posX;
    Vector3 posY;
    Vector3 posZ;
    public Vector3 velocity;
    public float currentSpeed;
    public float upwardsMomentum;

    private void Start()
    {
        StartCoroutine(getVelocity());
    }
    
    IEnumerator getVelocity()
    {
        while (true)
        {
            Vector3 prevPosX = new Vector3(transform.position.x, 0f, 0f);
            Vector3 prevPosY = new Vector3(0f, transform.position.y, 0f);
            Vector3 prevPosZ = new Vector3(0f, 0f, transform.position.z);
            Vector3 prevPosXZ = new Vector3(transform.position.x, 0f, transform.position.z);
            Vector3 prevPos = transform.position;

            yield return new WaitForFixedUpdate();

            posX = new Vector3(transform.position.x, 0f, 0f);
            posY = new Vector3(0f, transform.position.y, 0f);
            posZ = new Vector3(0f, 0f, transform.position.z);
            Vector3 velocityXZ = new Vector3(transform.position.x, 0f, transform.position.z);
            Vector3 velocityY = new Vector3(0f, transform.position.y, 0f);
            Vector3 velocityZ = new Vector3(0f, 0f, transform.position.z);

            velocity.x = Mathf.RoundToInt(Vector3.Distance(posX, prevPosX) / Time.fixedDeltaTime);
            velocity.y = Mathf.RoundToInt(Vector3.Distance(posY, prevPosY) / Time.fixedDeltaTime);
            velocity.z = Mathf.RoundToInt(Vector3.Distance(posZ, prevPosZ) / Time.fixedDeltaTime);

            currentSpeed = Mathf.RoundToInt(Vector3.Distance(velocityXZ, prevPosXZ) / Time.fixedDeltaTime);
            //float upwardsMomentum = Vector3.Angle(velocityY, velocityZ);
        }
    }
}
