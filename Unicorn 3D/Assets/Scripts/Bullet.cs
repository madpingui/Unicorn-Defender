using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Vector3 initialVelocity;

    public static float minVelocity = 5f;

    private Vector3 lastFrameVelocity;
    private Rigidbody rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        initialVelocity = transform.forward * minVelocity;
        rb.velocity = initialVelocity;
        Invoke("destroy", 4f);
    }

    private void Update()
    {
        lastFrameVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().healthLeft();
        }
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        GetComponent<Renderer>().material.color = newColor;
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
