using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnowPhysics : MonoBehaviour
{
    Rigidbody rb;
    private int flag = 0;
    [SerializeField]
    private int shot;
    private Enemyman damager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        damager = GameObject.Find("Enemyman").GetComponent<Enemyman>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (flag == 0)
        {
            rb.AddForce(Vector2.right * shot, ForceMode.Impulse);
            rb.AddForce(Vector2.up * 3.0f, ForceMode.Impulse);
            flag = 1;
        }
        if (transform.position.y < -7.0f)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name != "Character")
        {
            Destroy(this.gameObject);
        }
        if (collision.collider.name == "Enemyman")
        {
            damager.tookDamage();
        }
    }
}

