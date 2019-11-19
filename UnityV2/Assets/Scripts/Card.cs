using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card
{
    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDesc;

    public int drawXcards;
    public int addXmaxMana;

    public Sprite thisImage;

    public string color;

    public Card()
    {

    }
    
    public Card(int Id, string CardName, int Cost, int Power, string CardDesc, Sprite ThisImage, string Color, int DrawXcards, int AddXmaxMana)
    {
        id = Id;
        cardName = CardName;
        cost = Cost;
        power = Power;
        cardDesc = CardDesc;

        thisImage = ThisImage;

        color = Color;

        drawXcards = DrawXcards;
        addXmaxMana = AddXmaxMana;
    }
}
