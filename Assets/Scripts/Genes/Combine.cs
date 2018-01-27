using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour {
	MaterialSwapper oldArms;
	MaterialSwapper oldBody;
	MaterialSwapper oldHead;
	MaterialSwapper newArms;
	MaterialSwapper newBody;
	MaterialSwapper newHead;

	void Start (){
		oldArms = GameObject.FindGameObjectWithTag ("OldMonster").transform.Find ("Arms").gameObject.GetComponent<MaterialSwapper>();
		oldBody = GameObject.FindGameObjectWithTag ("OldMonster").transform.Find ("Body").gameObject.GetComponent<MaterialSwapper>();
		oldHead = GameObject.FindGameObjectWithTag ("OldMonster").transform.Find ("Head").gameObject.GetComponent<MaterialSwapper>();
		newArms = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Arms").gameObject.GetComponent<MaterialSwapper>();
		newBody = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Body").gameObject.GetComponent<MaterialSwapper>();
		newHead = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Head").gameObject.GetComponent<MaterialSwapper>();
	}

	public void PressButton (){
		oldArms.GeneLogic (newArms.CurrentGene);
	}
}
