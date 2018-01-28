using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour {
	public ObjectiveManager objectiveManager;
	public Randomize randomizer;
	[SerializeField] MaterialSwapper currentLimbs;
    [SerializeField] MaterialSwapper currentBody;
    [SerializeField] MaterialSwapper currentHead;
    [SerializeField] MaterialSwapper newLimbs;
    [SerializeField] MaterialSwapper newBody;
    [SerializeField] MaterialSwapper newHead;

    public Gene GetGene(Objective.Slot s){

        if (s.Equals(Objective.Slot.Head))
            return currentHead.CurrentGene;
        else if(s.Equals(Objective.Slot.Limbs))
            return currentLimbs.CurrentGene;
        else
            return currentBody.CurrentGene;
    }

	public void PressButton (){
		currentLimbs.GeneLogic (newLimbs.CurrentGene);
		currentBody.GeneLogic (newBody.CurrentGene);
		currentHead.GeneLogic (newHead.CurrentGene);
		objectiveManager.CheckNewCreature(currentHead.CurrentGene, currentBody.CurrentGene, currentLimbs.CurrentGene);
		randomizer.PressButton();
	}
}
