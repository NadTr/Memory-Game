using System.Collections.Generic;
using UnityEngine;

public class CardsManager_old : MonoBehaviour
{
    List<CardBehavior> deck;
    Color[] colors;
    List<int> colorsDoubleIndexes = new();
    public void Initialize(List<CardBehavior> deck, Color[] colors)
    {
        this.deck = deck;
        this.colors = colors;
        int colorIndex;

        for (int c = 0; c < deck.Count / 2; c++)
        {
            // colorCode = Random.Range(0, colors.Length);
            colorsDoubleIndexes.Add(c);
            colorsDoubleIndexes.Add(c);
        }


        for (int i = 0; i < deck.Count; i++)
        {
            colorIndex = colorsDoubleIndexes[Random.Range(0, colorsDoubleIndexes.Count)];
            // Debug.Log($"colorIndex = {colorIndex}");
            // deck[i].Initialize(colors[colorIndex], colorIndex, this);
            colorsDoubleIndexes.Remove(colorIndex);
        }
    }
}
