using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    List<CardBehavior> deck;
    Color[] colors;
    private CardBehavior cardMemorized = null;
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

            if (cardMemorized != null)
            {
                if (cardMemorized.IndexColor == card.IndexColor)
                {
                    card.Won();
                    cardMemorized.Won();
                    Debug.Log("Bravo, Ce sont les mêmes");
                }
                else
                {
                    card.FaceDown();
                    cardMemorized.FaceDown();
                    Debug.Log("Cartes différentes, réessayez");
                }
                cardMemorized = null;
            }
            else
            {
                cardMemorized = card;
            }
        }
        

    }
}
