using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndPanel : MonoBehaviour
{
    [SerializeField] private GameObject _gameScreenpanel;
    [SerializeField] private Button _gameRestartButton;

    private void Start()
    {
        FindObjectOfType<GameCompleteZone>().OnGameEnd += EneableScreen;
        FindObjectOfType<PlayerTriggerListner>().OnGameEnd += EneableScreen;
    }

    private void EneableScreen()
    {
        _gameScreenpanel.SetActive(true);
        _gameRestartButton.onClick.AddListener(() => RestartLevel());
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
}
