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
    //Если true, то после регистрации пользователю не надобудет потом заново входить.
    [Tooltip("Запомнить пользователя")]
    [SerializeField] private bool _allowLoginIfHasUser = false;
    [Tooltip("Флажёк - Запомнить пользователя")]
    [SerializeField] private Toggle _allowLoginToggle;
    [Tooltip("Поле ввода - Email")]
    [SerializeField] private TMP_InputField _emailField;
    [Tooltip("Поле ввода - Password")]
    [SerializeField] private TMP_InputField _passwordField;
    [Tooltip("Кнопка - вход")]
    [SerializeField] private Button _loginButton;
    [Tooltip("Кнопка - регистрация")]
    [SerializeField] private Button _registrationButton;
    [Tooltip("Текстовое поле - информация")]
    [SerializeField] private TextMeshProUGUI _infoText;
    [Tooltip("Текстовое поле - ID пользователя")]
    public static string UserId = "";
    //Класс FireBase для реализации аутентификации
    private FirebaseAuth _auth;
    //Лишняя часть в тексте ошибкок
    private int _errorSuffixLenght = 28;
    
    /// <summary>
    /// Успешная авторизация
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
        //Испоьзуем для работы системы аутентицикации настройки по-умоланию
        _auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        //Если в систем присутствует пользователь
        if (_auth.CurrentUser != null)
        {
            //Если флаг "Запомнить пароль" не установлен
            if (_allowLoginIfHasUser == false)
            {
                //Осуществляем вход в систему
                _auth.SignOut();
            }
            else
            {
                //Переходим в приложение по сохранёным данным пользователя
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
                _infoText.text = $"Удачный вход пользователя {_auth.CurrentUser.Email}";
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

        //Добавить проверку полей ввода
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
                _infoText.text = $"Удачная регистрация пользователя {email}";
                GoToApp();
                return;
            }
        }, taskScheduler);
    }
}
