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

    public float StartTimeBtwAttk;
    public float TimeBtwAttk;

    public float bulletForce = 20f; //how fast bullet will go

    public Transform shootingPos; //gets location of shooting position (where bullet will come from)
    public GameObject bullet; //gets sprite of bullet

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
        TimeBtwAttk -= Time.deltaTime;
        TimeBtwDmg -= Time.deltaTime;
        Shoot();
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
    void Shoot()
    {
        if(TimeBtwAttk <= 0)
        {
            if(Input.GetButtonDown("Fire1")) //instantiate bullet with force
            {
                GameObject bullet1 = Instantiate(bullet, shootingPos.position, shootingPos.rotation);
                Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
                rb.AddForce(shootingPos.right * bulletForce, ForceMode2D.Impulse);
                TimeBtwAttk = StartTimeBtwAttk; //reset shooting cd
            }
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
