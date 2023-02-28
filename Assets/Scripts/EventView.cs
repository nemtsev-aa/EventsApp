using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventView : MonoBehaviour
{
    [Tooltip("Название мероприятия")]
    [SerializeField] private TextMeshProUGUI _nameText;
    [Tooltip("Описание")]
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [Tooltip("Дата")]
    [SerializeField] private TextMeshProUGUI _dateText;
    [Tooltip("Время")]
    [SerializeField] private TextMeshProUGUI _timeText;
    [Tooltip("Возраст участников")]
    [SerializeField] private TextMeshProUGUI _ageRangeText;
    [Tooltip("Иконка")]
    [SerializeField] private Image _icon;

    private void GetValues(EventObj eventObj)
    {
        _nameText.text = eventObj.Name;
        _descriptionText.text = eventObj.Description;
        _dateText.text = eventObj.Date;
        _timeText.text = eventObj.Time;
        _ageRangeText.text = eventObj.AgeRange;
        
        StartCoroutine(EventIcon(ConnectionFirebase.User.PhotoUrl.ToString()));
    }
   
    private IEnumerator EventIcon(string url)
{
    using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
    {
        yield return uwr.SendWebRequest();
        _icon.sprite = Sprite.Create(DownloadHandlerTexture.GetContent(uwr), new Rect(0f, 0f, DownloadHandlerTexture.GetContent(uwr).width, DownloadHandlerTexture.GetContent(uwr).height), new Vector2(0f, 0f));
    }
}

}
