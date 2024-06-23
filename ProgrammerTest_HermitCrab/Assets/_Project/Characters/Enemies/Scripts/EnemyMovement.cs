using DG.Tweening;
using UnityEngine;

public class EnemyMovement : BaseCharacterMovement<EnemyAnimations>
{
    private Tweener _movementTweener;

    public void ChaseTarget(Vector2 targetPosition)
    {
        _animations.IsMoving = true;
        targetPosition.y = transform.position.y;
        _rigidbody.position = Vector2.MoveTowards(_rigidbody.position, targetPosition, _movementSpeed * Time.deltaTime);
        RotateCharacter((int)(targetPosition.x - transform.position.x));
    }

    public Tweener GoToPositionX(float positionX)
    {
        _movementTweener = transform.DOMoveX(positionX, _movementSpeed).SetEase(Ease.Linear).SetSpeedBased(true);
        _movementTweener.onComplete = Stop;
        _animations.IsMoving = true;
        return _movementTweener;
    }

    public override void Stop()
    {
        base.Stop();
        _movementTweener.Kill();
    }
}
