using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AstronautPlayer
{
    public class AstronautPlayerRigitbody : AstronautPlayer
    {
        [SerializeField]
        private float jumpForce;
        private float rotationAmount;

   
        private void FixedUpdate()
        {
            bool wasGrounded = isGrounded;
            isGrounded = CheckIfGrounded();

            if (isGrounded && !wasGrounded)
            {
                animator.SetBool("IsGrouned", true);

            }
            else if (!isGrounded && wasGrounded)
            {
                animator.SetBool("IsGrouned", false);
                animator.ResetTrigger("Jump");
            }

            MovingHandle();
            RotationHandle();
            JumpHandle();
        }

        private void MovingHandle()
        {
            Vector3 moveDirection = movementVector * movementSpeed * Time.deltaTime;
            rigidbody.MovePosition(rigidbody.position + moveDirection);
        }

        private void RotationHandle()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            if (Mathf.Abs(horizontalInput) > 0.01f) 
            {
                float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
                transform.Rotate(0, rotationAmount, 0);
            }
        }

        private void JumpHandle()
        {
      
            if (jumpRequested && isGrounded)
            {
                animator.SetTrigger("Jump");
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpRequested = false;
            }
           
        }

    }
}

