namespace ScpKilledBy
{
    public class Config
    {
        public string selfDestructed { get; set; } = 
            "<size=50><color=red>💀 <b>{Scp}</color></size> <size=40>был самоликвидирован</b></size>";

        public ushort selfDestructedTime { get; set; } = 5;
        
        public string DestructedByPlayer { get; set; } = 
            "<size=50><color=red>💀 <b>{Scp}</color></size> <size=40>был ликвидирован игроком <color=orange>{Attacker}</color></b></size>";
        public ushort DestructedByPlayerTime { get; set; } = 5;
    }
}