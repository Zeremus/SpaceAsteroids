using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitScript : MonoBehaviour
{
    public bool gameIsOver;
    public GameStateManager gameManager;
    public Movement asteroidMov;

    void OnCollisionEnter2D (Collision2D col)
    {
        gameManager.ActivateGameOverCanvas();
        asteroidMov.StopMotion();
        gameIsOver = true;
    }
}
