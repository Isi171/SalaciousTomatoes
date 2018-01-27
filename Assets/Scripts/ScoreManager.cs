using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    [SerializeField] private GameObject highScore;
    [SerializeField] private Text score;

    void Start () {
        int lastScore = PlayerPrefs.GetInt("Score");

        score.text = lastScore.ToString();

        if (lastScore > PlayerPrefs.GetInt("Highscore", 0)) {
            highScore.SetActive(true);
            PlayerPrefs.SetInt("Highscore", lastScore);
        }
    }

    public void Retry() {
        SceneManager.LoadScene("Game");
    }

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }

}
