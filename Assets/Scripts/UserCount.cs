using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserCount : MonoBehaviour
{
    [Tooltip("���������� �������������")]
    [SerializeField] private List<Gender> _gender;

    [Header("��������� ����")]
    [Tooltip("����� ����������")]
    [SerializeField] private TextMeshProUGUI _AllUserCount;
    [Tooltip("���������� - �������")]
    [SerializeField] private TextMeshProUGUI _maleUserCount;
    [Tooltip("���������� - �������")]
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
