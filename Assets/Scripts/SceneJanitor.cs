using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneJanitor : MonoBehaviour
{
    public Button btn_startGame = default;
    public Button btn_closeGame = default;
    public Button btn_settings = default;
    public Button btn_leaderboard = default;
    public Button btn_Back = default;

    int lastSceneId = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (btn_startGame != null)
        {
            btn_startGame.onClick.AddListener(() => startGame());
        }
        if (btn_closeGame != null)
        {
            btn_closeGame.onClick.AddListener(() => closeGame());
        }
        if (btn_settings != null)
        {
            btn_settings.onClick.AddListener(() => openSettings());
        }
        if (btn_leaderboard != null)
        {
            btn_leaderboard.onClick.AddListener(() => openLeaderboard());
        }
        if (btn_Back != null)
        {
            btn_Back.onClick.AddListener(() => goBack());

        }




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
            SceneManager.UnloadSceneAsync(lastSceneId);
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
            SceneManager.LoadScene("SettingsScene");
            SceneManager.UnloadSceneAsync(lastSceneId);
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
            SceneManager.UnloadSceneAsync(lastSceneId);
        }
        catch (Exception)
        {
            Debug.Log("Scene (GameScene) nicht gefunden");
            throw;
        }
    }
}
