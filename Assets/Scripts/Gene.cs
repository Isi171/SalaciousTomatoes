using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gene : MonoBehaviour {
	public enum RPS {Rock, Paper, Scissors, Zero};
	public enum Strength {Small, Medium, Big};
	RPS rpsValue;
	Strength strValue;

	public RPS RpsValue {
		get{return rpsValue; }
		set{ rpsValue = value; }
	}

	public Strength StrValue {
		get{return strValue;}
		set{ strValue = value; }
	}
}
