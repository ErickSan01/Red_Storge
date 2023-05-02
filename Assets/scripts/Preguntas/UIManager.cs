using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable()]
public struct UIManagerParameters{
    [Header("Answers Options")]
    [SerializeField] float margins;
    public float Margins {get{return margins;}}  
}

[Serializable()]
public struct UIElements
{
    [SerializeField] RectTransform answersContentArea;
    public RectTransform AnswersContentArea { get { return answersContentArea; } }

    [SerializeField] TextMeshProUGUI questionInfoTextObject;
    public TextMeshProUGUI QuestionInfoTextObject { get { return questionInfoTextObject; } }

    [SerializeField] CanvasGroup mainCanvasGroup;
    public CanvasGroup MainCanvasGroup { get { return mainCanvasGroup; } }
}

public class UIManager : MonoBehaviour
{
    public enum ResolutionScreenType {Correcto, Incorrecto}
    [SerializeField]    UIManagerParameters parameters;
    [Header("References")]
    [SerializeField]    GameEvents  events;

    [Header("UI Elements (Prefabs)")]
    [SerializeField]    AnswerData answerPrefab;

    [SerializeField]    UIElements uIElements;
    private             List<AnswerData>       currentAnswers               = new List<AnswerData>();
    void OnEnable()
    {
        events.UpdateQuestionUI         += UpdateQuestionUI;
        //events.DisplayResolutionScreen  += DisplayResolution;
        
    }
    
    void OnDisable()
    {
        events.UpdateQuestionUI         -= UpdateQuestionUI;
        //events.DisplayResolutionScreen  -= DisplayResolution;
        
    }
    void UpdateQuestionUI(Question question)
    {
        uIElements.QuestionInfoTextObject.text = question.Info;
        CreateAnswers(question);
    }
    void CreateAnswers(Question question)
    {
        EraseAnswers();

        float offset = 0 - parameters.Margins;
        for (int i = 0; i < question.Answers.Length; i++)
        {
            AnswerData newAnswer = (AnswerData)Instantiate(answerPrefab, uIElements.AnswersContentArea);
            newAnswer.UpdateData(question.Answers[i].Info, i);

            newAnswer.Rect.anchoredPosition = new Vector2(0, offset);

            offset -= (newAnswer.Rect.sizeDelta.y + parameters.Margins);
            uIElements.AnswersContentArea.sizeDelta = new Vector2(uIElements.AnswersContentArea.sizeDelta.x, offset * -1);

            currentAnswers.Add(newAnswer);
        }

        void EraseAnswers()
    {
        foreach (var answer in currentAnswers)
        {
            Destroy(answer.gameObject);
        }
        currentAnswers.Clear();
    }
    }


    
    
}
