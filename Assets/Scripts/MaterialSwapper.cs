using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour {
	SkinnedMeshRenderer smr;
	[SerializeField] Material mat_zero;
	[SerializeField] Material mat_a;
	[SerializeField] Material mat_b;
	[SerializeField] Material mat_c;
	Gene currentGene;
	// Use this for initialization
	void Start () {
		smr = GetComponent<SkinnedMeshRenderer> ();
	}
	
	public void GeneLogic (Gene newGene){
		if (Gene.Equals (currentGene, newGene) == 1) { //the new gene is stronger
			currentGene = newGene;
		}
	}
}
