using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    [SerializeField] private GameObject highScore;
    [SerializeField] private Text score;

    void Start () {
        PlayerPrefs.GetInt("Score");
    }

}
