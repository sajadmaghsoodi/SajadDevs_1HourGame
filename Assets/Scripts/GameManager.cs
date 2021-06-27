using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    [SerializeField] private GameObject _losePanel;

    private void Awake()
    {
        _instance = this;
    }

    public static void EndGame()
    {
        Player.Active = false;
        Camera.Active = false;
        _instance._losePanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Player.Active = true;
        Camera.Active = true;
    }

}
