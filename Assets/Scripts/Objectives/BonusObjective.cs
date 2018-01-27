﻿using System;

public class BonusObjective : Objective {

    public Gene.Strength strength;

    public BonusObjective(int b, Random random) {
        // Assign a slot to the objective.
        var slotArray = Enum.GetValues(typeof(Slot));
        slot = (Slot)slotArray.GetValue(random.Next(slotArray.Length));
        // Assign a strength to the objective.
        var strengthArray = Enum.GetValues(typeof(Gene.Strength));
        strength = (Gene.Strength)strengthArray.GetValue(random.Next(strengthArray.Length));
        // Assign a strength to the objective.
        var geneArray = Enum.GetValues(typeof(Gene.RPS));
        gene = (Gene.RPS)geneArray.GetValue(random.Next(geneArray.Length - 1));
        // Set the other fields.
        bonus = b;
    }

}