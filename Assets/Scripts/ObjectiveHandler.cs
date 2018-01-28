using UnityEngine;
using UnityEngine.UI;

public class ObjectiveHandler : MonoBehaviour {
    public Text timerText;
    [SerializeField] private Image icon;
    [SerializeField] private ScoreTextHandler scoreTextHandler;
    
    [Header("Objectives Sprites Positive")]
    [SerializeField] private Sprite headPurpleScissors;
    [SerializeField] private Sprite headGreenPaper;
    [SerializeField] private Sprite headYellowRock;
    [SerializeField] private Sprite bodyPurpleScissors;
    [SerializeField] private Sprite bodyGreenPaper;
    [SerializeField] private Sprite bodyYellowRock;
    [SerializeField] private Sprite limbsPurpleScissors;
    [SerializeField] private Sprite limbsGreenPaper;
    [SerializeField] private Sprite limbsYellowRock;
    
    [Header("Objectives Sprites Negative")]
    [SerializeField] private Sprite headPurpleScissorsNegative;
    [SerializeField] private Sprite headGreenPaperNegative;
    [SerializeField] private Sprite headYellowRockNegative;
    [SerializeField] private Sprite bodyPurpleScissorsNegative;
    [SerializeField] private Sprite bodyGreenPaperNegative;
    [SerializeField] private Sprite bodyYellowRockNegative;
    [SerializeField] private Sprite limbsPurpleScissorsNegative;
    [SerializeField] private Sprite limbsGreenPaperNegative;
    [SerializeField] private Sprite limbsYellowRockNegative;
    
    public Objective objective { get; set; }
    
    public void SetTimer(string counter)
    {
        timerText.text = counter;
    }

    public void TriggerScore(int amount)
    {
        scoreTextHandler.TriggerScore(amount);
    }
    
    public void SetObjective(Gene.RPS rps, Objective.Slot slot, bool positive)
    {
        if (positive)
        {
            SetObjectivePositive(rps, slot);
        }
        else
        {
            SetObjectiveNegative(rps, slot);
        }
    }
    
    private void SetObjectivePositive(Gene.RPS rps, Objective.Slot slot)
    {
        switch (rps)
        {
            case Gene.RPS.Rock:
                switch (slot)
                {
                    case Objective.Slot.Head:
                        icon.sprite = headYellowRock;
                        break;
                    case Objective.Slot.Body:
                        icon.sprite = bodyYellowRock;
                        break;
                    case Objective.Slot.Limbs:
                        icon.sprite = limbsYellowRock;
                        break;
                }
                break;
            case Gene.RPS.Paper:
                switch (slot)
                {
                    case Objective.Slot.Head:
                        icon.sprite = headGreenPaper;
                        break;
                    case Objective.Slot.Body:
                        icon.sprite = bodyGreenPaper;
                        break;
                    case Objective.Slot.Limbs:
                        icon.sprite = limbsGreenPaper;
                        break;
                }
                break;
            case Gene.RPS.Scissors:
                switch (slot)
                {
                    case Objective.Slot.Head:
                        icon.sprite = headPurpleScissors;
                        break;
                    case Objective.Slot.Body:
                        icon.sprite = bodyPurpleScissors;
                        break;
                    case Objective.Slot.Limbs:
                        icon.sprite = limbsPurpleScissors;
                        break;
                }
                break;
        }
    }

    private void SetObjectiveNegative(Gene.RPS rps, Objective.Slot slot)
    {
        switch (rps)
        {
            case Gene.RPS.Rock:
                switch (slot)
                {
                    case Objective.Slot.Head:
                        icon.sprite = headYellowRockNegative;
                        break;
                    case Objective.Slot.Body:
                        icon.sprite = bodyYellowRockNegative;
                        break;
                    case Objective.Slot.Limbs:
                        icon.sprite = limbsYellowRockNegative;
                        break;
                }
                break;
            case Gene.RPS.Paper:
                switch (slot)
                {
                    case Objective.Slot.Head:
                        icon.sprite = headGreenPaperNegative;
                        break;
                    case Objective.Slot.Body:
                        icon.sprite = bodyGreenPaperNegative;
                        break;
                    case Objective.Slot.Limbs:
                        icon.sprite = limbsGreenPaperNegative;
                        break;
                }
                break;
            case Gene.RPS.Scissors:
                switch (slot)
                {
                    case Objective.Slot.Head:
                        icon.sprite = headPurpleScissorsNegative;
                        break;
                    case Objective.Slot.Body:
                        icon.sprite = bodyPurpleScissorsNegative;
                        break;
                    case Objective.Slot.Limbs:
                        icon.sprite = limbsPurpleScissorsNegative;
                        break;
                }
                break;
        }
    }

    }
