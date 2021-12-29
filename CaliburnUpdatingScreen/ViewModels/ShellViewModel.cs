using Caliburn.Micro;
using CaliburnUpdatingScreen.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CaliburnUpdatingScreen.ViewModels
{
    class ShellViewModel : Conductor<object>, IHandle<SplittingEvent>
    {
        public static System.Action CloseAction { get; set; }

        private IEventAggregator _events;
        private StartUpViewModel _suVM;
        private TermSplitterViewModel _tsVM;

        public ShellViewModel()
        {

        }
        public ShellViewModel(StartUpViewModel suVM, TermSplitterViewModel tsVM, IEventAggregator events)
        {
            _suVM = suVM;
            _tsVM = tsVM;


            _events = events;

            _events.SubscribeOnPublishedThread(this);

            ActivateItemAsync(_suVM);
        }
        public void Exit()
        {
            CloseAction();
        }
        public void btnComb()
        {
            _events.PublishOnUIThreadAsync(new SplittingEvent());
        }
        public Task HandleAsync(SplittingEvent message, CancellationToken cancellationToken)
        {
            ActivateItemAsync(_tsVM);
            return Task.CompletedTask;
        }
    }
}
