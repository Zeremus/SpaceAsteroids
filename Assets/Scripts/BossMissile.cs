using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissile : MonoBehaviour
{
  public Rigidbody2D missileRB;
  // Start is called before the first frame update
  void Start()
  {
      missileRB.AddForce(transform.up * 300); 
      Destroy(gameObject, 2.0f); 
  }

    // Update is called once per frame
  void Update()
  {

  }

}
