using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject gameplayUI;

    private bool playerActive;
    private bool gameOver;
    private bool gameStarted;
    private float score;

    public bool PlayerActive { get { return playerActive;}    }
    public bool GameOver { get { return gameOver; } }
    public bool GameStarted { get { return gameStarted; } }
    public float Score { get { return score; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        Assert.IsNotNull(mainMenu);
        Assert.IsNotNull(gameplayUI);

    }

    private void Start()
    {
        playerActive = false;
        gameOver = false;
        gameStarted = false;
        mainMenu.SetActive(true);
        gameplayUI.SetActive(false);
    }

    private void Update()
    {
        if (playerActive == true)
        {
            score += Time.deltaTime;
         }
    }

    public void PlayerCollided()
    {
        gameOver = true;
        playerActive = false;
        gameStarted = false;
    }

    public void PlayerStartedGame()
    {
        playerActive = true;
        gameplayUI.SetActive(true);

    }

    public void EnterGame()
    {
        gameStarted = true;
        mainMenu.SetActive(false);
    }
}
