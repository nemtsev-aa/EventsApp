using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AdminPages
{
    Statistic,
    CreateAccount,
    EventManagement,
    ViewEvents,
    ArchiveEvents
}
public class AdminPage : MonoBehaviour
{
    [SerializeField] public AdminPages PageName;
}
