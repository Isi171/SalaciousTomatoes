using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour {
	private static System.Random random = new System.Random ();
	SkinnedMeshRenderer smr;
	public enum BodyPartType {Arms, Body, Head};
	public BodyPartType bpt;
	RPStoMaterial associator;
	Gene currentGene;
	// Use this for initialization
	void Start () {
		smr = GetComponent<SkinnedMeshRenderer> ();
		if (bpt == BodyPartType.Arms) {
			associator = GameObject.FindGameObjectWithTag ("ArmsAssociator").GetComponent<RPStoMaterial>();
		} else if (bpt == BodyPartType.Body) {
			associator = GameObject.FindGameObjectWithTag ("BodyAssociator").GetComponent<RPStoMaterial>();
		} else if (bpt == BodyPartType.Head) {
			associator = GameObject.FindGameObjectWithTag ("HeadAssociator").GetComponent<RPStoMaterial>();
		}
		currentGene = new Gene (Gene.RPS.Zero, Gene.Strength.Small);
		smr.material=associator.Associate (currentGene); //associator... ASSOCIATE!
	}

	public void GeneLogic (Gene newGene){
		if (Gene.Equals (currentGene, newGene) == 1) { //the new gene is stronger
			currentGene = newGene;
		}
		smr.material=associator.Associate (currentGene);
	}

	public void Randomize(){
		var geneArray = Enum.GetValues(typeof(Gene.RPS));
		Gene.RPS rps = (Gene.RPS)geneArray.GetValue(random.Next(geneArray.Length));
		var strengthArray = Enum.GetValues(typeof(Gene.Strength));
		Gene.Strength strength = (Gene.Strength)strengthArray.GetValue(random.Next(strengthArray.Length));
		currentGene = new Gene (rps, strength);
		smr.material = associator.Associate (currentGene);
	}

	public Gene CurrentGene {
		get{ return currentGene; }
	}
}
