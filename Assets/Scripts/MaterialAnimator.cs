using System;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class MaterialAnimator : MonoBehaviour {

    [SerializeField] private MaterialAnimator linkedMaterialAnimator = null;
    [SerializeField] private MaterialSwapper otherSwapper = null;
    [SerializeField] private MaterialAnimator otherMaterialAnimator = null;

    private Animator animator;
    private MaterialSwapper mySwapper;

    public void SetMaterial(Gene gene, bool dominant = false) {
        if (animator == null)
            animator = GetComponent<Animator>();
        if (mySwapper == null)
            mySwapper = GetComponent<MaterialSwapper>();


        if (mySwapper != null && otherSwapper != null && otherSwapper.CurrentGene != null && gene != null) {
            gene = mySwapper.CurrentGene;
            Debug.Log("Io sono " + gameObject.name + " "  + gene.RpsValue + " l'altro è " + otherSwapper.CurrentGene.RpsValue);
            /*
            if (otherSwapper.CurrentGene.RpsValue == gene.RpsValue) {
                dominant = false;
                otherMaterialAnimator.SetDominant(false);
            } else if (otherSwapper.CurrentGene.RpsValue == Gene.RPS.Zero) {
                dominant = true;
                otherMaterialAnimator.SetDominant(false);
            */

            if(Gene.Equals(gene,otherSwapper.CurrentGene)==0)
            {
                // Debug.Log(gameObject.name + " Io sono " + false + " l'altro è " + false);
                dominant = false;
                otherMaterialAnimator.SetDominant(false);
            } 
            else if (Gene.Equals(gene, otherSwapper.CurrentGene) < 0) 
            {
                // Debug.Log(gameObject.name + "Io sono " + true + " l'altro è " + false);
                dominant = true;
                otherMaterialAnimator.SetDominant(false);
            }
            else
            {
                // Debug.Log(gameObject.name + "Io sono " + false + " l'altro è " + true);
                dominant = false;
                otherMaterialAnimator.SetDominant(true);
            }

        }

        animator.SetInteger("PartType", Array.IndexOf(Gene.RPS.GetValues(gene.RpsValue.GetType()), gene.RpsValue));
        animator.SetBool("Dominant", dominant);

        if (linkedMaterialAnimator != null)
            linkedMaterialAnimator.SetPassive(Array.IndexOf(Gene.RPS.GetValues(gene.RpsValue.GetType()), gene.RpsValue), dominant);
    }

    public void SetDominant(bool d) {
        animator.SetBool("Dominant", d);
        if (linkedMaterialAnimator != null)
            linkedMaterialAnimator.SetDominant( d);
    }

    public void SetPassive(int i, bool b) {
        if (animator == null)
            animator = GetComponent<Animator>();
        animator.SetInteger("PartType", i);
        animator.SetBool("Dominant", b);
    } 

}