using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HealthService : MonoBehaviour {
    public Text healthBar;
    public int health = 100;
    protected int currentHealth = 100;
    public bool toEndGameOnDeath = false;
    public uint splitChunksCount = 0;
    public GameObject chunkPrefab;
    public Vector3 spawnOffset;
    public GameObject deadthAnimation;
    protected virtual void Start () {
        currentHealth = health;
        healthBar.text = currentHealth.ToString();

    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        if (toEndGameOnDeath) {
            healthBar.text = currentHealth.ToString();
        }
        if (currentHealth <= 0)
        {
            OnDeath();
        }
        
    }
    public int getHealth() {
        return currentHealth;
    }
    protected void OnDeath()
    {
        if (chunkPrefab != null && splitChunksCount > 0)
        {
            float step = 360f / splitChunksCount;
            for (int i = 0; i < splitChunksCount; i++)
            {
                float angle = step * i;
                Vector3 spawnPosition = gameObject.transform.position;
                spawnPosition += Quaternion.Euler(0, angle, 0) * spawnOffset;
                Instantiate(chunkPrefab, spawnPosition, gameObject.transform.rotation);
            }
        }
        Instantiate(deadthAnimation, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(deadthAnimation);
        if (toEndGameOnDeath)
        {
            SceneManager.LoadScene("EndMenu");
        }
       
    }
}
