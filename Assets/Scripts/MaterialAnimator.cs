using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class MaterialAnimator : MonoBehaviour {

    [SerializeField] private float animationSpeed;
    [SerializeField] private Material[] paperMaterials;
    [SerializeField] private Material[] rockMaterials;
    [SerializeField] private Material[] scissorMaterials;
    [SerializeField] private Material[] neutralMaterials;

    private Gene.RPS currentAnimation;

    private SkinnedMeshRenderer smr;
    private int frame = 0;
    private float lastAnimationChange = 0;

    void Start() {
        smr = this.GetComponent<SkinnedMeshRenderer>();
    }

    void Update() {
        if (Time.time - lastAnimationChange > animationSpeed) {
            switch (currentAnimation) {
                case Gene.RPS.Paper:
                    AnimateMaterial(paperMaterials);
                    break;
                case Gene.RPS.Rock:
                    AnimateMaterial(rockMaterials);
                    break;
                case Gene.RPS.Scissors:
                    AnimateMaterial(scissorMaterials);
                    break;
                case Gene.RPS.Zero:
                    AnimateMaterial(neutralMaterials);
                    break;
            }
        }
    }

    private void AnimateMaterial(Material[] materials) {
        smr.material = materials[frame];
        lastAnimationChange = Time.time;
        frame++;
        if (frame == materials.Length) {
            frame = 0;
        }
    }

    public void SetMaterial(Gene.RPS gene) {
        currentAnimation = gene;
    }

}