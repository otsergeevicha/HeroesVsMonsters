using DG.Tweening;
using UnityEngine;

namespace Source.Scripts.Enemies
{
    public class EnemyMovement : Enemy
    {
        [SerializeField] private float _speed = 3f;

        private Tweener _movementTween;

        public override void OnActive()
        {
            base.OnActive();
            StartMovement();
        }

        public override void InActive()
        {
            StopMovement();
            base.InActive();
        }

        private void StartMovement()
        {
            if (!CurrentTarget)
            {
                Debug.LogWarning("EnemyMovement has no target assigned.", this);
                return;
            }

            StopMovement();

            var destination = new Vector3(CurrentTarget.position.x, CurrentTarget.position.y, transform.position.z);
            var origin2d = new Vector2(transform.position.x, transform.position.y);
            var destination2d = new Vector2(destination.x, destination.y);
            var distance = Vector2.Distance(origin2d, destination2d);

            if (distance <= Mathf.Epsilon)
                return;

            var duration = distance / Mathf.Max(_speed, 0.01f);

            _movementTween = transform
                .DOMove(destination, duration)
                .SetEase(Ease.Linear)
                .OnComplete(() => _movementTween = null);
        }

        private void StopMovement()
        {
            if (_movementTween?.IsActive() ?? false) 
                _movementTween.Kill();

            _movementTween = null;
        }
    }
}