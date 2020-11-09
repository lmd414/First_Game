using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float MaxHealth = 100f;
    private float currentHealth;

    public float StartTimeBtwDmg;
    public float TimeBtwDmg;

    public HealthBar bar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        bar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        TimeBtwDmg -= Time.deltaTime;
        CheckHP();
        RegenHP();
    }

    void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        bar.SetCurrentHealth(currentHealth);
    }
    void CheckHP()
    {
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    void RegenHP()
    {
        if(currentHealth < 100)
        {
            currentHealth += 0.5f * Time.deltaTime;
            bar.SetCurrentHealth(currentHealth);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            if(TimeBtwDmg <= 0)
            {
                TakeDamage(10);
                TimeBtwDmg = StartTimeBtwDmg;
            }
        }
    }
}
