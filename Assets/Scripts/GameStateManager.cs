using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameObject youWinCanvas;
    public GameObject gameOverCanvas;
    public PlayerScript player;

    public void ActivateGameOverCanvas()
    {
        gameOverCanvas.SetActive(true);
    }

    public void ActivateYouWinCanvas()
    {
        youWinCanvas.SetActive(true);
    }
}
