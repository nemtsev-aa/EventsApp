using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventCategoryCount : MonoBehaviour
{
    [Tooltip("���������� ���������")]
    [SerializeField] private List<Category> _category;

    [Header("��������� ����")]
    [Tooltip("����� ���������� �����������")]
    [SerializeField] private TextMeshProUGUI _allEventsCount;
    [Tooltip ("���������� - �������� � �������")]
    [SerializeField] private TextMeshProUGUI _paintingAndGraphicsEventsCount;
    [Tooltip("���������� - ��������")]
    [SerializeField] private TextMeshProUGUI _ecologyEventsCount;
    [Tooltip("���������� - �����")]
    [SerializeField] private TextMeshProUGUI _vocalsEventsCount;
    [Tooltip("���������� - IT")]
    [SerializeField] private TextMeshProUGUI _iTEventsCount;
    [Tooltip("���������� - ����������� ���������")]
    [SerializeField] private TextMeshProUGUI _theatricalArtEventsCount;
    [Tooltip("���������� - ���������� ����������")]
    [SerializeField] private TextMeshProUGUI _appliedCreativityEventsCount;
    [Tooltip("���������� - ���������� ����")]
    [SerializeField] private TextMeshProUGUI _sportsGamesEventsCount;
    [Tooltip("���������� - ������������")]
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
