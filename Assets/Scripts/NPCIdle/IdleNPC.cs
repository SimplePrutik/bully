
using System;
using System.Collections;
using System.Collections.Generic;
using NPCIdle.States;
using UnityEngine;
using Random = UnityEngine.Random;

public class IdleNPC : Unit
{
    [NonSerialized]
    public StateMachine fsm;

    public float moveSpeed = 10;

    private void Awake()
    {
        fsm = new StateMachine();
        fsm.AddState(new IdleState("idle", this));
        fsm.SetState("idle");
    }

    #region enable_disable
    
    private void OnEnable()
    {
        Button.OnButtonClicked += ButtonHandler;
    }

    private void OnDisable()
    {
        Button.OnButtonClicked -= ButtonHandler;
    }
    

    #endregion
    

    void ButtonHandler(string buttonName) => fsm.ButtonHandler(buttonName);

    public IEnumerator Patrol()
    {
        var nextPos = transform.localPosition;
        while (true)
        {
            if (Vector3.Distance(transform.localPosition, nextPos) < 0.05f)
            {
                nextPos = new Vector3(Random.value - 0.5f, nextPos.y, Random.value - 0.5f);
                yield return new WaitForSeconds(Random.Range(1f,2f));
            }
            var current_pos = transform.localPosition;
            var motion_vec = nextPos - current_pos;
            var step = motion_vec.normalized * (Time.deltaTime * moveSpeed);
            transform.localPosition += step;
            if (step.magnitude > motion_vec.magnitude)
                transform.localPosition = nextPos;
            yield return null;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != transform && other.GetComponent<Bullet>() != null)
            gameObject.SetActive(false);
    }
}