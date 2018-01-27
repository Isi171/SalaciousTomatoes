using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPStoMaterial : MonoBehaviour {
	public Material Neutral;
	public Material Rock;
	public Material Paper;
	public Material Scissors;

	public Material Associate (Gene gene){
		if (gene.RpsValue == Gene.RPS.Rock) {
			return Rock;
		} else if (gene.RpsValue == Gene.RPS.Paper) {
			return Paper;
		} else if (gene.RpsValue == Gene.RPS.Scissors) {
			return Scissors;
		} else {
			return Neutral;
		}
	}
}
