using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class BlackJack : MonoBehaviour
{
    Card[] Deck = new Card[52];
    Card[] ShuffledDeck = new Card[52];

    int DeckIndex;
    int PlayerScore;
    int DealerScore;
    int Balance = 10;

    List<int> PlayerHand = new List<int>();
    List<int> DealerHand = new List<int>();

    public GameObject[] SpeedCard = new GameObject[13];
    public GameObject[] HeartCard = new GameObject[13];
    public GameObject[] DiamondCard = new GameObject[13];
    public GameObject[] ClubCard = new GameObject[13];

    List<GameObject> PlayerHandObject = new List<GameObject>();
    List<GameObject> DealerHandObject = new List<GameObject>();

    private const int Spade = 0;
    private const int Heart = 1;
    private const int Diamond = 2;
    private const int Club = 3;

    void Start()
    {
        for (int i = 0; i < 52; i++)
        {
            Deck[i] = new Card();
            ShuffledDeck[i] = new Card();

            if (i < 40)
            {
                Deck[i].Num = i % 10 + 1;
                Deck[i].Val = i % 10 + 1;

                if (i < 10) Deck[i].Mark = Spade;
                else if (i < 20) Deck[i].Mark = Heart;
                else if (i < 30) Deck[i].Mark = Diamond;
                else Deck[i].Mark = Club;
            }

            else
            {
                Deck[i].Val = 10;
                Deck[i].Num = i % 3 + 11;

                if (i < 43) Deck[i].Mark = Spade;
                else if (i < 46) Deck[i].Mark = Heart;
                else if (i < 49) Deck[i].Mark = Diamond;
                else Deck[i].Mark = Club;
            }
        }

        Shuffle();
    }

    void Update()
    {
    }

    void Shuffle()
    {
        ShuffledDeck = Deck.OrderBy(i => Guid.NewGuid()).ToArray();

        DeckIndex = 0;
        PlayerHand = new List<int>();
        DealerHand = new List<int>();

        DrawCard(PlayerHand);
        DrawCard(PlayerHand);
        DrawCard(DealerHand);
        DrawCard(DealerHand);

        PlayerScore = CalculateScore(PlayerHand);
        DealerScore = CalculateScore(DealerHand);
    }

    void DrawCard(List<int> Hand)
    {
        Hand.Add(DeckIndex);
        DeckIndex++;
    }

    int CalculateScore(List<int> Hand)
    {
        int Score = 0;
        foreach (int i in Hand)
        {
            Score += ShuffledDeck[i].Val;
        }

        if (Score < 12)
        {
            foreach (int i in Hand)
            {
                if (ShuffledDeck[i].Val == 1)
                {
                    Score += 10;
                    break;
                }
            }
        }

        return Score;
    }
}

public class Card
{
    public int Mark;
    public int Num;
    public int Val;
}
