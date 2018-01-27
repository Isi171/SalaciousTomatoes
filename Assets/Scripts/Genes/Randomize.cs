using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize : MonoBehaviour {

	MaterialSwapper Arms;
	MaterialSwapper Body;
	MaterialSwapper Head;

	void Start (){
		Arms = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Arms").gameObject.GetComponent<MaterialSwapper>();
		Body = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Body").gameObject.GetComponent<MaterialSwapper>();
		Head = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Head").gameObject.GetComponent<MaterialSwapper>();
	}

	// I'm sorry Mario, but your Random logic is in another class

	public void PressButton (){
		Arms.Randomize ();
		Body.Randomize ();
		Head.Randomize ();
	}
}
