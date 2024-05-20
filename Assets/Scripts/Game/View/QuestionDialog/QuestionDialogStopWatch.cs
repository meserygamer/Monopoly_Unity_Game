using System;
using System.Timers;
using TMPro;
using UnityEditor.Search;
using UnityEngine;

namespace Scripts.Game.View.QuestionDialog
{
    public class QuestionDialogStopWatch : MonoBehaviour
    {
        [SerializeField] private uint _timeOnStopWatchInSecond;
        [SerializeField] private TextMeshProUGUI _timerTimeTextShower;

        private Timer _stopwatch;


        public bool IsTicking { get; private set; } = false;


        public void Start()
        {
            StartStopwatch();
        }


        public bool SetTime(uint timeInSecond)
        {
            if(IsTicking)
                return false;
            _timeOnStopWatchInSecond = timeInSecond;
            return true;
        }

        public void StartStopwatch()
        {
            IsTicking = true;
            _stopwatch = new Timer()
            {
                Interval = 1000,
                Enabled = true
            };
            _stopwatch.Elapsed += Stopwatch_Elapsed;

            #if UNITY_EDITOR
                Dispatcher.Enqueue(new Action(() => _timerTimeTextShower.text = FormTimeOnStopwatchInString()));
            #else
                _timerTimeTextShower.text = FormTimeOnStopwatchInString();
            #endif

            _stopwatch.Start();
        }

        private void Stopwatch_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timeOnStopWatchInSecond -= 1;

             #if UNITY_EDITOR    
                Dispatcher.Enqueue( new Action(() => _timerTimeTextShower.text = FormTimeOnStopwatchInString()));
             #else
                _timerTimeTextShower.text = FormTimeOnStopwatchInString();
             #endif

            if (_timeOnStopWatchInSecond == 0)
            {
                _stopwatch.Stop();
                IsTicking = false;
            }
        }

        private string FormTimeOnStopwatchInString()
        {
            string minutes = (_timeOnStopWatchInSecond / 60).ToString();
            string seconds = (_timeOnStopWatchInSecond % 60).ToString();
            return ((minutes.Length == 2)? minutes : '0' + minutes)
                + ':' 
                + ((seconds.Length == 2)? seconds : '0' + seconds);
        }
    }
}
