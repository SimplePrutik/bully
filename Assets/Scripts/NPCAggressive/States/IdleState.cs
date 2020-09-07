namespace NPCAggressive.States
{
    public class IdleState : NPCIdle.States.IdleState
    {

        public IdleState(string stateName, IdleNPC unit) : base(stateName, unit)
        {
        }

        public override void ButtonHandler(string buttonName)
        {
            switch (buttonName)
            {
                case "Chase":
                    ((AggressiveNPC)unit).fsm.SetState("chase");
                    break;
            }
        }
    }
}