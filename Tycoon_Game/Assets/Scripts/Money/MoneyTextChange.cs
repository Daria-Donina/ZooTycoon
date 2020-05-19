using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Money.Entities;

public class MoneyTextChange : MonoBehaviour
{
    [SerializeField]
    private Text moneyText;

    private void Update() => moneyText.text = Zoo.Money.ToString();
}
