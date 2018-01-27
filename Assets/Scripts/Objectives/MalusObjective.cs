﻿using System;

public class MalusObjective : Objective {

    private int generations;
    private int malus;

    public MalusObjective(int minGen, int maxGen, int b, int m) {
        System.Random random = new System.Random();

        // Assign a slot to the objective.
        var slotArray = Enum.GetValues(typeof(Slot));
        slot = (Slot)slotArray.GetValue(random.Next(slotArray.Length));
        // Assign a strength to the objective.
        generations = random.Next(minGen, maxGen);
        // Set the other fields.
        bonus = b * generations;
        malus = m;
    }

}
