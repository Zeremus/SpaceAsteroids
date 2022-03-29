using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentScript : MonoBehaviour
{
    public Rigidbody2D fragmentRB;
    // Start is called before the first frame update
    void Start()
    {
      fragmentRB = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
      fragmentRB.velocity = new Vector2 (0, -5.0f);  
    }
}
