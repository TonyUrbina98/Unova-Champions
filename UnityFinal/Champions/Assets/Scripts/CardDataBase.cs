using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    private void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, "None", Resources.Load <Sprite>("None"), "None", 1, 1, 0, 0));
        cardList.Add(new Card(1, "Quick Attack", 0, 500, "Deals a Quick damage to opponent & get an extra card!", Resources.Load<Sprite>("QuickAttackImage"), "Yellow", 1, 1, 0, 0));
        cardList.Add(new Card(2, "ThunderShock", 3, 4000, "Deals Big Damage!", Resources.Load<Sprite>("ThunderShockImage"), "Yellow", 0, 1, 0, 0));
        cardList.Add(new Card(3, "ThunderWave", 5, 6000, "Powerful Attack that deals boat load of damage!", Resources.Load<Sprite>("ThunderwaveImage"), "Yellow", 0 , 1, 0, 0));
        cardList.Add(new Card(4, "Double Team", 2, 1000, "Deals damage & Brings Back A Card From The Grave!", Resources.Load<Sprite>("DoubleTeamImage"), "Yellow", 0, 1, 1, 0));
        cardList.Add(new Card(5, "Protect", 1, 1, "No Attack But Gets You Health!", Resources.Load<Sprite>("ProtectImage"), "Yellow", 0, 1, 0, 1000));
        cardList.Add(new Card(6, "ThunderBolt", 5, 6000, "Deals Big Damage!", Resources.Load<Sprite>("ThunderBoltImage"), "Yellow", 0, 1, 0, 0));
        cardList.Add(new Card(7, "Tackle", 2, 1000, "Deals damage & Brings Back A Card From The Grave!", Resources.Load<Sprite>("TackleImage"), "Yellow", 0, 1, 1, 0));
    }
}
