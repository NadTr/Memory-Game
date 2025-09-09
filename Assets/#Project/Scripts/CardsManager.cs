using System.Collections.Generic;
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
        int cardIndex;

        List<int> colorsAlreadyInGame = new();
        List<CardBehavior> cards = new(deck);

        for (int _ = 0; _ < deck.Count / 2; _++)
        {
            colorIndex = Random.Range(0, colors.Length);
            while (colorsAlreadyInGame.Contains(colorIndex))
            {
                colorIndex = Random.Range(0, colors.Length);
            }
            colorsAlreadyInGame.Add(colorIndex);

            for (int n = 0; n < 2; n++)
            {
                cardIndex = Random.Range(0, cards.Count);
                cards[cardIndex].Initialize(colors[colorIndex], colorIndex, this);
                cards.RemoveAt(cardIndex);
            }

        }
    }
    public void CardIsClicked(CardBehavior card)
    {
        //tout les réactions des cartes face visibles
        if (!card.IsFaceUp)
        {
            card.FaceUp();
        }
        else
        {
            card.FaceDown();
        }

    }
}
