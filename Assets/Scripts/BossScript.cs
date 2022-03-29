using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
  public bool gameOn = true;
  public GameObject gameWonCanvas;
  public int lifePoints = 12;

  public Rigidbody2D bossRB;

  public GameObject bossMissile;

  public float nextAttack = 1.0f;

  public bool canAttack;

  public float attackRate = 2.0f;

  public PlayerScript playerScript;

  public BossMissile bossAttack;

  public GameObject firePoint;
  public GameObject firePoint2; //165º
  public GameObject firePoint3; //150º
  public GameObject firePoint4; //195º
  public GameObject firePoint5; //210º
  public GameObject firePoint6; //135º
  public GameObject firePoint7; //225º
  public GameObject audioClip;
  public GameObject sound;
    // Start is called before the first frame update
  void Start()
  {
    canAttack = false;
    bossRB.velocity = new Vector2(3.0f, 0); 
  }

    // Update is called once per frame
  void Update()
  {
    if(playerScript.playerLife <= 0)
    {
      gameOn = false;
      bossRB.velocity = new Vector2 (0.0f, 0.0f);
    }
    if (lifePoints < 7)
    {
      attackRate = 2.0f;
      bossRB.AddForce (transform.up * 500);
    }

    if (gameOn)
    {

      if (Time.timeSinceLevelLoad > nextAttack)
      {
        canAttack = true;
      } 
      if (canAttack && lifePoints > 6)
      {
        GameObject newMissile = Instantiate(bossMissile, firePoint.transform.position, Quaternion.Euler(0, 0, 180));
        canAttack = false;
        nextAttack = Time.timeSinceLevelLoad + attackRate;
        Destroy(newMissile, 2.0f);
      } 
      if (canAttack && lifePoints < 7)
      {
        GameObject newMissile = Instantiate(bossMissile, firePoint.transform.position, Quaternion.Euler(0, 0, 180));
        GameObject newMissile2 = Instantiate(bossMissile, firePoint2.transform.position, Quaternion.Euler(0, 0, 165));
        GameObject newMissile3 = Instantiate(bossMissile, firePoint4.transform.position, Quaternion.Euler(0, 0, 195));
        GameObject newMissile4 = Instantiate(bossMissile, firePoint5.transform.position, Quaternion.Euler(0, 0, 210));
        GameObject newMissile5 = Instantiate(bossMissile, firePoint3.transform.position, Quaternion.Euler(0, 0, 150));
        GameObject newMissile6 = Instantiate(bossMissile, firePoint6.transform.position, Quaternion.Euler(0, 0, 135));
        GameObject newMissile7 = Instantiate(bossMissile, firePoint7.transform.position, Quaternion.Euler(0, 0, 225));
        canAttack = false;
        nextAttack = Time.timeSinceLevelLoad + attackRate;
      }

      if (bossRB.transform.position.x <= -8)
      {
        bossRB.velocity = new Vector2 (3.0f, 0f);
      } 

      if (bossRB.transform.position.x >= 8)
      {
        bossRB.velocity = new Vector2 (-3.0f, 0f);
      }

      if (lifePoints <= 0)
      {
        GameObject explosion = Instantiate(audioClip, transform.position, Quaternion.identity);
        playerScript.shipSpeed = 0;
        Destroy(gameObject);
        gameWonCanvas.SetActive(true);
        playerScript.Invulnerable();
        playerScript.StopPlayer();
      }
    }
  }

  void OnCollisionEnter2D (Collision2D col)
  {
    lifePoints--;
    GameObject explosionSound = Instantiate(sound, transform.position, Quaternion.identity);
    Destroy(explosionSound, 3.0f);
  }
}
