﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace MstnAPP.Modules.Page.Home.ViewModels
{
    public class HomePageViewModel : BindableBase, IRegionMemberLifetime
    {
        private readonly IDialogService _dialogService;
        public bool KeepAlive => false;

        public HomePageViewModel(IDialogService dialog)
        {
            _dialogService = dialog;
        }

        private DelegateCommand _buttonWeChatCommand;

        public DelegateCommand ButtonWeChatCommand =>
            _buttonWeChatCommand ??= new DelegateCommand(ExecuteButtonWeChatCommand);

        private void ExecuteButtonWeChatCommand()
        {
            _dialogService.ShowDialog("WeChatDialog");
        }

        private DelegateCommand _buttonQQCommand;

        public DelegateCommand ButtonQQCommand =>
            _buttonQQCommand ??= new DelegateCommand(ExecuteButtonQQCommand);

        private void ExecuteButtonQQCommand()
        {
            _dialogService.ShowDialog("QQDialog");
        }

        private DelegateCommand _buttonGithubCommand;

        public DelegateCommand ButtonGithubCommand =>
            _buttonGithubCommand ??= new DelegateCommand(ExecuteButtonGithubCommand);

        private static void ExecuteButtonGithubCommand()
        {
            Services.Sys.Process.StartProcess.OpenGithub();
        }

        private DelegateCommand _buttonEmailCommand;

        public DelegateCommand ButtonEmailCommand =>
            _buttonEmailCommand ??= new DelegateCommand(ExecuteButtonEmailCommand);

        private static void ExecuteButtonEmailCommand()
        {
            Services.Sys.Process.StartProcess.OpenEmail();
        }

        private DelegateCommand _buttonDonateCommand;

        public DelegateCommand ButtonDonateCommand =>
            _buttonDonateCommand ??= new DelegateCommand(ExecuteButtonDonateCommand);

        private static void ExecuteButtonDonateCommand()
        {
            Services.Sys.Process.StartProcess.OpenDonate();
        }
    }
}