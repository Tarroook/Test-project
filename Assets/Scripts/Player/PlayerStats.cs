using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float speed = 10f;
    public float sprintSpeed = 6f;
    public int defense = 5;
    public float jumpHeight = 3f;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        
        else if (currentHealth < 0)
            currentHealth = 0;
    }
}
