using Platformer2D;
using Platformer2D.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text gameOver,scoreText;
    [SerializeField]
    GameObject gameOverPanel;
    [SerializeField]
    Button resetButton;
    private void OnEnable()
    {
        GameManager.Instance.scoreUpdate += UpdateScore;
        GameManager.Instance.gameStatus += GameStatus;
    }
    
    public void ResetGame()
    {
        gameOver.text = string.Empty;
        scoreText.text = string.Empty;
        gameOverPanel.SetActive(false);
        scoreText.gameObject.SetActive(true);
        GameManager.Instance.controller.ChangeState(StateController.GameStates.end);
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.scoreUpdate -= UpdateScore;
            GameManager.Instance.gameStatus -= GameStatus;
        }
    }

    private void GameStatus(bool obj)
    {
        gameOverPanel.SetActive(true);
        scoreText.gameObject.SetActive(false);
        Debug.Log("Game won:" + obj + "   Score:" + ServiceLocator.GetService<IScoreHandler>().TotalCoinsCollected() * 10);
        bool isGameWon = ServiceLocator.GetService<IScoreHandler>().CheckForGameWin();
        if (isGameWon)
            gameOver.text = "Level Finish\nGame Over\nScore:" + ServiceLocator.GetService<IScoreHandler>().TotalCoinsCollected() * 10;
        else
            gameOver.text = "Player Died\nGameOver\nScore:" + ServiceLocator.GetService<IScoreHandler>().TotalCoinsCollected() * 10;

    }

    private void UpdateScore()
    {
        scoreText.text = "CoinsCollected:"+ ServiceLocator.GetService<IScoreHandler>().TotalCoinsCollected() + "\nScore:" + ServiceLocator.GetService<IScoreHandler>().TotalCoinsCollected() * 10;
    }
    private void Start()
    {
        gameOverPanel.SetActive(false);
        resetButton.onClick.AddListener(ResetGame);
    }
}
