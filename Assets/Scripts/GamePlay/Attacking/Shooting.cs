using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Aim))]
public class Shooting : Attacking
{
    public AttackTowerProfileHandler profileHandler;
    public Transform barrel;
    public GameObject bulletPrefab;

    protected bool reloading;
    protected Aim aim;

    protected Queue<BulletComponents> bulletPool = new Queue<BulletComponents>();
    protected int poolSize = 10;



    protected void Awake()
    {
        aim = GetComponent<Aim>();

        FillStats();
        FillPool();
    }
    protected void FillPool()
    {
        for(int i = 0; i < poolSize; i++)
        {
            BulletComponents bullet;

            bullet.obj = Instantiate(bulletPrefab);
            bullet.behaviour = bullet.obj.GetComponent<Bullet>();
            bullet.physic = bullet.obj.GetComponent<Rigidbody2D>();

            bullet.obj.SetActive(false);

            bulletPool.Enqueue(bullet);
        }
    }
    protected void FillStats()
    {
        _damage = profileHandler.data.damage;
        _attackRate = profileHandler.data.fireRate;
    }

    protected virtual IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(1 / _attackRate);
        reloading = false;
    }
    protected override void Attack()
    {
        if (aim.Target == null)
        {
            return;
        }
        BulletComponents bullet = bulletPool.Dequeue();

        Vector2 direction = (aim.Target.position - barrel.position).normalized;
        bullet.obj.SetActive(true);

        bullet.obj.transform.position = barrel.position;
        bullet.physic.velocity = direction * bullet.behaviour.speed;
        bullet.behaviour.damage = _damage;

        bulletPool.Enqueue(bullet);
        onAttack.Invoke();
    }

    protected void Update()
    {
        if(!reloading && aim.HasTarget)
        {
            Attack();
            StartCoroutine(Reload());
        }
    }


    protected struct BulletComponents
    {
        public GameObject obj;
        public Bullet behaviour;
        public Rigidbody2D physic;
    }
}
