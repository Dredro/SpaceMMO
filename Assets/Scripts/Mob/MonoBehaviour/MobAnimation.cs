using UnityEngine;

namespace Mob
{
    public class MobAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        

        public void PlayMovement()
        {
            _animator.SetBool("movement",true);
        }

        public void StopMovement()
        {
            _animator.SetBool("movement",false);
        }

        public void PlayAttack()
        {
            _animator.SetTrigger("attack");
        }
        
        
    }
}