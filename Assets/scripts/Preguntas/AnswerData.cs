using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Clase que representa los datos de una respuesta en el juego.
/// </summary>
public class AnswerData : MonoBehaviour
{
    [Header("Elementos de la interfaz de usuario")]
    [SerializeField] TextMeshProUGUI infoTextObject = null;
    [SerializeField] Image toggle = null;

    [Header("Texturas")]
    [SerializeField] Sprite uncheckedToggle = null;
    [SerializeField] Sprite checkedToggle = null;
    private bool Checked = false;
    [Header("Referencias")]
    [SerializeField] GameEvents events = null;

    private int _answerIndex = -1;

    /// <summary>
    /// Índice de la respuesta.
    /// </summary>
    public int AnswerIndex { get { return _answerIndex; } }

    private RectTransform _rect = null;

    /// <summary>
    /// Rectángulo asociado al objeto.
    /// </summary>
    public RectTransform Rect
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

    /// <summary>
    /// Actualiza los datos de la respuesta.
    /// </summary>
    /// <param name="info">Texto de información de la respuesta.</param>
    /// <param name="index">Índice de la respuesta.</param>
    public void UpdateData(string info, int index)
    {
        infoTextObject.text = info;
        _answerIndex = index;
    }

    /// <summary>
    /// Restablece el estado de la respuesta.
    /// </summary>
    public void Reset()
    {
        Checked = false;
        UpdateUI();
    }

    /// <summary>
    /// Cambia el estado de la respuesta.
    /// </summary>
    public void SwitchState()
    {
        Checked = !Checked;
        UpdateUI();

        if (events.UpdateQuestionAnswer != null)
        {
            events.UpdateQuestionAnswer(this);
        }
    }

    /// <summary>
    /// Actualiza la interfaz de usuario.
    /// </summary>
    private void UpdateUI()
    {
        if (toggle == null) return;

        toggle.sprite = (Checked) ? checkedToggle : uncheckedToggle;
    }
}
