using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEnabler : MonoBehaviour {

    [SerializeField] private InputHandler ih;

    public void EnableInput() {
        ih.stopInput = false;
    }

    public void DisableInput() {
        ih.stopInput = true;
    }

}
