namespace NPCAggressive.States
{
    public class ChaseState : State
    {
        public ChaseState(string stateName, AggressiveNPC unit)
        {
            base.stateName = stateName;
            this.unit = unit;
        }

        public override void EnterState()
        {
            unit.StopAllCoroutines();
            unit.StartCoroutine(((AggressiveNPC) unit).ChaseTarget());
        }
    }
}