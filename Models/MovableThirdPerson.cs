using UnityEngine;

namespace AssemblyActorCore
{
    public class MovableThirdPerson : Movable
    {
        private Rigidbody _rigidbody;

        private new void Awake()
        {
            base.Awake();

            _rigidbody = gameObject.GetComponent<Rigidbody>();
        }

        public override void FreezAll() 
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            _rigidbody.useGravity = false;
            _rigidbody.isKinematic = true;
            _rigidbody.velocity = Vector3.zero;
        }

        public override void FreezRotation()
        {
            _rigidbody.constraints = RigidbodyConstraints.None;
            _rigidbody.freezeRotation = true;
            _rigidbody.useGravity = false;
            _rigidbody.isKinematic = false;
            _rigidbody.velocity = Vector3.zero;
        }

        public override void MoveToDirection(Vector3 direction, float speed)
        {
            direction.Normalize();

            if (direction == Vector3.zero && Gravity == 0)
            {
                _rigidbody.velocity = Vector3.zero;
            }
            else
            {
                _rigidbody.MovePosition(_rigidbody.position + direction * speed * GetSpeedScale);
                _rigidbody.AddForce(Physics.gravity * Gravity, ForceMode.Acceleration);
            }
        }
    }
}