using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealOrDamage : MonoBehaviour
{
    private PlayerStats stats;
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    

    public void damagePlayer(int damage)
    {
        stats.currentHealth -= damage;
    }

    public void healPlayer(int heal)
    {
        stats.currentHealth += heal;
    }
}
