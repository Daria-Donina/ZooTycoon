﻿using System;
using UnityEngine;

public class GuestsGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject human1;
    [SerializeField]
    private GameObject human2;
    [SerializeField]
    private GameObject human3;
    [SerializeField]
    private GameObject human4;
    [SerializeField]
    private GameObject human5;
    [SerializeField]
    private GameObject human6;

    private GameObject[] people;

    private Vector3[] startedPositions;

    private int localAnimalCount;

    private float waitTime;

    private float timer;

    private int expectedNumberOfGuests;

    // Start is called before the first frame update
    void Start()
    {
        people = new GameObject[] { human1, human2, human3, human4, human5, human6 };
        localAnimalCount = Zoo.AnimalCount;

        var startedPosition1 = new Vector3(-0.5f, -13.5f, 0);
        var startedPosition2 = new Vector3(0.5f, -13.5f, 0);

        startedPositions = new Vector3[] { startedPosition1, startedPosition2 };

        waitTime = UnityEngine.Random.Range(5, 26);
        timer = 0.0f;

        expectedNumberOfGuests = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            timer -= waitTime;

            if (localAnimalCount != Zoo.AnimalCount)
            {
                localAnimalCount = Zoo.AnimalCount;
                expectedNumberOfGuests = GenerateNumberOfGuests();
            }

            if (Zoo.PeopleCount != expectedNumberOfGuests)
            {
                GenerateGuest();
                ++Zoo.PeopleCount;
            }

            waitTime = UnityEngine.Random.Range(5, 26);
        }
    }

    private int GenerateNumberOfGuests() => (int)Math.Exp(localAnimalCount);

    private void GenerateGuest()
    {
        var guestPrefab = people[UnityEngine.Random.Range(0, 6)];

        var startedPosition = startedPositions[UnityEngine.Random.Range(0, 2)];
        Instantiate(guestPrefab, startedPosition, transform.rotation);
    }
}
