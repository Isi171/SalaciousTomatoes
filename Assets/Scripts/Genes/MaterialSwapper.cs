using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour {
	//SkinnedMeshRenderer smr;
	//public enum BodyPartType {Limbs, Body, Head};
	//public BodyPartType bpt;
	//RPStoMaterial associator;
	Gene currentGene;
	MaterialAnimator ma;
	
	// RACE CONDITION WITH RandomizeMeAtStart.cs, used on NewMonster
	//to have it start randomized
	//Do not change from Awake to Start
	void Awake ()
	{
		//smr = GetComponent<SkinnedMeshRenderer> ();
		ma = GetComponent<MaterialAnimator> ();
		/*if (bpt == BodyPartType.Limbs) {
			associator = GameObject.FindGameObjectWithTag ("LimbsAssociator").GetComponent<RPStoMaterial>();
		} else if (bpt == BodyPartType.Body) {
			associator = GameObject.FindGameObjectWithTag ("BodyAssociator").GetComponent<RPStoMaterial>();
		} else if (bpt == BodyPartType.Head) {
			associator = GameObject.FindGameObjectWithTag ("HeadAssociator").GetComponent<RPStoMaterial>();
		}*/
		currentGene = new Gene (Gene.RPS.Zero, Gene.Strength.Small);
		//smr.material=associator.Associate (currentGene); //associator... ASSOCIATE!
		ma.SetMaterial (currentGene);
	}

	public void GeneLogic (Gene newGene){
		if (Gene.Equals (currentGene, newGene) == 1) { //the new gene is stronger
			currentGene = newGene;
		}
		//smr.material = associator.Associate(currentGene);
		ma.SetMaterial (currentGene);
	}

	public void Randomize(){
		var geneArray = Enum.GetValues(typeof(Gene.RPS));
		Gene.RPS rps = (Gene.RPS)geneArray.GetValue(CustomRandom.Next(geneArray.Length));
		var strengthArray = Enum.GetValues(typeof(Gene.Strength));
		Gene.Strength strength = (Gene.Strength)strengthArray.GetValue(CustomRandom.Next(strengthArray.Length));
		currentGene = new Gene (rps, strength);
		//smr.material = associator.Associate (currentGene);
		ma.SetMaterial (currentGene);
	}

	public Gene CurrentGene {
		get{ return currentGene; }
	}
}
