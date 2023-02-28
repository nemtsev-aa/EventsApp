using Firebase;
using Firebase.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase.Database;
using Firebase.Auth;
using TMPro;


public class DataBase : MonoBehaviour
{
    DatabaseReference dbRef;
    FirebaseAuth auth;
    public Button LoginButton;
    public Button RegistrationButton;
    public TMP_InputField Email;
    public TMP_InputField Password;
    public TextMeshProUGUI Info;


    void Start()
    {
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
        auth = FirebaseAuth.DefaultInstance;

        LoginButton.onClick.AddListener(delegate {
            Login();
        });

        RegistrationButton.onClick.AddListener(delegate {
            Register();
        });
    }

  
    // Update is called once per frame
    public void SetValue()
    {
        dbRef.Child("Users").SetValueAsync("Atrem");
    }

    public void Login()
    {
        auth.SignInWithEmailAndPasswordAsync(Email.text, Password.text);
        Info.text = $"Успешный вход пользователя: {Email.text}";

        //SceneManager.LoadScene("PersonalAccount");
    }
    public void Register()
    {
        var email = Email.text;
        var password = Password.text;

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            FirebaseUser newUser = task.Result;
            Info.text = $"Успешная регистрация пользователя: {Email.text}";
        });
    }
}

