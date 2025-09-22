using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private Text totalTime;
    private float timer = 0;

    [SerializeField] private GameObject endScreenPanel;

    void Start()
    {
        PlayerController.OnPlayerHit += EndScreen;
    }
    
    void OnDestroy()
    {
        PlayerController.OnPlayerHit -= EndScreen;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Home()
    {
        AudioManager.Instance.PlaySound("Click");
        SceneManager.LoadScene("Main Menu");
        GameManager.Instance.playerStatus(false);
        endScreenPanel.SetActive(false);
    }

    public void Restart()
    {
        AudioManager.Instance.PlaySound("Click");
        SceneManager.LoadScene("Gameplay");
        endScreenPanel.SetActive(false);
    }

    public void EndScreen()
    {
        timerText.gameObject.SetActive(false);
        totalTime.text = "Time Survived:  " + timerText.text;
        endScreenPanel.SetActive(true);
    }
}
