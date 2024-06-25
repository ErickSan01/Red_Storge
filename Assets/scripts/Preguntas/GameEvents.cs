using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Clase que representa los eventos del juego.
/// </summary>
[CreateAssetMenu(fileName = "GameEvents", menuName = "Quiz/new GameEvents")]
public class GameEvents : ScriptableObject
{
    /// <summary>
    /// Delegado para actualizar la interfaz de usuario de la pregunta.
    /// </summary>
    /// <param name="question">La pregunta actual.</param>
    public delegate void UpdateQuestionUICallback(Question question);
    public UpdateQuestionUICallback UpdateQuestionUI = null;

    /// <summary>
    /// Delegado para actualizar la respuesta de la pregunta.
    /// </summary>
    /// <param name="pickedAnswer">La respuesta seleccionada.</param>
    public delegate void UpdateQuestionAnswerCallback(AnswerData pickedAnswer);
    public UpdateQuestionAnswerCallback UpdateQuestionAnswer = null;

    /// <summary>
    /// Delegado para mostrar la pantalla de resolución.
    /// </summary>
    /// <param name="type">El tipo de pantalla de resolución.</param>
    /// <param name="score">La puntuación obtenida.</param>
    public delegate void DisplayResolutionScreenCallback(UIManager.ResolutionScreenType type, int score);
    public DisplayResolutionScreenCallback DisplayResolutionScreen = null;

    /// <summary>
    /// Delegado para actualizar la puntuación.
    /// </summary>
    public delegate void ScoreUpdatedCallback();
    public ScoreUpdatedCallback ScoreUpdated = null;

    [HideInInspector]
    public int CurrentFinalScore = 0;
    [HideInInspector]
    public int StartupHighscore = 0;
}


