using System;

public class BonusObjective : Objective {

    private Gene.Strength strength;

    public BonusObjective(int b) {
        // Assign a slot to the objective.
        var slotArray = Enum.GetValues(typeof(Slot));
        slot = (Slot)slotArray.GetValue(new System.Random().Next(slotArray.Length));
        // Assign a strength to the objective.
        var strengthArray = Enum.GetValues(typeof(Gene.Strength));
        strength = (Gene.Strength)strengthArray.GetValue(new System.Random().Next(strengthArray.Length));
        // Set the other fields.
        bonus = b;
    }

}