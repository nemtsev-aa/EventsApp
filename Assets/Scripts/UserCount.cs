using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserCount : MonoBehaviour
{
    [Tooltip("Категрории пользователей")]
    [SerializeField] private List<Gender> _gender;

    [Header("Текстовые поля")]
    [Tooltip("Общее количество")]
    [SerializeField] private TextMeshProUGUI _AllUserCount;
    [Tooltip("Категрория - Мужчины")]
    [SerializeField] private TextMeshProUGUI _maleUserCount;
    [Tooltip("Категрория - Женщины")]
    [SerializeField] private TextMeshProUGUI _femaleUserCount;
    void Start()
    {
        _gender.Add(Gender.All);
        _gender.Add(Gender.Male);
        _gender.Add(Gender.Female);
    }

    private void SetUserGenderCount()
    {

    }

}
