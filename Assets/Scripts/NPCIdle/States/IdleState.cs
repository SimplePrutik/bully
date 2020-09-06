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
            ((IdleNPC)unit).Do("Patrol");
        }

        public override void ExitState()
        {
            //stop patroling or smtg
        }

    }
}