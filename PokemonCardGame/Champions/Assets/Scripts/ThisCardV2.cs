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
    public Text cardDescText;

    public Sprite thisSprite;
    public Image thatImage;

    public Image frame;

    public bool cardBack;
    public static bool staticCardBack;

    // Start is called before the first frame update
    void Start()
    {
        thisCard[0] = CardDataBase.cardList[thisId];
    }

    // Update is called once per frame
    void Update()
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
        cardDescText.text = "" + cardDesc;
        thatImage.sprite = thisSprite;

        if (thisCard[0].color == "Yellow")
        {
            frame.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
        }

        staticCardBack = cardBack;
    }
}
