using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
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

    public GameObject Hand;

    public int numberOfCardsInDeck;

    public bool canBeSummon;
    public bool summoned;
    public GameObject battleZone;

    public static int drawX;
    public int drawXcards;
    public int addXmaxMana;

    public GameObject attackBoarder;

    public GameObject Target;
    public GameObject Enemy;

    public bool summoningSickness;
    public bool cantAttack;

    public bool canAttack;

    public static bool staticTargeting;
    public static bool staticTargetingEnemy;

    public bool targeting;
    public bool targetingEnemy;
    public bool onlyThisCardAttack;

    public GameObject summonBorder;


    private void Start()
    {
        thisCard[0] = CardDataBase.cardList[thisId];
        numberOfCardsInDeck = PlayerDeck.deckSize;

        canBeSummon = false;
        summoned = false;

        drawX = 0;

        canAttack = false;
        summoningSickness = true;

        Enemy = GameObject.Find("Enemy HP");

        targeting = false;
        targetingEnemy = false;
    }
    private void Update()
    {
        Hand = GameObject.Find("Hand");
        if (this.transform.parent == Hand.transform.parent)
        {
            cardBack = false;
        }

        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost = thisCard[0].cost;
        power = thisCard[0].power;
        cardDesc = thisCard[0].cardDesc;

        thisSprite = thisCard[0].thisImage;

        drawXcards = thisCard[0].drawXcards;
        addXmaxMana = thisCard[0].addXmaxMana;

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


        if (this.tag == "Clone")
        {
            thisCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";
        }

        if (TurnSystem.currentMana >= cost && summoned == false)
        {
            canBeSummon = true;
        }
        else
        {
            canBeSummon = false;
        }

        if (canBeSummon == true)
        {
            gameObject.GetComponent<Draggable>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Draggable>().enabled = false;
        }

        battleZone = GameObject.Find("Drop");

        if (summoned == false && this.transform.parent == battleZone.transform)
        {
            Summon();
        }

        if (canAttack == true)
        {
            attackBoarder.SetActive(true);
        }
        else
        {
            attackBoarder.SetActive(false);
        }

        if (TurnSystem.isYourTurn == false && summoned == true)
        {
            summoningSickness = false;
            canAttack = false;
        }

        if (TurnSystem.isYourTurn == true && summoningSickness == false && cantAttack == false)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }

        targeting = staticTargeting;
        targetingEnemy = staticTargetingEnemy;

        if (targetingEnemy == true)
        {
            Target = Enemy;
        }
        else
        {
            Target = null;
        }

        if (targeting == true && targetingEnemy == true && onlyThisCardAttack == true)
        {
            Attack();
        }

        if(canBeSummon == true)
        {
            summonBorder.SetActive(true);
        }
        else
        {
            summonBorder.SetActive(false);
        }
    }
    public void Summon()
    {
        TurnSystem.currentMana -= cost;
        summoned = true;

        MaxMana(addXmaxMana);
        drawX = drawXcards;
    }

    public void MaxMana(int x)
    {
        TurnSystem.maxMana += x;
    }

    public void Attack()
    {
        if (canAttack == true)
        {
            if (Target != null)
            {
                if (Target == Enemy)
                {
                    EnemyHp.staticHp -= power;
                    targeting = false;
                    cantAttack = true;
                }
                if (Target.name == "CardToHand(Clone)")
                {
                    canAttack = true;
                }
            }
        }
    }

    public void UntargetEnemy()
    {
        staticTargetingEnemy = false;
    }

    public void TargetEnemy()
    {
        staticTargetingEnemy = true;
    }

    public void StartAttack()
    {
        staticTargeting = true;
    }

    public void StopAttack()
    {
        staticTargeting = false;
    }

    public void OneCardAttack()
    {
        onlyThisCardAttack = true;
    }

    public void OneCardAttackStop()
    {
        onlyThisCardAttack = false;
    }
}
