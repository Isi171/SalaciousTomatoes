using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPStoMaterial : MonoBehaviour {
	public static Material Neutral;
	public static Material Rock;
	public static Material Paper;
	public static Material Scissors;

	public static Material Association (Gene gene){
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
