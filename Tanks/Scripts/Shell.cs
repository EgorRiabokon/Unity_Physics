using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject explosion;
    private float speed = 0f;
    private float yspeed = 0f;
    private float mass = 10f;
    private float force = 2f;
    private float drag = 0.3f;
    private float gravity = -9.8f;
    private float gAccel;
    private float acceleration;


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "tank")
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        acceleration = force / mass;
        speed += acceleration * 1;
        gAccel = gravity / mass;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        speed *= (1 - Time.deltaTime * drag);
        yspeed += gAccel * Time.deltaTime;
        this.transform.Translate(0, yspeed, speed * Time.deltaTime);
    }
}
