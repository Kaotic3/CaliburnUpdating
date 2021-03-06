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
            string[] firstGroupTermsList = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday ", "Saturday", "Sunday", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", "Red", "Blue", "Orange", "Green", "Gray", "Black", "Purple", "Brown", "Pink", "White", "Yellow", "Rust", "Acoustic", "Electric", "Nylon", "Steel", "Leather", "Wood", "Rubber" };
            string[] secGroupTermsList = new string[] { "RAM", "CPU", "GPU", "PSU", "SSD", "Harddrive", "USB", "Audio", "Graphics", "Memory", "PCIE", "Power ", "Light", "RGB", "Thermo", "Paste", "Cable", "Desk", "Chair", "Keyboard", "Mouse", "Fan", "Sofa", "Lounge", "Coffee", "Tea", "Bread", "Milk", "Pizza", "Sausage ", "Chicken", "Pineapple", "Apple", "Banana", "Sugar", "Butter", "Margarine", "Cooker", "Microwave", "Picture", "Camera", "Violin ", "Guitar", "Drum", "String", "Shelf", "Fireplace", "Monitor", "Speakers", "XLR" };
            string[] thirdGroupTermsList = new string[] { "success", "perform", "won", "rate", "dominate", "range", "try" };
            string[] fourthGroupTermsList = new string[] { "UK", "United Kingdom", "England", "Scotland", "Wales", "Northern Ireland", "NI", "Europe", "EEA", "European Economic Area", "EU", "European Union", "Turkey", "Ukraine", "Switzerland" };
            string[] operandListArray = new string[] { "AND", "AND", "AND" };

            StringBuilder outputCombined = new StringBuilder();

            //var query = from elem1 in firstGroupTermsList from elem2 in secGroupTermsList from elem3 in thirdGroupTermsList from elem4 in fourthGroupTermsList select string.Join(" ", elem1, operandListArray[0], elem2, operandListArray[1], elem3, operandListArray[2], elem4);

            foreach (var item in firstGroupTermsList)
            {
                foreach (var item1 in secGroupTermsList)
                {
                    foreach (var item2 in thirdGroupTermsList)
                    {
                        foreach (var item3 in fourthGroupTermsList)
                        {
                            outputCombined.Append(item + $" {operandListArray[0]} " + item1 + $" {operandListArray[1]} " + item2 + $" {operandListArray[2]} " + item3 + Environment.NewLine);
                        }
                    }
                }
            }

            //foreach (var element in query)
            //{
            //    outputCombined.Append(element + Environment.NewLine);
            //}

            strGroupOutPut = outputCombined.ToString();

            outputCombined.Clear();
        }
        public void btnReset()
        {
            strGroupOutPut = "";

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
