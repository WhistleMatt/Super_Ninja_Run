using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Card : Card
{
    public int Cost { get; set; }
    public int AttackPower { get; set; }
    public int ID { get; set; }
    public string Name { get; set; }

    public virtual void Execute()
    {
        return;
    }
}
