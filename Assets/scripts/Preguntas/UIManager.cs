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

    [Header("Resolution Screen Options")]
    [SerializeField] Color correctBGColor;
    public Color CorrectBGColor { get { return correctBGColor; } }
    [SerializeField] Color incorrectBGColor;
    public Color IncorrectBGColor { get { return incorrectBGColor; } }
    [SerializeField] Color finalBGColor;
    public Color FinalBGColor { get { return finalBGColor; } }
    
}

[Serializable()]
public struct UIElements
{
    [SerializeField] RectTransform answersContentArea;
    public RectTransform AnswersContentArea { get { return answersContentArea; } }
    [SerializeField] TextMeshProUGUI questionInfoTextObject;
    public TextMeshProUGUI QuestionInfoTextObject { get { return questionInfoTextObject; } }
    [SerializeField] TextMeshProUGUI scoreText;
    public TextMeshProUGUI ScoreText { get { return scoreText; } }
    [Space]
    [SerializeField] Animator resolutionScreenAnimator;
    public Animator ResolutionScreenAnimator { get { return resolutionScreenAnimator; } }

    [SerializeField] Image resolutionBG;
    public Image ResolutionBG { get { return resolutionBG; } }

    [SerializeField] TextMeshProUGUI resolutionStateInfoText;
    public TextMeshProUGUI ResolutionStateInfoText { get { return resolutionStateInfoText; } }

    [SerializeField] TextMeshProUGUI resolutionScoreText;
    public TextMeshProUGUI ResolutionScoreText { get { return resolutionScoreText; } }

    [Space]

    [SerializeField] TextMeshProUGUI highScoreText;
    public TextMeshProUGUI HighScoreText { get { return highScoreText; } }

    [SerializeField] CanvasGroup mainCanvasGroup;
    public CanvasGroup MainCanvasGroup { get { return mainCanvasGroup; } }

    [SerializeField] RectTransform finishUIElements;
    public RectTransform FinishUIElements { get { return finishUIElements; } }



}

public class UIManager : MonoBehaviour
{
    public enum ResolutionScreenType {Correcto, Incorrecto, Finish}
    [Header("References")]
    [SerializeField] GameEvents events;
   

    [Header("UI Elements (Prefabs)")]
     [SerializeField] UIElements uIElements = new UIElements();
    [SerializeField]  AnswerData answerPrefab;
    [Space]
    [SerializeField]    UIManagerParameters    parameters = new UIManagerParameters();
    private    IEnumerator  IE_DisplayTimedResolution    = null;

    private   List<AnswerData>  currentAnswers    = new List<AnswerData>();
    private   int   resStateParaHash   = 0;
    void OnEnable()
    {
        events.UpdateQuestionUI         += UpdateQuestionUI;
        events.DisplayResolutionScreen  += DisplayResolution;
        
    }
    
    void OnDisable()
    {
        events.UpdateQuestionUI         -= UpdateQuestionUI;
        events.DisplayResolutionScreen  -= DisplayResolution;
        
    }

void Start()
    {
        //UpdateScoreUI();
        resStateParaHash = Animator.StringToHash("ScreenState");
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

void UpdateResUI(ResolutionScreenType type, int score)
    {
        var highscore = PlayerPrefs.GetInt(GameUtility.SavePrefKey);

        switch (type)
        {
            case ResolutionScreenType.Correcto:
                uIElements.ResolutionBG.color = parameters.CorrectBGColor;
                uIElements.ResolutionStateInfoText.text = "CORRECT!";

                break;
            case ResolutionScreenType.Incorrecto:
                uIElements.ResolutionBG.color = parameters.IncorrectBGColor;
                uIElements.ResolutionStateInfoText.text = "WRONG!";

                break;
            case ResolutionScreenType.Finish:
                uIElements.ResolutionBG.color = parameters.FinalBGColor;

                uIElements.FinishUIElements.gameObject.SetActive(true);
                uIElements.HighScoreText.gameObject.SetActive(true);
                uIElements.HighScoreText.text = ((highscore > events.StartupHighscore) ? "<color=yellow>new </color>" : string.Empty) + "Highscore: " + highscore;
                break;
        }
    }

    IEnumerator CalculateScore()
    {
        var scoreValue = 0;
        while (scoreValue < events.CurrentFinalScore)
        {
            scoreValue++;
            uIElements.ResolutionScoreText.text = scoreValue.ToString();

            yield return null;
        }
    }

    IEnumerator DisplayTimedResolution()
    {
        yield return new WaitForSeconds(GameUtility.ResolutionDelayTime);
        uIElements.ResolutionScreenAnimator.SetInteger(resStateParaHash, 1);
        uIElements.MainCanvasGroup.blocksRaycasts = true;
    }
    void DisplayResolution(ResolutionScreenType type, int score)
    {
        UpdateResUI(type, score);
        uIElements.ResolutionScreenAnimator.SetInteger(resStateParaHash, 2);
        uIElements.MainCanvasGroup.blocksRaycasts = false;

        if (type != ResolutionScreenType.Finish)
        {
            if (IE_DisplayTimedResolution != null)
            {
                StopCoroutine(IE_DisplayTimedResolution);
            }
            IE_DisplayTimedResolution = DisplayTimedResolution();
            StartCoroutine(IE_DisplayTimedResolution);
        }
    }
    
}
