using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour
{
    [SerializeField] private Text creditsTitle;
    
    private static readonly string[] creditsTitles =
    {
        "Brought to you by",
        "Collaborators, test subjects and guinea pigs",
        "In loving memory of",
        "Heroes of the working day",
        "Geniuses, billionaires, playboys, philantrophists",
        "We only just met 48 hours ago",
        "Not the heroes that we deserve, but those that we need",
        "Sexier than y'all",
        "Boy, are our eyes tired",
        "Please send help",
        "What were we even thinking?",
        "Wall of shame",
        "Liquefying cute monsters for science",
        "This commercial paid for by",
        "??????????",
        "This time we ate somewhat decently (maybe)"
    };

    private void Start()
    {
        creditsTitle.text = CustomRandom.From(creditsTitles);
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
