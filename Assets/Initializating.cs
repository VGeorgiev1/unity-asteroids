using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializating : MonoBehaviour {
    public GameObject asteroid;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 6; i++) {
            if (i % 2 == 0)
            {
                Instantiate(asteroid, new Vector3(i + 11, 0, i - 10), transform.rotation);

            }
            else {
                Instantiate(asteroid, new Vector3(i - 11, 0, i + 10), transform.rotation);

            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
