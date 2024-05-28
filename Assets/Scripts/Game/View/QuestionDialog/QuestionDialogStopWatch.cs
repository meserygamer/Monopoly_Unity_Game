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


        public bool IsTicking { get; set; } = false;


        public event Action TimeIsOver;


        public bool SetTime(uint timeInSecond)
        {
            if(IsTicking)
                return false;
            _timeOnStopWatchInSecond = timeInSecond;
            _timerTimeTextShower.text = FormTimeOnStopwatchInString();
            return true;
        }

        public void StartStopwatch()
        {
            if(IsTicking)
                return;
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

            IsTicking = true;
            _stopwatch.Start();
        }

        public void StopStopwatch()
        {
            if(IsTicking)
            {
                _stopwatch.Stop();
                IsTicking = false;
            }
        }

        public void ResetStopwatch()
        {
            _stopwatch.Stop();
            IsTicking = false;
            _stopwatch.Dispose();
            _timeOnStopWatchInSecond = 0;

            #if UNITY_EDITOR
                Dispatcher.Enqueue(new Action(() => _timerTimeTextShower.text = FormTimeOnStopwatchInString()));
            #else
                _timerTimeTextShower.text = FormTimeOnStopwatchInString();
            #endif
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
                TimeIsOver?.Invoke();
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
