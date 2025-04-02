using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ability_Script : MonoBehaviour
{
    [SerializeField] private int MaxMana;
    private float mana;
    [SerializeField] private float manaRegen;
    private float timer;
    // Start is called before the first frame update
    public void Start()
    {
        mana = MaxMana;
        timer = 0;
    }

    private void Update()
    {
        if (mana < MaxMana) 
        {
            RegenerateMana();
        }
    }

    public void Cast()
    {
        if(UI_Manager.Instance.GameStarted)
        {
            Card selectedCard = this.GetComponent<Deck>().GetCurrentCard();
            if (selectedCard.Cost <= mana)
            {
                selectedCard.Execute();
                mana -= selectedCard.Cost;
            }
        }
    }

    private void RegenerateMana()
    {
        timer += Time.deltaTime;
        int seconds = (int)(timer % 60);
        if(seconds == 1)
        {
            timer = 0;
            mana += manaRegen;
        }
    }

    public float GetMana()
    {
        return mana;
    }

    public void RecoverMana(int value)
    {
        mana += value;
        MaxMana += value;
        manaRegen += 0.5f;
    }
}
