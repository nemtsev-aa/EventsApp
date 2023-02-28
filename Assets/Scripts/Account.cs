using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Firebase.Auth;
using System.Linq;
using System.Text.RegularExpressions;
using System;

public class Account : MonoBehaviour
{
    [Tooltip("���")]
    [SerializeField] private TMP_InputField _inputFieldName;
    [Tooltip("���� ��������")]
    [SerializeField] private TMP_InputField _inputFieldBirthdate;
    [Tooltip("������ ��������� ��� ������ ����")]
    [SerializeField] private ToggleGroup _genderToggle;
    [Tooltip("������ ��������� ��� ������ ���������")]
    [SerializeField] private ToggleGroup _interestsToggles;
    [Tooltip("�������� ������")]
    [SerializeField] private ErrorManager _errorManager;
    [Tooltip("�������� ����������")]
    [SerializeField] private UI_Manager _uiManager;
    [Tooltip("���� ��� ������ ������")]
    [SerializeField] private TextMeshProUGUI _errorText;

    // ��� ������������
    string _name;
    // ���� ��������
    string _birthdate;
    // ��� ������������
    private Gender _gender;
    // ��������
    private List<string> _interests;

    public void UpdatingButton()
    {
        _name = GetNameValue();
        Debug.Log("_name: " + _name);
        _birthdate = GetBirthdateValue();
        Debug.Log("_birthdate: " + _birthdate);
        _gender = GetGenderValue();
        Debug.Log("_gender: " + _gender);
        _interests = GetInterestsList();
        Debug.Log("_interests: " + _interests.Count);

        UpdatingUserData(_name, _birthdate, _gender, _interests);
    }

    private void UpdatingUserData(string name, string birthdate, Gender gender, List<string> interests)
    {
        //UserProfile profile = new UserProfile { DisplayName = name };
        //var profileTask = ConnectionFirebase.User.UpdateUserProfileAsync(profile);
        //yield return new WaitUntil(predicate: () => profileTask.IsCompleted);

        //if (profileTask.Exception != null)
        //{
        //    _errorManager.UpdateTextError(_errorText, "������ ���������� �������!");
        //}
        //else
        //{
        //    //_uiManager.SwitchAdminPage(1);
        //    _errorManager.UpdateTextError(_errorText, "");
        //    _errorManager.UpdateTextError(_errorText, "�������� ���������� ������ �������!");
        //}

        string userId = ConnectionFirebase.AuthorizationPlayer.CurrentUser.UserId;

        if (InteractionFirebase.FindUserById(userId) != true)
        {
            /// ������������ �� ������ � ��
            User newUser = new User();
            newUser.UserId = userId;
            newUser.Name = name;
            newUser.Birthdate = birthdate;
            newUser.Gender = gender;
            newUser.Actions = new List<UserActions>();
            newUser.PlannedEvents = new List<EventObj>();
            newUser.ArhiveEvents = new List<EventObj>();
            newUser.Interests = interests;

            InteractionFirebase.WriteUserData(newUser);
        }
    }

    private string GetNameValue()
    {
        string errorNameValue = "error";
        string nameValue = _inputFieldName.text;

        if (checkString(nameValue) != "errorName")
        {
            return errorNameValue;
        }
        else
        {
            _errorManager.UpdateTextError(_errorText, "������ ����� �.�.�.");
            return errorNameValue;
        }
    }
    private string checkString(string message)
    {
        if (message.Length > 0)
        {
            char[] symbols = "�������������������������������� �����Ũ��������������������������-'".ToCharArray();
            char[] chars = message.ToLower().ToCharArray();
            foreach (char symbol in chars)
            {
                if (!symbols.Contains(symbol))
                {
                    return "errorName";
                }
            }
        }
        else
        {
            return "errorName";
        }
        return message;
    }

    private string GetBirthdateValue()
    {
        string errorNameValue = "error";
        string pattern = @"[0-9]{2}/[0-9]{2}/[0-9]{4}";
        string nameValue = _inputFieldBirthdate.text;

        if (nameValue.Length > 0)
        {
            if (Regex.IsMatch(nameValue, pattern, RegexOptions.IgnoreCase))
            {
                return nameValue;
            }
            else
            {
                _errorManager.UpdateTextError(_errorText, "������ ������� ����� ���� ��������");
                return errorNameValue;
            }
        }
        else
        {
            _errorManager.UpdateTextError(_errorText, "���� �������� �� �������");
            return errorNameValue;
        }
    }

    private Gender GetGenderValue()
    {
        Toggle activeToggle = _genderToggle.ActiveToggles().FirstOrDefault();
        string genderValue = activeToggle.gameObject.name;
        if (genderValue == "Male")
        {
            return Gender.Male;
        }
        else
        {
            return Gender.Female;
        }
        
    }

    private List<string> GetInterestsList()
    {
        if (_genderToggle.ActiveToggles().FirstOrDefault() != null)
        {
            List<string> interests = new List<string>();
            Toggle[] toggles = _interestsToggles.GetComponentsInChildren<Toggle>();
           
            foreach (var iToogle in toggles)
            {
                if (iToogle.isOn)
                {
                    TextMeshProUGUI toggleText = iToogle.GetComponentInChildren<TextMeshProUGUI>();
                    interests.Add(toggleText.text);
                }
            }
            return interests;
        }
        else
        {
            _errorManager.UpdateTextError(_errorText, "�������� �� ��������");
            return null;
        }
    }
}
