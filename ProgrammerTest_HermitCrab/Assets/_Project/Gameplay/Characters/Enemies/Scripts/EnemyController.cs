using DG.Tweening;
using System.Collections;
using UnityEngine;

public class EnemyController : BaseCharacterController<EnemyMovement, EnemyAnimations, EnemyHealth, EnemyActions>
{
    [SerializeField] private float _patrolRestTime = 3;
    [SerializeField] private float _sightDistance = 3;
    [SerializeField] private float _attackDistance = 2;
    [SerializeField] private float _attackInterval = 2;
    [SerializeField] private float _secondsToForgetTarget = 3;

    enum EnemyState
    {
        Patrol, Chase, Attack, Dead
    }

    private EnemyState _state;
    private Transform[] _waypoints;
    private WaitForSeconds _patrolRestTimeWait;
    private WaitForSeconds _attackIntervalWait;
    private Coroutine _patrolCoroutine;
    private Coroutine _attackCoroutine;
    private RaycastHit2D[] _sightTargets;
    private BaseCharacterHealth _chaseTarget;
    private float _secondsAfterTargetDisapeared;

    protected override void Init()
    {
        base.Init();

        _patrolRestTimeWait = new WaitForSeconds(_patrolRestTime);
        _attackIntervalWait = new WaitForSeconds(_attackInterval);
        _sightTargets = new RaycastHit2D[1];
    }

    public override void OnDie()
    {
        _state = EnemyState.Dead;

        StopAttack();
        StopPatrol();

        base.OnDie();
    }

    private void FixedUpdate()
    {
        if (_state == EnemyState.Dead) return;

        EnemyBehaviour();
    }

    public void SetWaypoints(Transform[] waypoints)
    {
        _waypoints = waypoints;
    }

    private void EnemyBehaviour()
    {
        if (IsSeeingTarget())
        {
            _secondsAfterTargetDisapeared = 0;

            if (_state == EnemyState.Patrol)
            {
                StartChase();
            }
        }
        else
        {
            if (_state == EnemyState.Patrol) return;

            _secondsAfterTargetDisapeared += Time.deltaTime;
            if (_secondsAfterTargetDisapeared > _secondsToForgetTarget)
            {
                StartPatrol();
            }
        }

        if (_state != EnemyState.Patrol)
        {
            ChaseAndAttackPlayer();
        }
    }

    private bool IsSeeingTarget()
    {
        return Physics2D.RaycastNonAlloc(transform.position, transform.right, _sightTargets, _sightDistance, Actions.TargetsLayers) > 0 &&
            _sightTargets[0].rigidbody.TryGetComponent(out _chaseTarget);
    }

    public void StartPatrol()
    {
        if (_waypoints.Length == 0) return;

        StopPatrol();

        _chaseTarget = null;
        _state = EnemyState.Patrol;
        _secondsAfterTargetDisapeared = 0;
        _patrolCoroutine = StartCoroutine(PatrolCoroutine());
    }

    /// <summary>
    /// As the patrol behaviour is not always activated, for example, when the enemy is chasing the player,
    /// I prefer to put it on a Coroutine instead of the Update method.
    /// </summary>
    /// <returns></returns>
    private IEnumerator PatrolCoroutine()
    {
        while (_state == EnemyState.Patrol)
        {
            foreach (Transform point in _waypoints)
            {
                float waypointPosX = point.position.x;
                Movement.RotateCharacter((int)(waypointPosX - transform.position.x));
                yield return Movement.GoToPositionX(waypointPosX).WaitForCompletion();
                yield return _patrolRestTimeWait;
            }
        }
    }

    public void StopPatrol()
    {
        Movement.Stop();
        if (_patrolCoroutine != null)
        {
            StopCoroutine(_patrolCoroutine);
            _patrolCoroutine = null;
        }
    }

    private void StartChase()
    {
        StopPatrol();
        _state = EnemyState.Chase;
    }

    private void ChaseAndAttackPlayer()
    {
        if (_chaseTarget == null) return;

        if (Vector2.Distance(transform.position, _chaseTarget.transform.position) > _attackDistance)
        {
            if (_state == EnemyState.Attack)
            {
                StopAttack();
                _state = EnemyState.Chase;
            }

            Movement.ChaseTarget(_chaseTarget.transform.position);
        }
        else
        {
            StartAttacking();
        }
    }

    private void StartAttacking()
    {
        if (_state == EnemyState.Attack) return;

        print("Start Attack");
        Animations.IsMoving = false;

        _state = EnemyState.Attack;
        _attackCoroutine = StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        while (_state == EnemyState.Attack && !_chaseTarget.IsDead)
        {
            print("Attack");
            Actions.MeleeAttack();
            yield return _attackIntervalWait;
        }
    }

    private void StopAttack()
    {
        print("StopAttack");
        if (_attackCoroutine != null)
        {
            StopCoroutine(_attackCoroutine);
            _attackCoroutine = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right * _sightDistance);
    }
}
