using DG.Tweening;
using Reflex.Attributes;
using Source.Scripts.GameBase;
using UnityEngine;

namespace Source.Scripts.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;

        [Inject] private GameModule _gameModule;
        private Tweener _movementTween;
        
        public void StartMovement()
        {
            if (!_gameModule.TargetForEnemy)
            {
                Debug.Log($"EnemyMovement has no target assigned. [{_gameModule.TargetForEnemy}]");
                return;
            }

            
            StopMovement();
            
            var destination = new Vector3(_gameModule.TargetForEnemy.position.x, _gameModule.TargetForEnemy.position.y, transform.position.z);
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

        public void StopMovement()
        {
            if (_movementTween?.IsActive() ?? false) 
                _movementTween.Kill();

            _movementTween = null;
        }
    }
}