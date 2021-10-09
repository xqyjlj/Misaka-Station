﻿using MstnAPP.Modules.Page.RTThread.Event;
using MstnAPP.Modules.Page.RTThread.Models;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MstnAPP.Modules.Page.RTThread.ViewModels
{
    public class TaskDeviceViewModel : BindableBase, IRegionMemberLifetime
    {
        public bool KeepAlive => false;

        private readonly IEventAggregator _eventAggregator;

        public TaskDeviceViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _ = _eventAggregator.GetEvent<EventDevice>().Subscribe(EventDeviceReceived);
        }

        private ObservableCollection<ModelDevice> _DataGridItems = new();

        public ObservableCollection<ModelDevice> DataGridItems
        {
            get => _DataGridItems;
            set => _ = SetProperty(ref _DataGridItems, value);
        }

        private void EventDeviceReceived(List<string> list)
        {
            ParseData(list);
        }

        private void ParseData(List<string> list)
        {
            string head, msg;

            msg = list[0];
            head = msg[0..^11];//"list_device".Length
            msg = list[^1]; //列表中的最后一个字符串

            if (msg == head)  //第一个和最后一个 相同表示报文接收完毕
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    DataGridItems.Clear();
                });

                int count = list.Count - 4;
                for (int i = 3; i < 3 + count; i++)
                {
                    msg = list[i];

                    string[] subs = msg.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (subs.Length == 3)
                    {
                        ModelDevice model = new();
                        model.Name = subs[0];
                        model.Type = subs[1];
                        model.RefCount = subs[2];
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            DataGridItems.Add(model);
                        });
                    }
                }
            }
        }
    }
}