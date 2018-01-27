﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPStoMaterial_BODY : RPStoMaterial {
	public static Material body_Neutral;
	public static Material body_Rock;
	public static Material body_Paper;
	public static Material body_Scissors;

	public static Material Association (Gene gene){
		if (gene.RpsValue == Gene.RPS.Rock) {
			return body_Rock;
		} else if (gene.RpsValue == Gene.RPS.Paper) {
			return body_Paper;
		} else if (gene.RpsValue == Gene.RPS.Scissors) {
			return body_Scissors;
		} else {
			return body_Neutral;
		}
	}
}
