using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using OnlineCoursesPlatform.Globals;
using OnlineCoursesPlatform.Globals.NavigationServ;
using OnlineCoursesPlatform.Globals.Pages;
using OnlineCoursesPlatform.Globals.ViewModels;
using OnlineCoursesPlatform.Infrastructure.Commands;
using OnlineCoursesPlatform.Infrastructure.EF;
using OnlineCoursesPlatform.Infrastructure.Services;
using OnlineCoursesPlatform.Models;
using OnlineCoursesPlatform.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OnlineCoursesPlatform.ViewModels
{
    public class LoginVM : ViewModel
    {
        //ApplicationContext db = GlobalInstanses.DB;
       
        public BCommand CloseCommand { get; } = new((o) => { Application.Current.Shutdown(); }, (o) => true);

        private void MoveToRegistration(object p)
        {
            PasswordTB = "";
            UsNameTB = "";
            ErrorStringTB = "";
            ViewModelsService.GetMainVM().Content = ViewModelsService.GetMainVM().registrationF;
        }
        private void MoveToLogin(object p)
        {
            PasswordTB = "";
            UsNameTB = "";
            ErrorStringTB = "";
            ViewModelsService.GetMainVM().Content = ViewModelsService.GetMainVM().loginField;
        }
       
        private void GoToMain()
        {
            FrameNavigation.GetNavigation().NavigateTo<MainWindowVM>();
            GlobalInstanses.CurrentPage = "Main";
            ViewModelsService.GetMainVM().UpdateBestScore();
        }

        private int LogInUser(string username, string password)
        {
            if(db.Users.Any((u) => u.UserName == username))
            {
                if(db.Users.Any((u) => u.Password == password))
                {
                    GlobalInstanses.CurrentUser = db.Users.Single((u)=>u.UserName == username);
                    return 2;
                }
                return 1;

            }
            return 0;
        }
        private int RegisterUser(string username, string password, string secPassword)
        {
            if(!db.Users.Any((u) => u.UserName == username))
            {
                if (secPassword != password) return 1;
                var newUser = new Models.User(username, password, Roles.student);
                try { db.Users.Attach(newUser); } catch { }
                db.Users.Add(newUser);
                db.SaveChanges();

                GlobalInstanses.CurrentUser = newUser;

                PermissionState state;
                foreach(var c in db.Courses)
                {
                    if (c.IsOpen)
                        state = PermissionState.open;
                    else
                        state = PermissionState.close;
                    db.Permissions.Add(new Permission() { CourseId = c.Id, UserId = newUser.Id, State = state });
                }
                db.SaveChanges();

                return 2;
            }
            return 0;
        }
        private string _usNameTB = string.Empty;
        public string UsNameTB
        {
            get => _usNameTB;
            set => Set(ref  _usNameTB, value);
        }
        private string _passwordTB = string.Empty;
        public string PasswordTB
        {
            get => _passwordTB;
            set => Set(ref _passwordTB, value);
        }
        private string _secPasswordTB = string.Empty;
        public string SecPasswordTB
        {
            get => _secPasswordTB;
            set => Set(ref _secPasswordTB, value);
        }
        private string _errorStringTB = string.Empty;
        public string ErrorStringTB
        {
            get => _errorStringTB;
            set => Set(ref _errorStringTB, value);
        }
        private void OnLoginUserCommand(object p)
        {
            if (Regex.IsMatch(UsNameTB, @"^[а-яА-ЯёЁa-zA-Z0-9_]+$") &&
                Regex.IsMatch(PasswordTB, @"^[а-яА-ЯёЁa-zA-Z0-9_!.]+$"))
            {
                if (UsNameTB.Trim() != String.Empty && PasswordTB.Trim() != String.Empty)
                {
                    switch (LogInUser(UsNameTB.Trim(), PasswordTB.Trim()))
                    {
                        case 0:
                            ErrorStringTB = "There is no such user";
                            break;
                        case 1:
                            ErrorStringTB = "Incorrect password";
                            break;
                        case 2:
                            ErrorStringTB = "";
                            GoToMain();
                            break;
                    }
                }
            }
            else ErrorStringTB = "Invalid input values";

        }
        private void OnRegisterUserCommand(object p)
        {
            if (Regex.IsMatch(UsNameTB, @"^[а-яА-ЯёЁa-zA-Z0-9_]+$") &&
                Regex.IsMatch(PasswordTB, @"^[а-яА-ЯёЁa-zA-Z0-9_!.]+$") && Regex.IsMatch(SecPasswordTB, @"^[а-яА-ЯёЁa-zA-Z0-9_!.]+$"))
            {
                if (UsNameTB.Trim() != String.Empty && PasswordTB.Trim() != String.Empty && SecPasswordTB.Trim() != String.Empty)
                {
                    switch (RegisterUser(UsNameTB, PasswordTB, SecPasswordTB))
                    {
                        case 0:
                            ErrorStringTB = "Such a user already exist";
                            break;
                        case 1:
                            ErrorStringTB = "Passwords don't match";
                            break;
                        case 2:
                            ErrorStringTB = "";
                            GoToMain();
                            break;
                    }
                }
            }
            else ErrorStringTB = "Invalid input values";

           
        }
        private string namePat = @"^[а-яА-ЯёЁa-zA-Z0-9_]+$";
        public BCommand ToRegCommand { get; }
        public BCommand ToLoginCommand { get; }
        public BCommand RegisterUserCommand { get; }
        public BCommand LoginCommand { get; }
        public LoginVM()
        {
            db = new();
            //Content = ViewModelsService.GetMainVM().loginField;
            
            ToRegCommand = new(MoveToRegistration, (o) => true);
            ToLoginCommand = new(MoveToLogin, (o) => true);
            LoginCommand = new(OnLoginUserCommand, (o) => true);
            RegisterUserCommand = new(OnRegisterUserCommand, (o) => true);
        }


    }
}
