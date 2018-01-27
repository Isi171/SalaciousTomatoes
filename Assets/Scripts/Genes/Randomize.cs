using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize : MonoBehaviour {
	
	MaterialSwapper arms;
	MaterialSwapper body;
	MaterialSwapper head;

	void Start (){
		arms = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Arms").gameObject.GetComponent<MaterialSwapper>();
		body = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Body").gameObject.GetComponent<MaterialSwapper>();
		head = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Head").gameObject.GetComponent<MaterialSwapper>();
	}

	// I'm sorry Mario, but your Random logic is in another class

	public void PressButton (){
		arms.Randomize ();
		body.Randomize ();
		head.Randomize ();
	}
}
