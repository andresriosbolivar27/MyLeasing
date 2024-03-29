﻿using MyLeasing.Common.Models;
using Prism.Commands;
using Prism.Navigation;

namespace MyLeasing.Prism.ViewsModels
{
    public class PropertyItemViewModel : PropertyResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectPropertyCommand;

        public PropertyItemViewModel(
            INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectPropertyCommand => _selectPropertyCommand ?? (_selectPropertyCommand = new DelegateCommand(SelectProperty));

        private async void SelectProperty()
        {
            var parameters = new NavigationParameters
            {
                { "property", this}
            };

            await _navigationService.NavigateAsync("PropertyPage", parameters);
        }
    }
}
