using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Mob.Animation
{
    using UnityEngine;

    public class AnimationController : MonoBehaviour
    {
        public Animator animator;

        private Vector3 previousPosition;
        private float currentSpeed;

        public float Speed
        {
            set => animator.SetFloat("speed", value);
        }

        private void Start()
        {
            previousPosition = transform.position;
        }

        private void Update()
        {
            CalculateSpeed();
            Speed = currentSpeed;
        }

        private void CalculateSpeed()
        {
            Vector3 movement = transform.position - previousPosition;
            currentSpeed = movement.magnitude / Time.deltaTime;
            previousPosition = transform.position;
        }

        public void PlayAttackAnimation()
        {
            animator.SetTrigger("attack");
        }
    }

}