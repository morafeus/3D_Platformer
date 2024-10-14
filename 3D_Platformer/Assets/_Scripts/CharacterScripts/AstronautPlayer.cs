using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AstronautPlayer
{
    public class AstronautPlayer : MonoBehaviour, IPunchable
    {

        public float groundCheckDistance;

        [SerializeField]
        protected float movementSpeed = 6;
        [SerializeField]
        protected float rotationSpeed = 100;
        [SerializeField]
        protected GameObject root;
        protected Vector3 movementVector;
        protected bool isGrounded = false;
        protected bool jumpRequested;
        protected bool isRagdollActive = false;

        protected new Rigidbody rigidbody;
        protected List<Rigidbody> rigidbodies;
        protected Animator animator;
        protected Collider colider;

        private List<Transform> ragdollParts = new List<Transform>();
        private Vector3 originalPosition;

        public void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            colider = GetComponent<CapsuleCollider>();
            rigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());

            foreach (Transform child in transform)
            {
                ragdollParts.Add(child);
            }
        }

        protected void Update()
        {
            movementVector = Input.GetAxis("Vertical") * transform.forward;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpRequested = true;
            }
            if (transform.position.y < -20)
            {
                PlayerManager.Damage(100);
                rigidbody.isKinematic = true;   
            }
            StartCoroutine(Utils.CoroutuneRun(animator));         
        }

        protected bool CheckIfGrounded()
        {
            RaycastHit hit;
            Vector3 origin = transform.position + Vector3.down * (GetComponent<CapsuleCollider>().height / 2 - 1.5f);
            if (Physics.Raycast(origin, Vector3.down, out hit, groundCheckDistance))
            {
                return true;
            }
            jumpRequested = false;
            return false;
        }


        public void OnHit(Vector3 hitDirection, float hitForce)
        {
            rigidbody.AddForce(hitDirection.normalized * hitForce, ForceMode.Impulse);
        }
    }
}