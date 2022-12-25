using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillItem : MonoBehaviour
{
    public void itemDelete()
    {
        GameObject.Destroy(gameObject);
    }
}
