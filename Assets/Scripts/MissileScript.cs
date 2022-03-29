using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public Rigidbody2D missileRB;
    // Start is called before the first frame update
    void Start()
    { 
      missileRB.AddForce(transform.up * 300);  
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject, 0.0f);   
    }
}
