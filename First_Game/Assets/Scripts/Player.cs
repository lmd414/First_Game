using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float MaxHealth = 100f;
    private float currentHealth;

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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
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
}
