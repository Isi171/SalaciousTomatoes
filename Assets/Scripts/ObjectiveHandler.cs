using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveHandler : MonoBehaviour {
    [SerializeField] private Text geneRequestText;
    [SerializeField] private Text timerText;
    [SerializeField] private Image icon;

    public Objective objective {
        get; set;
    }

    public void SetObjective(string s) {
        geneRequestText.text = s;
    }

    public void SetTimer(string s) {
        timerText.text = s;
    }

}
