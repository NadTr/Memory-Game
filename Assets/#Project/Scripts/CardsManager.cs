using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    [SerializeField] private float delayBeforeFaceDown = 1f;
    // [SerializeField] private string Victory;
    List<CardBehavior> deck;
    Color[] colors;
    private CardBehavior cardMemorized = null;
    private int cardsWon = 0;
    public void Initialize(List<CardBehavior> deck, Color[] colors)
    {
        this.deck = deck;
        this.colors = colors;
        cardsWon = 0;

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
        if (card.IsFaceUp)
        {
            return;
        }
        else
        {
            card.FaceUp();

            if (cardMemorized != null)
            {
                if (cardMemorized.IndexColor == card.IndexColor)
                {
                    card.Won();
                    cardMemorized.Won();
                    cardsWon += 2;
                    Debug.Log($"Cartes gagnées : {cardsWon}");

                    if (cardsWon >= deck.Count)
                    {
                        Debug.Log("Victoire");
                        Invoke("Victory", 2f);
                    }

                }
                else
                {
                    card.FaceDown(delayBeforeFaceDown);
                    cardMemorized.FaceDown(delayBeforeFaceDown);
                }
                cardMemorized = null;
            }
            else
            {
                cardMemorized = card;
            }
        }
    }
    public void Victory()
    {
        SceneManager.LoadScene("Victory");
    }
}
