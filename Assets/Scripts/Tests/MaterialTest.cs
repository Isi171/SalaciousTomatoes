using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTest : MonoBehaviour {

    [SerializeField] private SkinnedMeshRenderer smr;
    [SerializeField] Material m;

	// Use this for initialization
	void Start () {
        smr.material = m;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
