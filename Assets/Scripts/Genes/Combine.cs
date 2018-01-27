using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour {
	public ObjectiveManager objectiveManager;
	public Randomize randomizer;
	MaterialSwapper currentArms;
	MaterialSwapper currentBody;
	MaterialSwapper currentHead;
	MaterialSwapper newArms;
	MaterialSwapper newBody;
	MaterialSwapper newHead;

	void Start (){
		currentArms = GameObject.FindGameObjectWithTag ("CurrentMonster").transform.Find ("Arms").gameObject.GetComponent<MaterialSwapper>();
		currentBody = GameObject.FindGameObjectWithTag ("CurrentMonster").transform.Find ("Body").gameObject.GetComponent<MaterialSwapper>();
		currentHead = GameObject.FindGameObjectWithTag ("CurrentMonster").transform.Find ("Head").gameObject.GetComponent<MaterialSwapper>();
		newArms = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Arms").gameObject.GetComponent<MaterialSwapper>();
		newBody = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Body").gameObject.GetComponent<MaterialSwapper>();
		newHead = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Head").gameObject.GetComponent<MaterialSwapper>();
	}

	public void PressButton (){
		currentArms.GeneLogic (newArms.CurrentGene);
		currentBody.GeneLogic (newBody.CurrentGene);
		currentHead.GeneLogic (newHead.CurrentGene);
		objectiveManager.CheckNewCreature(currentHead.CurrentGene, currentBody.CurrentGene, currentArms.CurrentGene);
		randomizer.PressButton();
	}
}
