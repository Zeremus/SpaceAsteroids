using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public Rigidbody2D meteorRB;
    private Animator animator;
    public GameObject fragment;
    private float attackRate = 0.5f;
    public float nextAttack;
    public bool canAttack = true;
    public GameObject audioClipObject;
    public Movement enemyMov;

    public bool gameOver = false;
    public PlayerScript playerScript;
    public LimitScript limitScript;
    
    void Start()
    {
      canAttack = false;
      nextAttack = Random.Range(1f, 6f);
      attackRate = Random.Range(3f, 10f);
      animator = GetComponent<Animator>();
      animator.enabled = false; 
    }

    void Update()
    {
      if (limitScript.gameIsOver)
      {
        gameOver = true;
      }
      if (playerScript.playerLife == 0)
      {
        gameOver = true;
      }
      if (gameOver == false)
      {
        if(Time.timeSinceLevelLoad > nextAttack)
        {
          canAttack = true;
        }
        if (canAttack)
        {
          GameObject newFragment = Instantiate(fragment, gameObject.transform.position, Quaternion.identity);
          canAttack = false;
          nextAttack = Time.timeSinceLevelLoad + attackRate;
          Destroy(newFragment, 2.0f);
        }
      }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
      enemyMov.DestroyMeteor();
      GameObject explosionSound = Instantiate (audioClipObject, transform.position, Quaternion.identity);
      Destroy(gameObject, 0.0f);
      animator.enabled = true;  
    }

}
