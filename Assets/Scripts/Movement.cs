using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D movRB;
    public int numberOfMeteors = 15;
    public GameStateManager gameManager;
    public PlayerScript playerMov;

    public Rigidbody2D MovRB { get => movRB; set => movRB = value; }

    // Start is called before the first frame update
    void Start()
    {
        MovRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if (MovRB.transform.position.x <= -6)
       {
           MovRB.velocity = new Vector2 (5.0f, -0.3f);
       } 

       if (MovRB.transform.position.x >= 6)
       {
           MovRB.velocity = new Vector2 (-5.0f, -0.3f);
       }

       if (numberOfMeteors <= 0 && playerMov.playerLife == 1)
       {
            gameManager.ActivateYouWinCanvas();
            playerMov.StopPlayer();
            playerMov.Invulnerable();
            Destroy(gameObject);
       }

      if (playerMov.playerLife <= 0)
      {
          StopMotion();
      }
    }

    public void StopMotion()
    {
        MovRB.velocity = new Vector2 (0.0f, 0.0f);
    }

    public void DestroyMeteor()
    {
        numberOfMeteors--;
    }
}
