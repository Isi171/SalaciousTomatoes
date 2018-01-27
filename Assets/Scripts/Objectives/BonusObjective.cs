using System;
using System.Collections.Generic;
using System.Collections;

public class BonusObjective : Objective {

    public Gene.Strength strength;

    public BonusObjective(int b, Random random, List<BonusObjective> bonusObjectives) {

        //Gets a list with all possible slots
        List<Slot> slotList = GetSlotList();

        foreach (BonusObjective activeBonusObj in bonusObjectives)
            slotList.Remove(activeBonusObj.slot);

        int slotIndex = random.Next(slotList.Count);

        slot = slotList[slotIndex];

        // Assign a slot to the objective.
        var slotArray = Enum.GetValues(typeof(Slot));
                      
        // Assign a strength to the objective.
        var strengthArray = Enum.GetValues(typeof(Gene.Strength));
        strength = (Gene.Strength)strengthArray.GetValue(random.Next(strengthArray.Length));
        // Assign a strength to the objective.
        var geneArray = Enum.GetValues(typeof(Gene.RPS));

        gene = (Gene.RPS)geneArray.GetValue(random.Next(geneArray.Length - 1));
        // Set the other fields.
        bonus = b;
    }

    private List<Slot> GetSlotList()
    {
        var slotArray = Enum.GetValues(typeof(Slot));
        List<Slot> slotList = new List<Slot>();

        foreach (Slot s in slotArray){
            slotList.Add(s);
        }
        return slotList;
    }
}