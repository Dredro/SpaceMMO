using UnityEngine;
using UnityEngine.Serialization;

namespace MobSystem
{
    public class MobAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        

        public void PlayMovement()
        {
            animator.SetBool("movement",true);
        }

        public void StopMovement()
        {
            animator.SetBool("movement",false);
        }

        public void PlayAttack()
        {
            animator.SetTrigger("attack");
        }
        
        
    }
}