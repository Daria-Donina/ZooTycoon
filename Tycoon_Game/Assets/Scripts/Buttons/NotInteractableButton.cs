using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotInteractableButton : MonoBehaviour
{
    void Start() => GetComponent<Button>().interactable = false;
}
