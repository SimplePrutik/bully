using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPCIdle.States
{
    public class IdleState : State
    {
        

        public IdleState(string stateName, IdleNPC unit)
        {
            base.stateName = stateName;
            this.unit = unit;
        }
        
        public override void EnterState()
        {
            unit.StartCoroutine(((IdleNPC)unit).Patrol());
        }

        public override void ExitState()
        {
            unit.StopAllCoroutines();
        }
    }
}