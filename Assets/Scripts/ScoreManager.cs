using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    [SerializeField]
    private Text highScoreValue;

    [SerializeField] private Text congratulationsHighscore;
    [SerializeField] private Text score;
    [SerializeField] private Text thankYou;

    private string[] thankYous =
    {
        "Thank you for playing",
        "Your performance was adequate",
        "Science thanks you for your collaboration",
        "You saved Science!",
        "For Science. You monster.",
        "This has been a social experiment",
        "This has been a SUCCESSFUL social experiment",
        "Help! I am trapped inside the source code!",
        "In his house at R'lyeh, dead Cthulhu waits dreaming",
        "We both did a lot of things that you are going to regret",
        "You won! Or did you?",
        "From great Power comes great Current squared Resistance",
        "Here's to hoping the project lead never sees this...",
        "You did very good today",
        "Will anyone ever even read this?"
    };
    
    void Start ()
    {
        highScoreValue.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();

        thankYou.text = CustomRandom.From(thankYous);
        int lastScore = PlayerPrefs.GetInt("Score");

        score.text = lastScore.ToString();

        if (lastScore >= PlayerPrefs.GetInt("Highscore", 0)) {
            PlayerPrefs.SetInt("Highscore", lastScore);
            congratulationsHighscore.text = "NEW HIGH SCORE!";
        }
    }

    public void Retry() {
        SceneManager.LoadScene("Game");
    }

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }

}
