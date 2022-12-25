using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthDisplay : MonoBehaviour
{
    public Text healthText;
    private PlayerStats stats;

    private void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HP : " + stats.currentHealth + " / " + stats.maxHealth;
        if (Input.GetKeyDown(KeyCode.H))
        {
            stats.currentHealth--;
        }
    }
}
