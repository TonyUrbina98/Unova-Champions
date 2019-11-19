using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCardV2 : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDesc;

    public Text nameText;
    public Text costText;
    public Text powerText;
    public Text descText;

    public Sprite thisSprite;
    public Image thatImage;

    public Image frame;

    public bool cardBack;
    public static bool staticCardBack;

    private void Start()
    {
        thisCard[0] = CardDataBase.cardList[thisId];

    }
    private void Update()
    {

        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost = thisCard[0].cost;
        power = thisCard[0].power;
        cardDesc = thisCard[0].cardDesc;

        thisSprite = thisCard[0].thisImage;

        nameText.text = "" + cardName;
        costText.text = "" + cost;
        powerText.text = "" + power;
        descText.text = "" + cardDesc;

        thatImage.sprite = thisSprite;

        if (thisCard[0].color == "Red")
        {
            frame.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
        if (thisCard[0].color == "Blue")
        {
            frame.GetComponent<Image>().color = new Color32(0, 0, 255, 255);
        }
        if (thisCard[0].color == "Green")
        {
            frame.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
        }
        if (thisCard[0].color == "Yellow")
        {
            frame.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
        }
        if (thisCard[0].color == "Orange")
        {
            frame.GetComponent<Image>().color = new Color32(255, 115, 0, 255);
        }
        if (thisCard[0].color == "Purple")
        {
            frame.GetComponent<Image>().color = new Color32(180, 0, 255, 255);
        }
        if (thisCard[0].color == "Black")
        {
            frame.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        }

        staticCardBack = cardBack;

    }
}
