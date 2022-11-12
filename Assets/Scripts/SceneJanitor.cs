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

    int lastSceneId = 0;
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
        Debug.Log("go Back");
        SceneManager.LoadScene(lastSceneId);
    }

    private void openLeaderboard()
    {
        Debug.Log("Load LeaderBoard");
        try
        {
            lastSceneId = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("LeaderBoard");
        }
        catch (Exception)
        {
            Debug.Log("Scene (LeaderBoard) nicht gefunden");
            throw;
        }
    }

    private void openSettings()
    {
        Debug.Log("Load Settings");
        try
        {
            lastSceneId = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("Settings");
        }
        catch (Exception)
        {
            Debug.Log("Scene (Settings) nicht gefunden");
            throw;
        }
    }

    private void closeGame()
    {
        lastSceneId = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Spiel beenden");
        Application.Quit();
    }

    private void startGame()
    {
        try
        {
            lastSceneId = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("GameScene");
        }
        catch (Exception)
        {
            Debug.Log("Scene (GameScene) nicht gefunden");
            throw;
        }
    }
}
