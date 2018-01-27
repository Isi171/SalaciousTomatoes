using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPStoMaterial_HEAD : RPStoMaterial {
	public static Material head_Neutral;
	public static Material head_Rock;
	public static Material head_Paper;
	public static Material head_Scissors;

	public static Material Association (Gene gene){
		if (gene.RpsValue == Gene.RPS.Rock) {
			return head_Rock;
		} else if (gene.RpsValue == Gene.RPS.Paper) {
			return head_Paper;
		} else if (gene.RpsValue == Gene.RPS.Scissors) {
			return head_Scissors;
		} else {
			return head_Neutral;
		}
	}
}
