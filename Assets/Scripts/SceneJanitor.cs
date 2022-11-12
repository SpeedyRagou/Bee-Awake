using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneJanitor : MonoBehaviour
{
    public Button btn_startGame;
    public Button btn_closeGame;
    public Button btn_settings;
    public Button btn_leaderboard;
    public Button btn_Back;


    // Start is called before the first frame update
    void Awake()
    {
        btn_startGame.onClick.AddListener(() => startGame());
        btn_closeGame.onClick.AddListener(() => closeGame());
        btn_settings.onClick.AddListener(() => openSettings());
        btn_leaderboard.onClick.AddListener(() => openLeaderboard());
        btn_Back.onClick.AddListener(() => goBack());
    }

    private void goBack()
    {
        throw new NotImplementedException();
    }

    private void openLeaderboard()
    {
        Debug.Log("Load LeaderBoard");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void openSettings()
    {
        Debug.Log("Load Settings");
        throw new NotImplementedException();
    }

    private void closeGame()
    {
        Debug.Log("Spiel beenden");
        Application.Quit();
    }

    private void startGame()
    {
        Debug.Log("start Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
