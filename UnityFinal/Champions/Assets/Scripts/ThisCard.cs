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
    public Text cardDescText;

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

    public bool canBeDestroyed;
    public GameObject Graveyard;
    public bool beInGraveyard;

    public int hurted;
    public int actualpower;
    public int returnXcards;
    public bool useReturn;

    public static bool YouCanReturn;

    public int healXpower;
    public bool canHeal;

    // Start is called before the first frame update
    void Start()
    {
        thisCard[0] = CardDataBase.cardList[thisId];
        numberOfCardsInDeck = PlayerDeck.deckSize;

        canBeSummon = false;
        summoned = false;

        drawX = 0;

        canAttack = false;
        summoningSickness = true;

        Enemy = GameObject.Find("EnemyHp");

        targeting = false;
        targetingEnemy = false;

        canHeal = true;
    }

    // Update is called once per frame
    void Update()
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

        returnXcards = thisCard[0].returnXcards;

        healXpower = thisCard[0].healXpower;

        nameText.text = "" + cardName;
        costText.text = "" + cost;
        actualpower = power - hurted;
        powerText.text = "" + actualpower;
        cardDescText.text = "" + cardDesc;
        thatImage.sprite = thisSprite;

        if(thisCard[0].color == "Yellow")
        {
            frame.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
        }

        staticCardBack = cardBack;

        if(this.tag == "Clone")
        {
            thisCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";
        }
        if (TurnSystem.currentMana >= cost && summoned == false && beInGraveyard == false)
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

        if (canAttack == true && beInGraveyard == false)
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
            cantAttack = false;
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

        if (canBeSummon == true || YouCanReturn == true && beInGraveyard == true)
        {
            summonBorder.SetActive(true);
        }
        else
        {
            summonBorder.SetActive(false);
        }

        if(actualpower <= 0)
        {
            Destroy();
        }

        if(returnXcards >0 && summoned == true && useReturn == false)
        {
            Return(returnXcards);
            useReturn = true;
        }

        if(TurnSystem.isYourTurn == false)
        {
            YouCanReturn = false;
        }

        if(canHeal == true && summoned == true)
        {
            Heal();
            canHeal = false;
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
        if (canAttack == true && summoned == true)
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

    public void Destroy()
    {
        Graveyard = GameObject.Find("GraveYard");
        canBeDestroyed = true;
        if(canBeDestroyed == true)
        {
            this.transform.SetParent(Graveyard.transform);
            canBeDestroyed = false;
            summoned = false;
            beInGraveyard = true;
            hurted = 0;
        }
    }

    public void Return(int x)
    {
        for(int i = 0; i <= x; i++)
        {
            ReturnCard();
        }
    }

    public void ReturnCard()
    {
        YouCanReturn = true;
    }

    public void ReturnThis()
    {
        if(beInGraveyard == true && YouCanReturn == true)
        {
            this.transform.SetParent(Hand.transform);
            YouCanReturn = false;
            beInGraveyard = false;
            summoningSickness = true;
        }
    }

    public void Heal()
    {
        PlayerHp.staticHp += healXpower;
    }
}
