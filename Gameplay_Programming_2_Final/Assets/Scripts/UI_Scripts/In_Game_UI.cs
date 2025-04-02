using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class In_Game_UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _mana;
    [SerializeField] TextMeshProUGUI _hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _mana.text = ((int)player.GetComponent<Ability_Script>().GetMana()).ToString();
            _hp.text = player.GetComponent<Player_Attributes>().GetHP().ToString();
        }
        else
        {
            _mana.text = "0";
        }
        
    }
}
