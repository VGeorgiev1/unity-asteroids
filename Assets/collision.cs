using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class collision : MonoBehaviour {

    public GameObject asteroid;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {

            Destroy(col.gameObject);
            Destroy(gameObject);
            Vector3 pos = new Vector3(30,0,30);
            Instantiate(asteroid, pos, transform.rotation);
        }
    }
}
