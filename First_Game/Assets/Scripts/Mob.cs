using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;

    public float speed = 2.5f;

    public float setDazedTime = 0.5f;
    private float DazedTime;
    private bool Dazed = false;


    void Start()
    {
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        CheckHealth();
        CheckDazed();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Playerr"))
        {
            transform.Translate(speed * Time.deltaTime * 55, 0, 0);
        }
        else if (collision.collider.CompareTag("Bullet"))       //else if hit bullet
        {
            TakeDamage(25);  //take dmg
            BeDazed();                                    //become dazed
        }

    }

    void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
    }

    void CheckHealth()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    void BeDazed()
    {
        speed = 0f;
        DazedTime = setDazedTime;
        Dazed = true;
    }
    void CheckDazed()
    {
        if (DazedTime <= 0)
        {
            speed = 2.5f;
        }
        else
        {
            DazedTime -= Time.deltaTime;
        }
    }
}
