using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextHandler : MonoBehaviour
{
    [SerializeField] private RectTransform scoreTextRectTransform;
    [SerializeField] private Text scoreText;
    [SerializeField] private float distance;
    [SerializeField] private float distanceDelta;
    private Vector3 scoreTextOriginalPosition;
    private bool running;
    
    private void Start()
    {
        scoreTextOriginalPosition = scoreTextRectTransform.localPosition;
    }

    private void Update()
    {
        if (!running)
        {
            return;
        }
        
        Vector3 position = scoreTextRectTransform.localPosition;
        position.y += distanceDelta;
        scoreTextRectTransform.localPosition = position;
        if (position.y - scoreTextOriginalPosition.y > distance)
        {
            StopScore();
        }
    }

    private void StopScore()
    {
        scoreText.text = "";
        running = false;
        scoreTextRectTransform.localScale = new Vector3(0, 0, 1);
    }

    public void TriggerScore(int amount)
    {
        scoreText.text = amount.ToString();
        running = true;
        scoreTextRectTransform.localScale = new Vector3(1, 1, 1);
        scoreTextRectTransform.localPosition = scoreTextOriginalPosition;
    }
}
