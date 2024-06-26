﻿using FontAwesome.Sharp;
using Login.Model;
using Login.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace Login.ViewModel
{
     public class MainViewModel : ViewModel
     {
          private UserAccModel _currentUserAccount;
          private ViewModel _currentChildView;
          private string _caption;
          private IconChar _icon;
          private IUserRepository userRepository;

          public UserAccModel CurrentUserAccount
          {
               get
               {
                    return _currentUserAccount;
               }

               set
               {
                    _currentUserAccount = value;
                    OnPropertyChanged(nameof(CurrentUserAccount));
               }
          }

          public ViewModel CurrentChildView {
               get {
                     return _currentChildView;
               }
               set { _currentChildView = value; 
                    OnPropertyChanged(nameof(CurrentChildView));

               }
          }
          public string Caption { get {  return _caption; } set { _caption = value; OnPropertyChanged(nameof(Caption)); } }
          public IconChar Icon { get { return _icon; } set { _icon = value; OnPropertyChanged(nameof(Icon)); } }

          public ICommand ShowHomeViewCommand { get; }
          public ICommand ShowCustomerViewCommand {  get; }

          public MainViewModel()
          {
               userRepository = new UserRepository();
               CurrentUserAccount = new UserAccModel();

               ShowHomeViewCommand = new RelayCommand(ExecuteShowHomeViewCommand);
               ShowCustomerViewCommand = new RelayCommand(ExecuteShowCustomerViewCommand);

               ExecuteShowHomeViewCommand(null);
               LoadCurrentUserData();
          }

          private void ExecuteShowCustomerViewCommand(object obj)
          {
               CurrentChildView = new CustomerViewModel();
               Caption = "Customer";
               Icon = IconChar.UserGroup;
          }

          private void ExecuteShowHomeViewCommand(object obj)
          {
               CurrentChildView = new HomeViewModel();
               Caption = "Dashboard";
               Icon = IconChar.Home;
          }

          private void LoadCurrentUserData()
          {
               var username = Thread.CurrentPrincipal.Identity.Name;
               if (string.IsNullOrEmpty(username))
               {
                    CurrentUserAccount.DisplayName = "No user logged in";
                    return;
               }

               var user = userRepository.GetByUsername(username);
               if (user != null)
               {
                    CurrentUserAccount.Username = user.Username;
                    CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName}";
                    CurrentUserAccount.ProfilePicture = null;
               }
               else
               {
                    CurrentUserAccount.DisplayName = "Invalid user, not logged in";
               }
          }
     }
}
