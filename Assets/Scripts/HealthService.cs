using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthService : MonoBehaviour {

    public int health = 100;
    protected int currentHealth = 100;

    public uint splitChunksCount = 0;
    public GameObject chunkPrefab;
    public Vector3 spawnOffset;
    
    protected virtual void Start () {
        currentHealth = health;
	}

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        
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
        SceneManager.LoadScene("EndMenu");
        Destroy(gameObject);
    }
    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 25;
        style.normal.textColor = new Color(1, 1, 1, 1f);
        string fpsText = string.Format("{0}", currentHealth);
        GUI.Label(rect, fpsText, style);
    }
}
