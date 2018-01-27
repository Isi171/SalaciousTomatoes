using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour {
	public ObjectiveManager objectiveManager;
	public Randomize randomizer;
	MaterialSwapper currentLimbs;
	MaterialSwapper currentBody;
	MaterialSwapper currentHead;
	MaterialSwapper newLimbs;
	MaterialSwapper newBody;
	MaterialSwapper newHead;

	void Start (){
		currentLimbs = GameObject.FindGameObjectWithTag ("CurrentMonster").transform.Find ("Limbs").gameObject.GetComponent<MaterialSwapper>();
		currentBody = GameObject.FindGameObjectWithTag ("CurrentMonster").transform.Find ("Body").gameObject.GetComponent<MaterialSwapper>();
		currentHead = GameObject.FindGameObjectWithTag ("CurrentMonster").transform.Find ("Head").gameObject.GetComponent<MaterialSwapper>();
		newLimbs = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Limbs").gameObject.GetComponent<MaterialSwapper>();
		newBody = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Body").gameObject.GetComponent<MaterialSwapper>();
		newHead = GameObject.FindGameObjectWithTag ("NewMonster").transform.Find ("Head").gameObject.GetComponent<MaterialSwapper>();
	}

	public void PressButton (){
		currentLimbs.GeneLogic (newLimbs.CurrentGene);
		currentBody.GeneLogic (newBody.CurrentGene);
		currentHead.GeneLogic (newHead.CurrentGene);
		objectiveManager.CheckNewCreature(currentHead.CurrentGene, currentBody.CurrentGene, currentLimbs.CurrentGene);
		randomizer.PressButton();
	}
}
