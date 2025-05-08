using UnityEngine;

#if UNITY_EDITOR
using UnityEditor.Animations;
#endif

[CreateAssetMenu(fileName = "New ZombieType", menuName = "Zombie")]
public class ZombieTypes : ScriptableObject
{
    public int health;               
    public float speed;             
    public int damage;               
    public float range = 0.5f;      
    public float eatCooldown = 1f;   

    public Sprite sprite;           
    public Sprite DeathSprite;       

    // Use RuntimeAnimatorController for runtime.
    public RuntimeAnimatorController animator;       

    public string walkAnimation = "Walk"; 
    public string attackAnimation = "Attack";
    public string deathAnimation = "Die";

    public void PlayWalkAnimation(Animator animator)
    {
        animator.SetBool(walkAnimation, true);  
    }

    public void StopWalkAnimation(Animator animator)
    {
        animator.SetBool(walkAnimation, false); 
    }

    public void PlayAttackAnimation(Animator animator)
    {
        animator.SetTrigger(attackAnimation);   
    }
}