using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyman : MonoBehaviour
{
    [SerializeField]
    private int healthPoints;
    private secondmovement connected;
    // Start is called before the first frame update
    void Start()
    {
        connected = GameObject.Find("Capsule").GetComponent<secondmovement>();
    }

    // Update is called once per frame

    public void tookDamage()
    {
        healthPoints--;
    }
    void Update()
    {

        if (healthPoints == 0)
        {

            connected.startDeath();
            Destroy(this.gameObject);
        }
    }
}
