﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob1 : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;

    public float speed = 3f;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        CheckHealth();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Playerr"))
        {
            transform.Translate(speed * Time.deltaTime * 30, 0, 0);
        }
        //else if hit bullet
        //take dmg
    }

    void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
    }

    void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
