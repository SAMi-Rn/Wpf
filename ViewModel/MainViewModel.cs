using Login.Model;
using Login.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace Login.ViewModel
{
     public class MainViewModel : ViewModel
     {
          private UserAccModel _currentUserAccount;
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

          public MainViewModel()
          {
               userRepository = new UserRepository();
               CurrentUserAccount = new UserAccModel();
               LoadCurrentUserData();
          }

          private void LoadCurrentUserData()
          {
               var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
               if (user != null)
               {
                    CurrentUserAccount.Username = user.Username;
                    CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName} ;)";
                    CurrentUserAccount.ProfilePicture = null;
               }
               else
               {
                    CurrentUserAccount.DisplayName = "Invalid user, not logged in";
               }
          }
     }
}
