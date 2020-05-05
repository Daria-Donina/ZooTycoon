using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    public void SetValue(int value) => slider.value = value;
}
