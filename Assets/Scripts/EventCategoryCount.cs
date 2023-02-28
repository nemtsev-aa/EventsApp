using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventCategoryCount : MonoBehaviour
{
    [Tooltip("Категрории конкурсов")]
    [SerializeField] private List<Category> _category;

    [Header("Текстовые поля")]
    [Tooltip("Общее количество мероприятий")]
    [SerializeField] private TextMeshProUGUI _allEventsCount;
    [Tooltip ("Категрория - Живопись и графика")]
    [SerializeField] private TextMeshProUGUI _paintingAndGraphicsEventsCount;
    [Tooltip("Категрория - Экология")]
    [SerializeField] private TextMeshProUGUI _ecologyEventsCount;
    [Tooltip("Категрория - Вокал")]
    [SerializeField] private TextMeshProUGUI _vocalsEventsCount;
    [Tooltip("Категрория - IT")]
    [SerializeField] private TextMeshProUGUI _iTEventsCount;
    [Tooltip("Категрория - Театральное искусство")]
    [SerializeField] private TextMeshProUGUI _theatricalArtEventsCount;
    [Tooltip("Категрория - Прикладное творчество")]
    [SerializeField] private TextMeshProUGUI _appliedCreativityEventsCount;
    [Tooltip("Категрория - Спортивные игры")]
    [SerializeField] private TextMeshProUGUI _sportsGamesEventsCount;
    [Tooltip("Категрория - Исследования")]
    [SerializeField] private TextMeshProUGUI _researchesEventsCount;
    
    void Start()
    {
        _category.Add(Category.All);
        _category.Add(Category.PaintingAndGraphics);
        _category.Add(Category.Ecology);
        _category.Add(Category.Vocals);
        _category.Add(Category.IT);
        _category.Add(Category.TheatricalArt);
        _category.Add(Category.AppliedCreativity);
        _category.Add(Category.SportsGames);
        _category.Add(Category.Researches);
    }

    private void SetEventsCount()
    {

    }
}
