using System;
using UnityEngine;

namespace Mob
{
    public class MobAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        

        public void PlayMovement()
        {
            _animator.SetFloat("speed",1);
        }

        public void PlayAttack()
        {
            _animator.SetFloat("speed",0);
            _animator.SetTrigger("attack");
        }
        
        
    }
}