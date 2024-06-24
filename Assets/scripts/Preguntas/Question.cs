using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Answer
{
    [SerializeField] private string _info;
    public string Info { get { return _info; } }

    [SerializeField] private bool _isCorrect;
    public bool IsCorrect { get { return _isCorrect; } }
}

/// <summary>
/// Clase que representa una pregunta en un cuestionario.
/// </summary>
[CreateAssetMenu(fileName = "New Question", menuName = "Quiz/new Question")]
public class Question : ScriptableObject
{
    /// <summary>
    /// Enumeración que define el tipo de respuesta de la pregunta.
    /// </summary>
    public enum AnswerType { Multi, Single }

    [SerializeField] private string _info = string.Empty;
    /// <summary>
    /// Información de la pregunta.
    /// </summary>
    public string Info { get { return _info; } }

    [SerializeField] Answer[] _answers = null;
    /// <summary>
    /// Respuestas posibles de la pregunta.
    /// </summary>
    public Answer[] Answers { get { return _answers; } }

    //Parameters
    [SerializeField] private bool _useTimer = false;
    /// <summary>
    /// Indica si la pregunta utiliza un temporizador.
    /// </summary>
    public bool UseTimer { get { return _useTimer; } }

    [SerializeField] private int _timer = 0;
    /// <summary>
    /// Duración del temporizador de la pregunta.
    /// </summary>
    public int Timer { get { return _timer; } }

    [SerializeField] private AnswerType _answerType = AnswerType.Multi;
    /// <summary>
    /// Tipo de respuesta de la pregunta.
    /// </summary>
    public AnswerType GetAnswerType { get { return _answerType; } }

    [SerializeField] private int _addScore = 10;
    /// <summary>
    /// Puntuación que se agrega al responder correctamente la pregunta.
    /// </summary>
    public int AddScore { get { return _addScore; } }

    /// <summary>
    /// Obtiene una lista de índices de las respuestas correctas.
    /// </summary>
    /// <returns>Lista de índices de las respuestas correctas.</returns>
    public List<int> GetCorrectAnswers ()
    {
        List<int> CorrectAnswers = new List<int>();
        for (int i = 0; i < Answers.Length; i++)
        {
            if (Answers[i].IsCorrect)
            {
                CorrectAnswers.Add(i);
            }
        }
        return CorrectAnswers;
    }
}


