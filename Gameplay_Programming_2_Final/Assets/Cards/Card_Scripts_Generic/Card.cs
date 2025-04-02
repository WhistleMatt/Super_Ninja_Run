using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Card
{
    public int Cost { get; set; }
    public int ID { get; set; }
    public string Name { get; set; }
    public void Execute();
}
