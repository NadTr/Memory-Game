using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    List<CardBehavior> deck;
    Color[] colors;
    public void Initialize(List<CardBehavior> deck, Color[] colors)
    {
        this.deck = deck;
        this.colors = colors;

        int colorIndex;
        for (int i = 0; i < deck.Count(); i++)
        {
            colorIndex = Random.Range(0, colors.Length);
            deck[i].Initialize(colors[colorIndex], colorIndex, this);
            
        }
    }
}
