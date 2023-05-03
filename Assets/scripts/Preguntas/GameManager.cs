using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
   private Question[] _questions = null;
    public Question[]Questions { get { return _questions; } }
    [SerializeField]    GameEvents          events                  = null;
    private             List<AnswerData>    PickedAnswers           = new List<AnswerData>();
    private             List<int>           FinishedQuestions       = new List<int>();

    private int currentQuestion = 0;
    void Start(){
        LoadQuestions();
        foreach (var question in Questions)
        {
            Debug.Log(question.Info);
        }
        Display();
    }

    //Actualizar cual de las respuestas es la que fue tomada, y que cambie el toggle.
    public void UpdateAnswers(AnswerData newAnswer)
    {
        foreach (var answer in PickedAnswers)
            {
                if (answer != newAnswer)
                {
                    answer.Reset();
                }
            }
            PickedAnswers.Clear();
            PickedAnswers.Add(newAnswer);
    }
    public void EraseAnswers()
    {
        PickedAnswers = new List<AnswerData>();
    }

    void Display()
    {
        EraseAnswers();
        var question = GetRandomQuestion();

        if (events.UpdateQuestionUI != null)
        {
            events.UpdateQuestionUI(question);
        } else { Debug.LogWarning("Ups! Something went wrong while trying to display new Question UI Data. GameEvents.UpdateQuestionUI is null. Issue occured in GameManager.Display() method."); }
    }

    Question GetRandomQuestion()
    {
        var randomIndex = GetRandomQuestionIndex();
        currentQuestion = randomIndex;

        return Questions[currentQuestion];
    }
    int GetRandomQuestionIndex()
    {
        var random = 0;
        if (FinishedQuestions.Count < Questions.Length)
        {
            do
            {
                random = UnityEngine.Random.Range(0, Questions.Length);
            } while (FinishedQuestions.Contains(random) || random == currentQuestion);
        }
        return random;
    }

    void LoadQuestions()
    {
        Object[] objs = Resources.LoadAll("Questions", typeof(Question));
        _questions = new Question[objs.Length];
        for (int i = 0; i < objs.Length; i++)
        {
            _questions[i] = (Question)objs[i];
        }
    }
    bool CheckAnswers()
    {
        if (!CompareAnswers())
        {
            return false;
        }
        return true;
    }

    bool CompareAnswers()
    {
        if (PickedAnswers.Count > 0)
        {
            //Las respuestas correctas de la pregunta actual
            List<int> c = Questions[currentQuestion].GetCorrectAnswers();
            //Las respuestas seleccionadas
            List<int> p = PickedAnswers.Select(x => x.AnswerIndex).ToList();

            //Operación de interesección de los vectores
            var f = c.Except(p).ToList();
            var s = p.Except(c).ToList();

            return !f.Any() && !s.Any();
        }
        return false;
    }

    public void Accept(){
        //UpdateTimer(false);
        bool isCorrect = CheckAnswers();
        FinishedQuestions.Add(currentQuestion);

    //     UpdateScore((isCorrect) ? Questions[currentQuestion].AddScore : -Questions[currentQuestion].AddScore);

    //     if (IsFinished)
    //     {
    //         SetHighscore();
    //     }

    //     var type 
    //         = (IsFinished) 
    //         ? UIManager.ResolutionScreenType.Finish 
    //         : (isCorrect) ? UIManager.ResolutionScreenType.Correct 
    //         : UIManager.ResolutionScreenType.Incorrect;

    //     if (events.DisplayResolutionScreen != null)
    //     {
    //         events.DisplayResolutionScreen(type, Questions[currentQuestion].AddScore);
    //     }

    //     AudioManager.Instance.PlaySound((isCorrect) ? "CorrectSFX" : "IncorrectSFX");

    //     if (type != UIManager.ResolutionScreenType.Finish)
    //     {
    //         if (IE_WaitTillNextRound != null)
    //         {
    //             StopCoroutine(IE_WaitTillNextRound);
    //         }
    //         IE_WaitTillNextRound = WaitTillNextRound();
    //         StartCoroutine(IE_WaitTillNextRound);
    //     }
     }
}
