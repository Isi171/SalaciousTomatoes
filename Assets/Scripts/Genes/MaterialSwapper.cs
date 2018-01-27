using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour {
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
}
