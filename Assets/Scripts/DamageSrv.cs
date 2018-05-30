using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageSrv : MonoBehaviour {

    public int damage = 10;
    public string tagToDamage = "Enemy";
    public GameObject hitAnimation;
    //public Text healthBar;
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(hitAnimation, transform.position, transform.rotation);
            
        //healthBar.text = (Int64.Parse(healthBar.text) - damage).ToString();

        if(collision.gameObject.CompareTag(tagToDamage))
        {
        
            HealthService healthSrv = collision.gameObject.GetComponent<HealthService>();
            if (healthSrv)
                healthSrv.DealDamage(damage);
        }
    }
}
