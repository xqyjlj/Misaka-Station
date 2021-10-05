﻿using MstnAPP.Modules.Page.RTThread.Models;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace MstnAPP.Modules.Page.RTThread.ViewModels
{
    internal class RTThreadPageTaskPerformanceMemoryHeapViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        public bool KeepAlive => false;

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public RTThreadPageTaskPerformanceMemoryHeapViewModel()
        {
        }

        private ObservableCollection<ModelMemoryHeap> _dataGridTaskItems = new();

        public ObservableCollection<ModelMemoryHeap> DataGridTaskItems
        {
            get => _dataGridTaskItems;
            set => _ = SetProperty(ref _dataGridTaskItems, value);
        }
    }
}