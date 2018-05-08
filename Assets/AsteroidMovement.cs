using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {
    public GameObject bullet;
    float speed = 5f;
    public float bulletDelay = 3.0f;
    private IEnumerator coroutine;
    // Update is called once per frame
    int direction = 1;
    void Start()
    {
        coroutine = WaitAndShoot(bulletDelay);
        StartCoroutine(coroutine);
    }
    void Update() {
        float x;
        float z;
        
        if (transform.position.x < -6 || transform.position.z < -4)
        {
            x = Random.Range(-20, 20);
            if (x > 0)
            {
                direction = 1;
            }
            else {
                direction = -1;
            }
            if (x > 10 || x < -10) {
                z = Random.Range(4, -4);
            }
            else
            {
                z = 7;
            }
            transform.position = new Vector3(x, 0f, z);
        }
        else {
            if (direction == 1)
            {
                x = transform.position.x - 4f;
                z = transform.position.z - 4f;
            }
            else {
                x = transform.position.x + 4f;
                z = transform.position.z - 4f;
            }

        }
        
        Vector3 displacement = new Vector3(x, 0f, z);
        transform.position = Vector3.MoveTowards(transform.position, displacement, speed * Time.deltaTime);
        transform.Rotate(0,80 * Time.deltaTime,0);

    }
    private IEnumerator WaitAndShoot(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(bullet, new Vector3(transform.position.x,0, transform.position.x), transform.rotation);
        }
    }
    void OnCollisionEnter(Collision col)
    {
       
        if (col.gameObject.tag == "Enenmy")
        {
            Destroy(col.gameObject);
        }
    }
}
