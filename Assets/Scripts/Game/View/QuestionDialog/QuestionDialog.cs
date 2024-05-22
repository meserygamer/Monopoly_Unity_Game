using System;
using Monopoly_Unity_Game_Server.Model;
using Scripts.Game.Presenter.QuestionDialog;
using TMPro;
using UnityEngine;
using Zenject;

namespace Scripts.Game.View.QuestionDialog
{
    public sealed class QuestionDialog : MonoBehaviour
    {
        [SerializeField] QuestionTextShower _questionTextShower;
        [SerializeField] QuestionDialogStopWatch _questionDialogStopwatch;
        [SerializeField] TMP_InputField _answearInputField;
        [SerializeField] RightAnswearShower _rightAnswearInputField;

        private QuestionDialogPresenter _presenter;

        private bool _isAnswered;


        public event Action QuestionWindowClosed;


        [Inject]
        private void Constructor(QuestionDialogPresenter presenter)
        {
            _presenter = presenter;
            _presenter.View = this;
        }


        private void StartStopwatch()
        {
            _questionTextShower.StringPrinted -= StartStopwatch;
            _questionDialogStopwatch.TimeIsOver += StopwatchTimeIsOverHandler;
            _questionDialogStopwatch.StartStopwatch();
        }

        private void StopwatchTimeIsOverHandler()
        {
            if(_isAnswered)
                return;
            
            if(_presenter.CheckAnswear("", out string rightAnswer))
                _rightAnswearInputField.PrintAnswearAsRight(rightAnswer);
            else 
                _rightAnswearInputField.PrintAnswearAsFailure(rightAnswer);

            _questionDialogStopwatch.TimeIsOver -= StopwatchTimeIsOverHandler;
            _isAnswered = true;
        }


        public void ShowNewQuestion(GameSquareExample example)
        {
            ClearQuestionDialog();
            _questionTextShower.SetStringToPrint(example.Question.QuestionText);
            _questionDialogStopwatch.SetTime(example.DefaultTimeForAnswerInSecond);
            _questionTextShower.StringPrinted += StartStopwatch;
            _questionTextShower.PrintString();
        }

        public void CheckAnswear()
        {
            if(_isAnswered)
                return;
                
            if(_presenter.CheckAnswear(_answearInputField.text, out string rightAnswer))
                _rightAnswearInputField.PrintAnswearAsRight(rightAnswer);
            else 
                _rightAnswearInputField.PrintAnswearAsFailure(rightAnswer);

            _questionDialogStopwatch.StopStopwatch();
            _isAnswered = true;
        }

        public void CloseQuestion()
        {
            _questionDialogStopwatch.StopStopwatch();
            QuestionWindowClosed?.Invoke();
        }

        private void ClearQuestionDialog()
        {
            _isAnswered = false;
            _rightAnswearInputField.ClearRightAnswearField();
            _answearInputField.text = "";
        }
    }
}
