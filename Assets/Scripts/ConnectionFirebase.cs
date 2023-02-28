using Firebase;
using Firebase.Auth;
using Firebase.Database;
using UnityEngine;

public class ConnectionFirebase : MonoBehaviour
{
    public static FirebaseAuth AuthorizationPlayer;
    public static DatabaseReference Reference;
    public static FirebaseUser User;
    
    [SerializeField] private ErrorManager errorManager;
    
    private void Awake()
    {
        Reference = FirebaseDatabase.DefaultInstance.RootReference;
        AuthorizationPlayer = FirebaseAuth.DefaultInstance;
    }
}
