using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static int playerHealth;

    public TextMeshProUGUI playerHealthStatus;
    public GameObject Player;
    public GameObject Lose;
    public GameObject Win;
    public GameObject Timer;
    public GameObject RetryButton;
    public GameObject Rocket;
    public GameObject Camera;
    public GameObject RocketCamera;

    public static TextMeshProUGUI TimerStatus;
   

    private static bool gameOverStatus;
    private static bool gameWinStatus;
    private static DateTime startTime;

    void Start()
    {
        playerHealth = 100;
        gameOverStatus = false;
        gameWinStatus = false;
        Cursor.visible = false;
        startTime = DateTime.Now;
        RetryButton.GetComponent<Button>().onClick.AddListener(RetryOnClick);
        TimerStatus = Timer.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        playerHealthStatus.text = "" + playerHealth;
        if (gameOverStatus)
        {
            Lose.SetActive(true);
            RetryButton.SetActive(true);
            Player.SetActive(false);
            Cursor.visible = true;
        }
        if(gameWinStatus)
        {
            Win.SetActive(true);
            RetryButton.SetActive(true);
            Timer.SetActive(true);
            Player.SetActive(false);
            Cursor.visible = true;
            Rocket.GetComponent<Rigidbody>().AddForce(Vector3.up * 10f, ForceMode.Acceleration);
            Camera.SetActive(false);
            RocketCamera.SetActive(true);
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public static void Damage(int damage)
    {
        if(playerHealth > 0) 
            playerHealth -= damage;
        if (playerHealth <= 0)
        {
            gameOverStatus = true;
        }
    }

    public static void PlayerWin()
    {
        gameWinStatus = true;
        TimeSpan timeForSession = DateTime.Now - startTime;
        TimerStatus.text = $"Your time: {timeForSession.Hours:D2}:{timeForSession.Minutes:D2}:{timeForSession.Seconds:D2}";
    }

    public void RetryOnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
