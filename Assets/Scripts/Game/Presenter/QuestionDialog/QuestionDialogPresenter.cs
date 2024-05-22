using System;
using Scripts.Game.Model.GameMaster;
using Scripts.Game.Services;

namespace Scripts.Game.Presenter.QuestionDialog
{
    public sealed class QuestionDialogPresenter
    {
        public QuestionDialogPresenter(QuestionMaster questionMaster,
                                       QuestionService questionService)
        {
            _questionMaster = questionMaster;
            _questionService = questionService;

            _questionMaster.PlayerQuestionWasGenerated += PlayerQuestionWasGeneratedHandler;
        }


        ~QuestionDialogPresenter()
        {
            _questionMaster.PlayerQuestionWasGenerated -= PlayerQuestionWasGeneratedHandler;
        }


        private QuestionMaster _questionMaster;
        private QuestionService _questionService;

        private View.QuestionDialog.QuestionDialog _view;


        public View.QuestionDialog.QuestionDialog View 
        {
            get => _view;
            set
            {
                if(_view is not null)
                    _view.QuestionWindowClosed -= QuestionWindowClosedHandler;

                _view = value;

                _view.QuestionWindowClosed += QuestionWindowClosedHandler;
            }
        }

        public uint? LastQuestionIndex { get; private set; } = null;


        private void QuestionWindowClosedHandler() => _questionMaster.PayRentForQuestion();


        private void PlayerQuestionWasGeneratedHandler(uint questionIndex)
        {
            LastQuestionIndex = questionIndex;
            View.ShowNewQuestion(_questionService.GetGameSquareExample(questionIndex));
        } 


        public bool CheckAnswear(string playerAnswear, out string rightAnswear)
        {
            rightAnswear = _questionService.GetRightAnswearOnQuestion((uint)LastQuestionIndex);
            return _questionService.GiveAnswearToQuestion((uint)LastQuestionIndex, playerAnswear);
        }
    }
}