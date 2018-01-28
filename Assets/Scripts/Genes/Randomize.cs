using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize : MonoBehaviour {
    public ObjectiveManager objectiveManager;
    [SerializeField] MaterialSwapper limbs;
    [SerializeField] MaterialSwapper body;
    [SerializeField] MaterialSwapper head;

    // I'm sorry Mario, but your Random logic is in another class

    public void PressButton() {
        limbs.Randomize();
        body.Randomize();
        head.Randomize();
    }
}
