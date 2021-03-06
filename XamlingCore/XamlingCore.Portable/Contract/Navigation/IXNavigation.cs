using System;
using System.Collections.Generic;
using System.ComponentModel;
using XamlingCore.Portable.Model.Navigation;

namespace XamlingCore.Portable.Contract.Navigation
{
    public interface IXNavigation
    {
        bool IsModal { get; set; }
        event EventHandler<XNavigationEventArgs> Navigated;
        bool IsReverseNavigation { get; set; }
        List<object> NavigationHistory { get; set; }
        object CurrentContentObject { get; set; }
        object PreviousContentObject { get; set; }
        bool CanGoBack { get; set; }
        object ModalContentObject { get; set; }
        TimeSpan? RestrictNavigationTime { get; set; }
        TimeSpan? BlockSameNavigationTime { get; set; }
        void InsertIntoHistory(object obj);
        void ResetHistory();
        void NavigateTo(object content);
        void NavigateTo(object content, bool noHistory);
        void NavigateTo(object content, bool noHistory, bool forceBack);
        bool NavigateBack();
        bool NavigateBack(bool allowNullNavigation);
        event PropertyChangedEventHandler PropertyChanged;
        void NavigateToModal(object content);
    }
}