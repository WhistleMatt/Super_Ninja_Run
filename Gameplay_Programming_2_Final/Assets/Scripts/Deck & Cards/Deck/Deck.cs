using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] public List<Card> CardList = new List<Card>();
    private Card CurrentCard;
    [SerializeField] private int maxDeckSize;
    private int deckSize;
    private int cardIndex;
    // Start is called before the first frame update
    void Start()
    {
        CardList = CardDataBase.Instance.GenerateCards();
        CurrentCard = CardList[0];
        cardIndex = 0;
        deckSize = CardList.Count;
    }

    public Card GetCurrentCard()
    {
        return CurrentCard;
    }

    public void PlayCurrentCard()
    {
        CurrentCard.Execute();
    }

    public void SwitchSelectedCard(int _cycleDirection)
    {
        cardIndex += _cycleDirection;
        if(cardIndex < 0) 
        {
            cardIndex = deckSize - 1;
        }
        else if (cardIndex >= deckSize)
        {
            cardIndex = 0;
        }
        CurrentCard = CardList[cardIndex];
    }

    public void InsertCard(int _index, Card _newCard)
    {
        if(deckSize + 1 > maxDeckSize)
        {
            return;
        }
        CardList.Insert(_index, _newCard);
        deckSize++;
    }

    public Card RemoveCard(int _index)
    {
        if(deckSize - 1 <= 0)
        {
            return null;
        }
        var card = CardList[_index];
        CardList.RemoveAt(_index);
        deckSize--;
        return card;
    }
}
