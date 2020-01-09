using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Aim), typeof(AttackTowerProfileHandler))]
public class BeamAttack : Attacking
{
    public LineRenderer beam;
    public Transform barrel;
    public UnityEvent onFinishAttacking = new UnityEvent();

    private Aim _aim;
    private AttackTowerProfileHandler _profile;
    private Health _targetHealth;
    private bool _attacking = false;
    private readonly Vector3[] _zeroline = { Vector3.zero, Vector3.zero };


    private void Start()
    {
        _aim = GetComponent<Aim>();
        _profile = GetComponent<AttackTowerProfileHandler>();

        _damage = _profile.data.damage;
        _attackRate = _profile.data.fireRate;
        _aim.onRefreshTarget.AddListener(RefreshEnemy);
    }
    private void Update()
    {
        if (_aim.Target != null)
        {
            Attack();
        }
        else if (_attacking)
        {
            beam.SetPositions(_zeroline);
            _attacking = false;
            onFinishAttacking.Invoke();
        }
    }
    private void RefreshEnemy()
    {
        _targetHealth = _aim.Target.GetComponent<Health>();
    }

    protected override void Attack()
    {
        _targetHealth.Modify(-_damage * Time.deltaTime * Time.timeScale);

        Vector3[] line = new Vector3[2];
        line[0] = barrel.localPosition;
        line[1] = _aim.Target.position - transform.position;
        beam.SetPositions(line);

        if(!_attacking)
        {
            _attacking = true;
            onAttack.Invoke();
        }
    }
}