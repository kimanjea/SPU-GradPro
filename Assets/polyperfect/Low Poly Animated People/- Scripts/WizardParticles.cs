using UnityEngine;

[ExecuteInEditMode]
public class WizardParticles : MonoBehaviour
{
    Animator animator;

    public Transform leftHand, rightHand;

    public Vector3 direction, midPoint;
    public Quaternion rotation;
    public float scale;

    

    public Vector3 sizeMultiplier = Vector3.one;

    public new ParticleSystem particleSystem;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
        leftHand = animator.GetBoneTransform(HumanBodyBones.LeftHand);
        rightHand = animator.GetBoneTransform(HumanBodyBones.RightHand);
    }

    void Update()
    {
        direction = leftHand.position - rightHand.position;

        midPoint = (rightHand.position + leftHand.position) / 2;
        scale = direction.magnitude / 2;

        midPoint = midPoint - transform.position;

        rotation = Quaternion.LookRotation(direction, Vector3.up);

        var shape = particleSystem.shape;
        shape.position = midPoint;
        shape.rotation = rotation.eulerAngles;
        shape.scale = new Vector3(scale * sizeMultiplier.x, scale * sizeMultiplier.y, scale * sizeMultiplier.z);
    }

    void OnDrawGizmos()
    {
        
    }
}
