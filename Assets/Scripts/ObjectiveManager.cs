using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour {

    [SerializeField] private int gameDuration;

    [Header("Objectives")] [SerializeField] private int activeObjectives;
    [SerializeField] ObjectiveHandler[] handlers;

    [Header("Bonus")] [SerializeField] private int bonusScore;

    [Header("Malus")] [SerializeField] [Range(0, 1)] private float malusProbability;
    [SerializeField] private int malusScore;
    [SerializeField] private int malusPenalty;
    [SerializeField] private int malusMinGenerations;
    [SerializeField] private int malusMaxGenerations;

    [Header("UI")] [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;

    private List<BonusObjective> bonusObjectives = new List<BonusObjective>();
    private List<MalusObjective> malusObjectives = new List<MalusObjective>();
    private List<BonusObjective> completedBonus = new List<BonusObjective>();
    private List<MalusObjective> completedMalus = new List<MalusObjective>();

    private int score = 0;
    private int generation = 0;
    private float initialTime;

    System.Random random = new System.Random();

    void Start() {
        GenerateObjectives();

        initialTime = TimeSinceStart();
        scoreText.text = score.ToString();
    }

    private void Update() {
        float residualTime = gameDuration - TimeSinceStart() - initialTime;
        int minutes = (int)Mathf.Floor(residualTime / 60);
        int seconds = Mathf.RoundToInt(residualTime % 60);
        if (seconds == 60) {
            minutes++;
            seconds = 0;
        }            
        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        if (gameDuration - TimeSinceStart() - initialTime < 0)
        {
            timeText.text = "00:00";
            EndGame();
        }
    }

    public void CheckNewCreature(Gene head, Gene body, Gene limbs) {
        generation++;
        //Debug.Log(head.RpsValue.ToString() + "  " + body.RpsValue.ToString() + " " + limbs.RpsValue.ToString());
        foreach (BonusObjective b in bonusObjectives) {
            switch (b.slot) {
                case Objective.Slot.Head:
                    if (head.RpsValue == b.gene/* && head.StrValue == b.strength*/)
                        CompleteBonus(b);
                    break;
                case Objective.Slot.Body:
                    if (body.RpsValue == b.gene/* && body.StrValue == b.strength*/)
                        CompleteBonus(b);
                    break;
                case Objective.Slot.Limbs:
                    if (limbs.RpsValue == b.gene/* && limbs.StrValue == b.strength*/)
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

        DecreaseTimers();
        GenerateObjectives(head, body, limbs);
    }

    private void CompleteBonus(BonusObjective o)
    {
        completedBonus.Add(o);
        UpdateScore(o.bonus);
        TriggerScorePopup(o);
        RemoveFromSlot(o);
    }

    private void CompleteMalus(MalusObjective o, bool success) {
        completedMalus.Add(o);
        UpdateScore(success ? o.bonus : o.malus);
        TriggerScorePopup(o, !success);
        RemoveFromSlot(o);
    }

    private void UpdateScore(int i) {
        score = score + i < 0 ? 0 : score + i;
        scoreText.text = score.ToString();
    }

    //First call only
    private void GenerateObjectives(){
        GenerateObjectives(null, null, null);
    }

    private void GenerateObjectives(Gene head, Gene body, Gene limbs) {
        //Any null arguments indicated that it is the first call.
        //No malus for first generation

        while (bonusObjectives.Count + malusObjectives.Count < activeObjectives) {
            if (head!=null && malusObjectives.Count == 0 && random.Next(0, 100) < malusProbability * 100) {
                //This is to avoid new objectives that would be automatically triggered
                //If there is a God, I hope it will forgive me for this mess
                MalusObjective m;
                do
                {
                    m = new MalusObjective(malusMinGenerations, malusMaxGenerations, malusScore, malusPenalty, generation, random);
                } while (isObjectiveInConflict(m,head,body,limbs));

                ObjectiveHandler o = FindVoidSlot(m);
                o.SetObjective(m.gene, m.slot, false);
                o.SetTimer((m.initialGeneration + m.generations - generation).ToString());
                malusObjectives.Add(m);

            }
            else {
                BonusObjective b;
                do
                {
                    b = new BonusObjective(bonusScore, random, bonusObjectives);
                } while (isObjectiveInConflict(b, head, body, limbs));

                ObjectiveHandler o = FindVoidSlot(b);
                o.SetObjective(b.gene, b.slot, true);
                o.SetTimer("");
                bonusObjectives.Add(b);
            }
        }
    }

    private bool isObjectiveInConflict(Objective o, Gene head, Gene body, Gene limbs)
    {
        if (head == null)
            return false;

        if (o.slot == Objective.Slot.Head && o.gene == head.RpsValue)
            return true;
        else if (o.slot == Objective.Slot.Body && o.gene == body.RpsValue)
            return true;
        else if (o.slot == Objective.Slot.Limbs && o.gene == limbs.RpsValue)
            return true;
        else
            return false;            
    }

    private ObjectiveHandler FindVoidSlot(Objective objective) {
        foreach (ObjectiveHandler o in handlers) {
            if (o.objective == null) {
                o.objective = objective;
                return o;
            }
        }
        return null;
    }

    private void RemoveFromSlot(Objective objective) {
        foreach (ObjectiveHandler o in handlers) {
            if (o.objective == objective) {
                o.objective = null;
                break;
            }
        }
    }

    private void DecreaseTimers() {
        foreach (ObjectiveHandler o in handlers) {
            if (o.objective is MalusObjective) {
                ((MalusObjective)o.objective).counter--;
                o.timerText.text = ((MalusObjective)o.objective).counter.ToString();
            }
        }
    }

    private void EndGame() {
        PlayerPrefs.SetInt("Score", score);
        SceneManager.LoadScene("Score");
    }

    private static float TimeSinceStart()
    {
        return Time.timeSinceLevelLoad;
    }

    private void TriggerScorePopup(Objective o, bool useMalus = false)
    {
        foreach (ObjectiveHandler handler in handlers)
        {
            if (handler.objective == o)
            {
                if (useMalus)
                {
                    handler.TriggerScore(((MalusObjective)o).malus);
                }
                else
                {
                    handler.TriggerScore(o.bonus);
                }
            }
        }
    }

}
