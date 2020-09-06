
using System;
using System.Collections;
using System.Collections.Generic;
using NPCIdle.States;
using UnityEngine;

public class IdleNPC : Unit
{
    private StateMachine fsm;

    public float moveSpeed = 10;

    private void Awake()
    {
        fsm = new StateMachine();
        fsm.AddState(new IdleState("idle", this));
        fsm.SetState("idle");
    }

    private void OnEnable()
    {
        Button.OnButtonClicked += ButtonHandler;
    }

    private void OnDisable()
    {
        Button.OnButtonClicked -= ButtonHandler;
    }

    void ButtonHandler(string buttonName) => fsm.ButtonHandler(buttonName);

    // void EventHandler(params object[] args) => fsm.EventHandler(args);

    public void Do(string command)
    {
        switch (command)
        {
            case "Patrol":
                StartCoroutine(Move(new Vector2(0.25f, 0.25f)));
                break;
        }
    }

    IEnumerator Move(Vector2 position)
    {
        var pos = new Vector3(position.x, transform.localPosition.y, position.y);
        while (Vector3.Distance(transform.localPosition, pos) > 0.05f)
        {
            var current_pos = transform.localPosition;
            var motion_vec = pos - current_pos;
            var step = motion_vec.normalized * (Time.deltaTime * moveSpeed);
            transform.localPosition += step;
            if (step.magnitude > motion_vec.magnitude)
                transform.localPosition = pos;
            yield return null;
        }

        Debug.Log("Move is over");
    }
}