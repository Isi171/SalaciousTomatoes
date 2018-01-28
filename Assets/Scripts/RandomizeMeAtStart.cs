using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeMeAtStart : MonoBehaviour
{
    [SerializeField] private MaterialSwapper head;
    [SerializeField] private MaterialSwapper body;
    [SerializeField] private MaterialSwapper limbs;

    public void Start()
    {
        if (head != null)
        {
            head.Randomize();
        }
        if (body != null)
        {
            body.Randomize();
        }
        if (limbs != null)
        {
            limbs.Randomize();
        }
    }
}
