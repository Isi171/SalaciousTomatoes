using System;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class MaterialAnimator : MonoBehaviour {

    [SerializeField] private MaterialAnimator linkedMaterialAnimator = null;

    Animator animator;

    public void SetMaterial(Gene gene) {
        if (animator == null)
            animator = GetComponent<Animator>();

        animator.SetInteger("PartType", Array.IndexOf(Gene.RPS.GetValues(gene.RpsValue.GetType()), gene.RpsValue));

        if (linkedMaterialAnimator != null)
            linkedMaterialAnimator.SetMaterial(gene);
    }

}