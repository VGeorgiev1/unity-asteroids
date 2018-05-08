using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidbulletCollision : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {

            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
