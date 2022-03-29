using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool canShoot = true;
    public float fireRate = 0.5f;
    public float nextShot;
    public GameObject firePoint;
    public float shipSpeed = 5.0f;
    public Rigidbody2D shipRB;
    public KeyCode leftKey, rightKey, fireKey;
    public GameObject missile;
    public int playerLife = 1;
    public GameStateManager gameManager;
    public GameObject audioClip;
    public bool stopGame = false;

    // Start is called before the first frame update
    void Start()
    {
      shipRB = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(stopGame == false)
        {
            if (Input.GetKey(leftKey) && shipRB.transform.position.x >= -11)
            {
                shipRB.velocity = new Vector2(-shipSpeed, 0);
            }else if ( Input.GetKey(rightKey) && shipRB.transform.position.x <= 11) 
            {
                shipRB.velocity = new Vector2(shipSpeed, 0);
             }else
            {
                shipRB.velocity = new Vector2(0, 0);
            }

            if (Time.time > nextShot)
            {
                canShoot = true;
            }

            if (Input.GetKeyDown(fireKey) && canShoot == true)
            {
                GameObject newMissile = Instantiate(missile, firePoint.transform);
                canShoot = false;
                nextShot = Time.time + fireRate;
                Destroy(newMissile, 2.0f);
            }
        }

        if (playerLife == 0)
        {
            gameManager.ActivateGameOverCanvas();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject explosion = Instantiate(audioClip, transform.position, Quaternion.identity);
        Destroy (explosion, 3.0f);
        playerLife = 0;
        Destroy(gameObject);
        gameManager.ActivateGameOverCanvas();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject explosion = Instantiate(audioClip, transform.position, Quaternion.identity);
        Destroy (explosion, 3.0f);
        playerLife = 0;
        Destroy(gameObject);
        gameManager.ActivateGameOverCanvas();
    }

    public void StopPlayer()
    {
        shipSpeed = 0f;
        stopGame = true;
        shipRB.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    public void Invulnerable()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
