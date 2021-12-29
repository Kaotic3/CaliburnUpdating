using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnUpdatingScreen.ViewModels
{
    public class TermSplitterViewModel : Screen
    {
        #region Public Properties

        private string _resultBar;

        public string ResultBar
        {
            get { return _resultBar; }
            set
            {
                _resultBar = value;
                NotifyOfPropertyChange(() => ResultBar);
            }
        }

        private int _currentProgress;
        public int CurrentProgress
        {
            get { return _currentProgress; }
            private set
            {
                _currentProgress = value;
                NotifyOfPropertyChange(() => CurrentProgress);
            }
        }
        private string _strNamesIn;
        public string strNamesIn
        {
            get { return _strNamesIn; }
            set
            {
                _strNamesIn = value;
                NotifyOfPropertyChange(() => strNamesIn);
            }
        }
        private string _strGroupOutPut;
        public string strGroupOutPut
        {
            get { return _strGroupOutPut; }
            set
            {
                _strGroupOutPut = value;
                NotifyOfPropertyChange(() => strGroupOutPut);
            }
        }
        private string _strGroupOne;
        public string strGroupOne
        {
            get { return _strGroupOne; }
            set
            {
                _strGroupOne = value;
                NotifyOfPropertyChange(() => strGroupOne);
            }
        }
        private string _strGroupTwo;
        public string strGroupTwo
        {
            get { return _strGroupTwo; }
            set
            {
                _strGroupTwo = value;
                NotifyOfPropertyChange(() => strGroupTwo);
            }
        }
        private string _strGroupThree;
        public string strGroupThree
        {
            get { return _strGroupThree; }
            set
            {
                _strGroupThree = value;
                NotifyOfPropertyChange(() => strGroupThree);
            }
        }
        private string _strGroupFour;
        public string strGroupFour
        {
            get { return _strGroupFour; }
            set
            {
                _strGroupFour = value;
                NotifyOfPropertyChange(() => strGroupFour);
            }
        }
        private string _strGroupOperand;
        public string strGroupOperand
        {
            get { return _strGroupOperand; }
            set
            {
                _strGroupOperand = value;
                NotifyOfPropertyChange(() => strGroupOperand);
            }
        }
        private string _tbSelectedGroup;
        public string tbSelectedGroup
        {
            get { return _tbSelectedGroup; }
            set
            {
                _tbSelectedGroup = value;
                NotifyOfPropertyChange(() => tbSelectedGroup);
            }
        }
        #endregion
        public TermSplitterViewModel()
        {
            ResultBar = 0 + "%";
        }
        public void btnAsyncTerms()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            return;
        }
        public void btnAsyncBaash()
        {
            var firstGroupTerms = strGroupOne;
            var secGroupTerms = strGroupTwo;
            var operandList = strGroupOperand;

            if (firstGroupTerms == "" || firstGroupTerms == null)
            {
                return;
            }
            if (secGroupTerms == "" || secGroupTerms == null)
            {
                return;
            }

            var firstGroupTermsList = strGroupOne.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var secGroupTermsList = strGroupTwo.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> thirdGroupTermsList = new List<string>();
            List<string> fourthGroupTermsList = new List<string>();
            if (strGroupThree != "" && strGroupThree != null)
            {
                thirdGroupTermsList = strGroupThree.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            if (strGroupFour != "" && strGroupFour != null)
            {
                fourthGroupTermsList = strGroupFour.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            var operandListArray = operandList.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            StringBuilder outputCombined = new StringBuilder();
            if (fourthGroupTermsList.Count() > 0)
            {
                var query = from elem1 in firstGroupTermsList from elem2 in secGroupTermsList from elem3 in thirdGroupTermsList from elem4 in fourthGroupTermsList select string.Join(" ", elem1, operandListArray[0], elem2, operandListArray[1], elem3, operandListArray[2], elem4);

                foreach (var element in query)
                {
                    outputCombined.Append(element + Environment.NewLine);
                }
            }
            else if (thirdGroupTermsList.Count() > 0)
            {
                var query2 = from elem1 in firstGroupTermsList from elem2 in secGroupTermsList from elem3 in thirdGroupTermsList select string.Join(" ", elem1, operandListArray[0], elem2, operandListArray[1], elem3);

                foreach (var element2 in query2)
                {
                    outputCombined.Append(element2 + Environment.NewLine);
                }
            }
            else
            {
                var query3 = from elem1 in firstGroupTermsList from elem2 in secGroupTermsList select string.Join(" ", elem1, operandListArray[0], elem2);
                foreach (var element3 in query3)
                {
                    outputCombined.Append(element3 + Environment.NewLine);
                }
            }

            var result = outputCombined.ToString().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            if (result.Length > 10000)
            {
                allOutput = outputCombined.ToString();
                outputCombined.Clear();

                outputCombined.Append("THIS IS A SAMPLE - CREATE TEXT FILE FOR FULL SET!" + Environment.NewLine + Environment.NewLine);

                for (int i = 0; i < 100; i++)
                {
                    outputCombined.Append(result[i] + Environment.NewLine);
                }
                strGroupOutPut = outputCombined.ToString();
            }
            else
            {
                strGroupOutPut = outputCombined.ToString();
            }

            outputCombined.Clear();
            firstGroupTermsList.Clear();
            secGroupTermsList.Clear();
            thirdGroupTermsList.Clear();
            fourthGroupTermsList.Clear();
            operandListArray.Clear();
        }
        public void btnReset()
        {
            tbSelectedGroup = "";
            strGroupOne = "";
            strGroupTwo = "";
            strGroupThree = "";
            strGroupFour = "";
            strNamesIn = "";
            strGroupOutPut = "";
            strGroupOperand = "";

            CurrentProgress = 0;
            ResultBar = 0 + "%";
        }
        #region Progress Bar methods
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            CurrentProgress = e.ProgressPercentage;
            ResultBar = (e.ProgressPercentage.ToString() + "%");
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        #endregion
    }
}
