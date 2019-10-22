using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, "None", Resources.Load<Sprite>(" ")));
        cardList.Add(new Card(1,"Thunder Bolt",2,12,"Deals Damage alongside Paralyze", Resources.Load<Sprite>("ThunderBoltImage")));
        cardList.Add(new Card(2,"Thunder Wave", 1, 12, "Deals Damage and opponent flinch", Resources.Load<Sprite>("ThunderWaveImage")));
        cardList.Add(new Card(3,"Thunder Shock", 1, 12, "Deals Damage alongside Paralyze", Resources.Load<Sprite>("ThunderShockImage")));
        cardList.Add(new Card(4,"Tackle", 1, 6, "Damage your oppnent", Resources.Load<Sprite>("TackleImage")));
        cardList.Add(new Card(5,"Protect", 1, 5, "Gain some shield", Resources.Load<Sprite>("ProtectImage")));
        cardList.Add(new Card(6,"Double Team", 1, 0, "Next Card Played is Played Twice", Resources.Load<Sprite>("DoubleTeamImage")));
        cardList.Add(new Card(7,"Quick Attack", 0, 3, "Deals a Quick damage to opponent and gains boost to next defense card", Resources.Load<Sprite>("QuickAttackImage")));
    }
}
