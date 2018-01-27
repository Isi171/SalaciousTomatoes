using System;

public class MalusObjective : Objective {

    public int generations;
    public int malus;
    public int initialGeneration;
    public int counter;

    public MalusObjective(int minGen, int maxGen, int b, int m, int g, Random random) {
        // Assign a slot to the objective.
        var slotArray = Enum.GetValues(typeof(Slot));
        slot = (Slot)slotArray.GetValue(random.Next(slotArray.Length));
        // Assign a strength to the objective.
        var geneArray = Enum.GetValues(typeof(Gene.RPS));
        gene = (Gene.RPS)geneArray.GetValue(random.Next(geneArray.Length - 1));
        // Assign a strength to the objective.
        generations = random.Next(minGen, maxGen);
        counter = generations;
        // Set the other fields.
        bonus = b * generations;
        malus = m;
        initialGeneration = g;
    }

}
