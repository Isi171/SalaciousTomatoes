﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveHandler : MonoBehaviour {
    public Text timerText;
    [SerializeField] private Text geneRequestText;
    [SerializeField] private Image icon;

    public Objective objective {
        get; set;
    }

    public void SetObjective(string s) {
        geneRequestText.text = s;
    }

    public void SetTimer(string counter)
    {
        timerText.text = counter;
    }
    
}
