using System;
using System.Timers;
using TMPro;
using UnityEditor.Search;
using UnityEngine;

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


        private void Start()
        {
            PrintString();
        }


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

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if(_currentSymbolIndex + 1 >= _stringToPrint.Length)
            {
                _timer.Stop();
                IsStringPrinting = false;
            }
            #if UNITY_EDITOR
                Dispatcher.Enqueue( () => _textMeshProForPrinting.text += _stringToPrint[_currentSymbolIndex++]);
            #else
                _textMeshProForPrinting.text += _stringToPrint[_currentSymbolIndex++];
            #endif
            
        }
    }
}