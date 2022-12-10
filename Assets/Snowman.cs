using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman : MonoBehaviour
{
    [SerializeField]
    private int healthPoints;
    private CharacterMovement connected;
    // Start is called before the first frame update
    void Start()
    {
        connected = GameObject.Find("Character").GetComponent<CharacterMovement>();
    }

    // Update is called once per frame

    public void tookDamage()
    {
        healthPoints--;
    }
    void Update()
    {

        if(healthPoints == 0)
        {
             
             connected.startDeath(); 
            Destroy(this.gameObject);
        }
    }

}
