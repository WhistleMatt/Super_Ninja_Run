using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardTextScript : MonoBehaviour
{
    Card CurrentCard { get; set; }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            CurrentCard = GameObject.FindGameObjectWithTag("Player").GetComponent<Deck>().GetCurrentCard();
            if(CurrentCard != null)
            {
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = CurrentCard.Name;
                transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = CurrentCard.Cost.ToString();
            }
        }
        
    }
}
