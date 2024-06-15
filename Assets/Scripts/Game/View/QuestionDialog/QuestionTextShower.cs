using System;
using System.Timers;
using TMPro;
using UnityEngine;
using Scripts.Game.View;

#if UNITY_EDITOR
using UnityEditor.Search;
#endif

namespace Scripts.Game.View.QuestionDialog
{
    public sealed class QuestionTextShower : MonoBehaviour
    {
        [SerializeField] private string _stringToPrint = "Hello_World";

        [SerializeField] private uint _symbolsInSecond = 5;

        [SerializeField] private TextMeshProUGUI _textMeshProForPrinting;

        private Timer _timer;

        private int _currentSymbolIndex = 0;


        public bool IsStringPrinting { get; private set; }


        public event Action StringPrinted;


        public void SetStringToPrint(string stringToPrint)
        {
            if(IsStringPrinting)
                return;
            if(stringToPrint == null)
                _stringToPrint = "";
            _stringToPrint = stringToPrint;
        }

        public void PrintString()
        {
            if(IsStringPrinting)
                return;
            IsStringPrinting = true;
            _textMeshProForPrinting.text = "";
            _timer = new Timer() 
            {
                Interval = 1000 / _symbolsInSecond,
                AutoReset = true,
                Enabled = true
            };
            _timer.Elapsed += TimerElapsed;
            _currentSymbolIndex = 0;
            _timer.Start();
        }

        public void ResetQuestionString()
        {
            _timer.Stop();
            IsStringPrinting = false;
            _timer.Dispose();
            
            #if UNITY_EDITOR
                Dispatcher.Enqueue( () => _textMeshProForPrinting.text = "");
            #else
                MultiThreadQueue.AddInMultithreadQueue(() => _textMeshProForPrinting.text = "");
            #endif
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if(_currentSymbolIndex + 1 >= _stringToPrint.Length)
            {
                _timer.Stop();
                IsStringPrinting = false;
                StringPrinted?.Invoke();
            }
            #if UNITY_EDITOR
                Dispatcher.Enqueue( () => _textMeshProForPrinting.text += _stringToPrint[_currentSymbolIndex++]);
            #else
                MultiThreadQueue.AddInMultithreadQueue(() => _textMeshProForPrinting.text += _stringToPrint[_currentSymbolIndex++]);
            #endif
            
        }
    }
}