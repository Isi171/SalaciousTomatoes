using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize : MonoBehaviour
{
	public ObjectiveManager objectiveManager;
	MaterialSwapper limbs;
	MaterialSwapper body;
	MaterialSwapper head;

	void Start (){
		limbs = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Limbs").gameObject.GetComponent<MaterialSwapper>();
		body = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Body").gameObject.GetComponent<MaterialSwapper>();
		head = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Head").gameObject.GetComponent<MaterialSwapper>();
	}

	// I'm sorry Mario, but your Random logic is in another class

	public void PressButton (){
		limbs.Randomize ();
		body.Randomize ();
		head.Randomize ();
	}
}
