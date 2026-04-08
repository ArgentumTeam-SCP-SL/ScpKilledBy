namespace ScpKilledBy
{
    public class Config
    {
        public string SelfDestructed { get; set; } = 
            "<size=50><color=red>💀 <b>%Scp%</color></size> <size=40>it was self-destructed</b></size>";

        public ushort SelfDestructedTime { get; set; } = 5;
        
        public string DestructedByPlayer { get; set; } = 
            "<size=50><color=red>💀 <b>%Scp%</color></size> <size=40>was eliminated by a player <color=orange>%Attacker%</color></b></size>";
        public ushort DestructedByPlayerTime { get; set; } = 5;
    }
}