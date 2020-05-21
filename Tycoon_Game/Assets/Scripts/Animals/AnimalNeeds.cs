using UnityEngine;
using Assets.Scripts.Animals.Entities;
using UnityEngine.UI;

public class AnimalNeeds : MonoBehaviour
{
    [SerializeField]
    private Bar foodBarPrefab;

    [SerializeField]
    private Bar waterBarPrefab;

    [SerializeField]
    private Bar entertainmentBarPrefab;

    [SerializeField]
    private Bar inhabitancyBarPrefab;

    [SerializeField]
    private Bar welfareBarPrefab;

    private Bar foodBar;
    private Bar waterBar;
    private Bar entertainmentBar;
    private Bar inhabitancyBar;
    private Bar welfareBar;

    [SerializeField]
    private GameObject animalNeedsPanelPrefab;

    private GameObject animalNeedsPanel;

    private AnimalInfo animal;

    // Start is called before the first frame update
    void Start()
    {
        animal = new AnimalInfo(Zoo.AnimalCount)
        {
            Food = 100f,
            Water = 100f,
            Entertainment = 100f,
            Inhabitancy = 100f,
            Welfare = 100f
        };

        Zoo.AnimalCount++;
        Zoo.AnimalWelfares.Add(animal.Welfare);

        CalculateInhabitancy();

        animalNeedsPanel = Instantiate(animalNeedsPanelPrefab, transform.position, transform.rotation) as GameObject;
        animalNeedsPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

        foodBar = Instantiate(foodBarPrefab, transform.position, transform.rotation) as Bar;
        inhabitancyBar = Instantiate(inhabitancyBarPrefab, transform.position, transform.rotation) as Bar;
        entertainmentBar = Instantiate(entertainmentBarPrefab, transform.position, transform.rotation) as Bar;
        waterBar = Instantiate(waterBarPrefab, transform.position, transform.rotation) as Bar;
        welfareBar = Instantiate(welfareBarPrefab, transform.position, transform.rotation) as Bar;

        var children = animalNeedsPanel.GetComponentsInChildren(typeof(HorizontalLayoutGroup), true);
        GameObject layoutTopForBars = null;
        GameObject layoutBottomForBars = null;
        GameObject welfareLayoutBar = null;

        foreach (var child in children)
        {
            if (child.gameObject.name == "LayoutTopForBars")
            {
                layoutTopForBars = child.gameObject;
            }
            if (child.gameObject.name == "LayoutBottomForBars")
            {
                layoutBottomForBars = child.gameObject;
            }
            if (child.gameObject.name == "WelfareLayoutBar")
            {
                welfareLayoutBar = child.gameObject;
            }
        }
        foodBar.transform.SetParent(layoutTopForBars.transform, false);
        inhabitancyBar.transform.SetParent(layoutTopForBars.transform, false);
        waterBar.transform.SetParent(layoutBottomForBars.transform, false);
        entertainmentBar.transform.SetParent(layoutBottomForBars.transform, false);
        welfareBar.transform.SetParent(welfareLayoutBar.transform, false);

        animalNeedsPanel.SetActive(false);
    }

    [System.Obsolete]
    private void FixedUpdate()
    {
        if (animal.Food > 0)
        {
            animal.Food -= 0.3f;
        }

        if (animal.Water > 0)
        {
            animal.Water -= 0.3f;
        }

        if (animal.Entertainment > 0)
        {
            animal.Entertainment -= 0.3f;
        }

        CalculateInhabitancy();
        CalculateWelfare();

        Zoo.AnimalWelfares.Insert(animal.AnimalIndex, animal.Welfare);
        if (animalNeedsPanel.active)
        {
            foodBar.SetValue((int)animal.Food);
            inhabitancyBar.SetValue((int)animal.Inhabitancy);
            entertainmentBar.SetValue((int)animal.Entertainment);
            waterBar.SetValue((int)animal.Water);
            welfareBar.SetValue((int)animal.Welfare);
        }
    }

    private void OnMouseDown()
    {
        if (GameObject.FindGameObjectWithTag("StorePanel") != null)
        {
            var panels = GameObject.FindGameObjectsWithTag("Panel");

            foreach (var panel in panels)
            {
                panel.SetActive(false);
            }

            foodBar.SetValue((int)animal.Food);
            inhabitancyBar.SetValue((int)animal.Inhabitancy);
            entertainmentBar.SetValue((int)animal.Entertainment);
            waterBar.SetValue((int)animal.Water);
            welfareBar.SetValue((int)animal.Welfare);

            animalNeedsPanel.SetActive(true);
        }
    }

    [System.Obsolete]
    private void OnCollisionStay2D(Collision2D collision)
    {
        var gameObject = collision.gameObject;
        if (gameObject.CompareTag("Food"))
        {
            animal.Food = 100;
            if (animalNeedsPanel.active)
            {
                foodBar.SetValue((int)animal.Food);
            }
            gameObject.SetActive(false);
        }
        if (gameObject.CompareTag("Water"))
        {
            animal.Water = 100;
            if (animalNeedsPanel.active)
            {
                waterBar.SetValue((int)animal.Water);
            }
            gameObject.SetActive(false);
        }
        if (gameObject.CompareTag("Entertainment"))
        {
            animal.Entertainment = 100;
            if (animalNeedsPanel.active)
            {
                entertainmentBar.SetValue((int)animal.Entertainment);
            }
            gameObject.SetActive(false);
        }
    }

    public void CalculateInhabitancy()
    {
        //to do
    }

    /// <summary>
    /// Вычисляет welfare животного, исходя из значений food, water, inhabitancy и entertainment.
    /// </summary>
    private void CalculateWelfare()
    {
        float foodPart;
        float waterPart;
        float entertainmentPart;
        float inhabitancyPart;

        //Считаем вклад entertainment в welfare.
        if (animal.Entertainment > 50f)
        {
            entertainmentPart = 25f;
        }
        else
        {
            entertainmentPart = animal.Entertainment / 50f * 25f;
        }

        //Считаем вклад food в welfare.
        if (animal.Food > 50f)
        {
            foodPart = 25f;
        }
        else
        {
            foodPart = animal.Food / 50f * 25f;
        }

        //Считаем вклад water в welfare.
        if (animal.Water > 50f)
        {
            waterPart = 25f;
        }
        else
        {
            waterPart = animal.Water / 50f * 25f;
        }

        inhabitancyPart = animal.Inhabitancy / 100f * 25f;

        animal.Welfare = foodPart + waterPart + entertainmentPart + inhabitancyPart;
    }
}
