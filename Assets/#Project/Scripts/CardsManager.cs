using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    List<CardBehavior> deck;
    Color[] colors;
    List<Color> colorscopy;
    public void Initialize(List<CardBehavior> deck, Color[] colors)
    {
        this.deck = deck;
        this.colors = colors;

        // choisir une couleur au hasard , l'affecter à deux carte puis la rendre impossible à choisir (=> faire une copie de colors pour éviter de changer le tableau)
        // utiliser une liste pour facilement retirer des trucs
        int colorIndex;
        // for (int c = 0; c < deck.Count() / 2; c++)
        // {
        //     colorIndex = Random.Range(0, colors.Length);
        //     colorscopy.Add(colors[colorIndex]);
        //     colorscopy.Add(colors[colorIndex]);
        // }
        for (int c = 0; c < deck.Count() / 2; c++)
        {
            colorIndex = Random.Range(0, colors.Length);
            colorscopy.Add(colors[colorIndex]);
            
        }


            for (int i = 0; i < deck.Count(); i++)
            {
                colorIndex = Random.Range(0, colors.Length);
                deck[i].Initialize(colors[colorIndex], colorIndex, this);

            }
    }
}
