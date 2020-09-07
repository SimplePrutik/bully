
using System.Collections;
using NPCAggressive.States;
using UnityEngine;

public class AggressiveNPC : IdleNPC
{
    private float attackRange = 0.25f;
    private float bulletSpeed = 200;
    private float attackSpeed = 1f;
    public Bullet bullet;
    
    public Unit target;
    private void Awake()
    {
        fsm = new StateMachine();
        fsm.AddState(new IdleState("idle", this));
        fsm.AddState(new ChaseState("chase", this));
        fsm.AddState(new ShootingState("shooting", this));
        fsm.SetState("idle");
    }

    public IEnumerator ChaseTarget()
    {
        while (Vector3.Distance(target.transform.localPosition, transform.localPosition) > attackRange)
        {
            var current_pos = transform.localPosition;
            var motion_vec = target.transform.localPosition - current_pos;
            var step = motion_vec.normalized * (Time.deltaTime * moveSpeed);
            transform.localPosition += step;
            yield return null;
        }
        fsm.SetState("shooting");
    }

    public IEnumerator Shooting()
    {
        while (Vector3.Distance(target.transform.localPosition, transform.localPosition) <= attackRange
               && target.gameObject.activeInHierarchy)
        {
            Shoot();
            yield return new WaitForSeconds(attackSpeed);
        }
        if (!target.gameObject.activeInHierarchy)
            fsm.SetState("idle");
        else
            fsm.SetState("chase");
        
    }

    private void Shoot()
    {
        transform.LookAt(target.transform);
        var b = Instantiate(bullet);
        b.transform.position = transform.position;
        b.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward * bulletSpeed));
    }
    
    public new void OnTriggerEnter(Collider other)
    {
        
    }
}