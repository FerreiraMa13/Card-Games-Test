using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
    public List<bs_Card> deck = new List<bs_Card>();
    public List<bs_Card> hand = new List<bs_Card>();
    public List<bs_Card> discard = new List<bs_Card>();
    public Transform[] fieldSlot;
    public Transform[] handSlot;
    public Transform discardSlot;
    public bool[] availableCardSlotField;
    public bool[] availableCardSlotHand;
    public int maxHandSize = 5;

    public void DrawFromDeck()
    {
        if(deck.Count > 0)
        {
            bs_Card top_card = deck[0];
            for(int i = 0; i < availableCardSlotHand.Length; i++)
            {
                if(availableCardSlotHand[i])
                {
                    top_card.gameObject.SetActive(true);
                    top_card.transform.position = handSlot[i].position;
                    availableCardSlotHand[i] = false;
                    deck.RemoveAt(0);
                    hand.Add(top_card);
                    return;
                }
            }
        }
    }
    public void MillFromDeck()
    {
        if (deck.Count > 0)
        {
            bs_Card top_card = deck[0];
            top_card.gameObject.SetActive(true);
            top_card.transform.position = discardSlot.position;
            deck.RemoveAt(0);
            discard.Insert(0, top_card);
            if(discard.Count > 1)
            {
                discard[1].gameObject.SetActive(false);
            }
            return;
        }
    }
}
