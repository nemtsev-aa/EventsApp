using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Auth;
using TMPro;
using System.Threading.Tasks;
using System;

public class LoginPage : MonoBehaviour
{
    //���� true, �� ����� ����������� ������������ �� ��������� ����� ������ �������.
    [Tooltip("��������� ������������")]
    [SerializeField] private bool _allowLoginIfHasUser = false;
    [Tooltip("����� - ��������� ������������")]
    [SerializeField] private Toggle _allowLoginToggle;
    [Tooltip("���� ����� - Email")]
    [SerializeField] private TMP_InputField _emailField;
    [Tooltip("���� ����� - Password")]
    [SerializeField] private TMP_InputField _passwordField;
    [Tooltip("������ - ����")]
    [SerializeField] private Button _loginButton;
    [Tooltip("������ - �����������")]
    [SerializeField] private Button _registrationButton;
    [Tooltip("��������� ���� - ����������")]
    [SerializeField] private TextMeshProUGUI _infoText;
    [Tooltip("��������� ���� - ID ������������")]
    public static string UserId = "";
    //����� FireBase ��� ���������� ��������������
    private FirebaseAuth _auth;
    //������ ����� � ������ �������
    private int _errorSuffixLenght = 28;
    
    /// <summary>
    /// �������� �����������
    /// </summary>
    public static event Action SuccessfulAuthorization;

    void Start()
    {
        SetToggleValue(_allowLoginIfHasUser);

        InitializeFirebase();

        _infoText.text = "";

        _allowLoginToggle.onValueChanged.AddListener(delegate
        {
           SetToggleValue(_allowLoginToggle.isOn);
        });

        _loginButton.onClick.AddListener(delegate
        {
            Login();
        });

        _registrationButton.onClick.AddListener(delegate
        {
            Register();
        });
    }
    private void GetToggleValue()
    {
        _allowLoginToggle.isOn = _allowLoginIfHasUser;
    }
    private void SetToggleValue(bool value)
    {
        _allowLoginToggle.isOn = value;
        _allowLoginIfHasUser = value;
    }

    private void InitializeFirebase()
    {
        //��������� ��� ������ ������� �������������� ��������� ��-��������
        _auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        //���� � ������ ������������ ������������
        if (_auth.CurrentUser != null)
        {
            //���� ���� "��������� ������" �� ����������
            if (_allowLoginIfHasUser == false)
            {
                //������������ ���� � �������
                _auth.SignOut();
            }
            else
            {
                //��������� � ���������� �� ��������� ������ ������������
                _emailField.text = _auth.CurrentUser.Email;
                _passwordField.text = "******";
                Invoke(nameof(GoToApp), 2f);
            }
        }
    }

    private void GoToApp()
    {
        UserId = _auth.CurrentUser.UserId;
        SuccessfulAuthorization?.Invoke();
    }

    private void Login()
    {
        var taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        var email = _emailField.text;
        var password = _passwordField.text;

        _auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                _infoText.text = task.Exception.GetBaseException().ToString().Remove(0, _errorSuffixLenght);
                return;
            }

            if (task.IsCompleted)
            {
                _infoText.text = $"������� ���� ������������ {_auth.CurrentUser.Email}";
                GoToApp();
                return;
            }
        }, taskScheduler);

        if (_auth.CurrentUser != null)
        {
            _auth.SignOut();
        }
    }

    private void Register()
    {
        var taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        //�������� �������� ����� �����
        var email = _emailField.text;
        var password = _passwordField.text;

        _auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                _infoText.text = task.Exception.GetBaseException().ToString().Remove(0, _errorSuffixLenght);
                return;
            }

            if (task.IsCompleted)
            {
                _infoText.text = $"������� ����������� ������������ {email}";
                GoToApp();
                return;
            }
        }, taskScheduler);
    }
}
