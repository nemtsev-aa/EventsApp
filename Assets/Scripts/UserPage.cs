using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum UserPages
{
    Account,
    SearchEvent,
    ViewEvent,
    ArchiveEvents
}
public class UserPage : MonoBehaviour
{
    [SerializeField] public UserPages PageName;
}
