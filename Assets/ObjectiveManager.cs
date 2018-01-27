using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour {

    [Header("Objectives")] [SerializeField] private int activeObjectives;

    [Header("Bonus")] [SerializeField] private int bonusScore;

    [Header("Malus")] [SerializeField] [Range(0, 1)] private float malusProbability;
    [SerializeField] private int malusScore;
    [SerializeField] private int malusPenalty;
    [SerializeField] private int malusMinGenerations;
    [SerializeField] private int malusMaxGenerations;

    private List<BonusObjective> bonusObjectives = new List<BonusObjective>();
    private List<MalusObjective> malusObjectives = new List<MalusObjective>();
    private List<BonusObjective> completedBonus = new List<BonusObjective>();
    private List<MalusObjective> completedMalus = new List<MalusObjective>();

    private int score = 0;
    private int generation = 0;

    System.Random random = new System.Random();

    void Start() {
        GenerateObjectives();
    }

    public void CheckNewCreature(Gene head, Gene body, Gene limbs) {
        generation++;

        foreach (BonusObjective b in bonusObjectives) {
            switch (b.slot) {
                case Objective.Slot.Head:
                    if (head.RpsValue == b.gene && head.StrValue == b.strength)
                        CompleteBonus(b);
                    break;
                case Objective.Slot.Body:
                    if (body.RpsValue == b.gene && body.StrValue == b.strength)
                        CompleteBonus(b);
                    break;
                case Objective.Slot.Limbs:
                    if (limbs.RpsValue == b.gene && limbs.StrValue == b.strength)
                        CompleteBonus(b);
                    break;
            }
        }

        foreach (MalusObjective m in malusObjectives) {
            switch (m.slot) {
                case Objective.Slot.Head:
                    if (head.RpsValue == m.gene)
                        CompleteMalus(m, false);
                    else if (generation == m.initialGeneration + m.generations)
                        CompleteMalus(m, true);
                    break;
                case Objective.Slot.Body:
                    if (body.RpsValue == m.gene)
                        CompleteMalus(m, false);
                    else if (generation == m.initialGeneration + m.generations)
                        CompleteMalus(m, true);
                    break;
                case Objective.Slot.Limbs:
                    if (limbs.RpsValue == m.gene)
                        CompleteMalus(m, false);
                    else if (generation == m.initialGeneration + m.generations)
                        CompleteMalus(m, true);
                    break;
            }
        }

        bonusObjectives.RemoveAll(o => completedBonus.Contains(o));
        malusObjectives.RemoveAll(o => completedMalus.Contains(o));

        completedBonus.Clear();
        completedMalus.Clear();

        GenerateObjectives();
    }

    private void CompleteBonus(BonusObjective o) {
        completedBonus.Add(o);
        UpdateScore(o.bonus);
    }

    private void CompleteMalus(MalusObjective o, bool success) {
        completedMalus.Add(o);
        UpdateScore(success ? o.malus : o.bonus);
    }

    private void UpdateScore(int i) {
        score = score + i < 0 ? 0 : score + i;
    }

    private void GenerateObjectives() {
        while (bonusObjectives.Count + malusObjectives.Count < activeObjectives) {
            if (malusObjectives.Count == 0 && random.Next(0, 100) < malusProbability * 100)
                malusObjectives.Add(new MalusObjective(malusMinGenerations, malusMaxGenerations, malusScore, malusPenalty, generation));
            else
                bonusObjectives.Add(new BonusObjective(bonusScore));
        }
    }

}
