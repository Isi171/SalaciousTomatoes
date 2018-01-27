using System;

public class Achievement {

	public enum Type {Avoid, Obtain};
	public enum Slot {Head, Body, Limbs};
	static Random rand = new Random ();

	Type achiType;
	Slot achiSlot;
	Gene.RPS achiRPS;

	public Type AchiType {
		get{ return achiType;}
	}
	public Slot AchiSlot {
		get{ return achiSlot; }
	}
	public Gene.RPS AchiRPS {
		get{ return achiRPS; }
	}

	/*public Achievement Generate (Achievement[] achiArray){
		foreach (Achievement a in achiArray) {
			
		}
	}*/
}
