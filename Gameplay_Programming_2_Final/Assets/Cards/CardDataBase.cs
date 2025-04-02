using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static CardDataBase Instance;
    List<Card> CardList;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        CardList = new List<Card>();
    }

    public Card RetrieveCard(int cardId)
    {
        Card card = CardList[cardId];
        return card;
    }

    public List<Card> GenerateCards()
    {
        CardList.Add(new PunchScript());
        CardList.Add(new Multi_Jump_Script());
        CardList.Add(new Warp_Script());
        return CardList;
    }

    public CardObjectScript CreateCardObject(string CardName, Card card)
    {
        CardObjectScript cardObjectScript = new CardObjectScript();
        cardObjectScript.card = card;
        return cardObjectScript;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
