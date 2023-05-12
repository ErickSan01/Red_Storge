using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerData : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI infoTextObject = null;
    [SerializeField] Image toggle = null;

    [Header("Textures")]
    [SerializeField] Sprite uncheckedToggle = null;
    [SerializeField] Sprite checkedToggle = null;
    private             bool            Checked             = false;
    [Header("References")]
    [SerializeField] GameEvents events = null;


    private int _answerIndex = -1;
    public int AnswerIndex { get { return _answerIndex; } }

    private             RectTransform   _rect               = null;
    public              RectTransform   Rect
    {
        get
        {
            if (_rect == null)
            {
                _rect = GetComponent<RectTransform>() ?? gameObject.AddComponent<RectTransform>();
            }
            return _rect;
        }
    }

    public void UpdateData (string info, int index)
    {
        infoTextObject.text = info;
        _answerIndex = index;
    }
    public void Reset ()
    {
        Checked = false;
        UpdateUI();
    }
    public void SwitchState ()
    {
        Checked = !Checked;
        UpdateUI();

        if (events.UpdateQuestionAnswer != null)
        {
            events.UpdateQuestionAnswer(this);
        }
    }
    void UpdateUI ()
    {
        if (toggle == null) return;

        toggle.sprite = (Checked) ? checkedToggle : uncheckedToggle;
    }

    
}
