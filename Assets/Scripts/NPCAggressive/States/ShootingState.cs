namespace NPCAggressive.States
{
    public class ShootingState : State
    {
        public ShootingState(string stateName, AggressiveNPC unit)
        {
            base.stateName = stateName;
            this.unit = unit;
        }

        public override void EnterState()
        {
            unit.StartCoroutine(((AggressiveNPC) unit).Shooting());
        }
    }
}