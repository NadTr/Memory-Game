using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameInitializer : MonoBehaviour
{
    const float CARD_SIZE = 1.0f;
    [SerializeField] private int rows = 3;
    [SerializeField] private int columns = 4;
    [SerializeField] private float gap = .5f;
    [SerializeField] private CardBehavior cardPrefab;
    private List<CardBehavior> deck = new();
    [SerializeField] private Color[] colors;
    [SerializeField] private CardsManager cardsManager;
    [SerializeField] private VictoryManager victoryManager;


    private void Start()
    {
        if (rows * columns % 2 != 0)
        {
            Debug.LogError("The number of cards need to be even");
            return;
        }
        if (colors.Length < rows * columns / 2)
        {
            Debug.LogError("Not enough colors to fill all the cards");
            return;
        }
        ObjectCreation();
        ObjectInitialization();

    }

    private void ObjectCreation()
    {
        Vector3 position;
        for (float x = 0f; x < columns * (CARD_SIZE + gap); x += CARD_SIZE + gap)
        {
            for (float z = 0f; z < rows * (CARD_SIZE + gap); z += CARD_SIZE + gap)
            {
                position = transform.position + Vector3.right * x + Vector3.forward * z;
                deck.Add(Instantiate(cardPrefab, position, Quaternion.identity));
            }
        }
        cardsManager = Instantiate(cardsManager);
    }
    private void ObjectInitialization()
    {
        cardsManager.Initialize(deck, colors, victoryManager);
    }
}
