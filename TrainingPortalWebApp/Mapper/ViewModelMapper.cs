using System;
using TrainingPortal.Entities.Models;
using TrainingPortal.WebPL.Interfaces;
using TrainingPortal.WebPL.Models;

namespace TrainingPortal.WebPL.Mapper
{
    public class ViewModelMapper : IViewModelMapper
    {
        public TOut ConvertToDomainModel<TIn, TOut>(TIn sourceInstance) where TIn : class where TOut : class
        {
            switch (typeof(TIn).Name)
            {
                case nameof(RegisterUserViewModel):
                    RegisterUserViewModel registerUserViewModel = sourceInstance as RegisterUserViewModel;
                    return new User(0, registerUserViewModel.Login, registerUserViewModel.Password, registerUserViewModel.Email,
                        new Role(1, "user"), null, null, null) as TOut;

                case nameof(SettingsUserViewModel):
                    SettingsUserViewModel settingsUserViewModel = sourceInstance as SettingsUserViewModel;
                    return new User(0, settingsUserViewModel.Login, settingsUserViewModel.Password, settingsUserViewModel.Email,
                        new Role(1, "user"), settingsUserViewModel.Lastname, settingsUserViewModel.Firstname,
                        settingsUserViewModel.Patronymic) as TOut;
                case nameof(EditUserViewModel):
                    EditUserViewModel editUserViewModel = sourceInstance as EditUserViewModel;
                    return new User(0, editUserViewModel.Login, null, editUserViewModel.Email,
                        null, editUserViewModel.Lastname, editUserViewModel.Firstname,
                        editUserViewModel.Patronymic) as TOut;

                default:
                    throw new ArgumentException("The argument type is not in the allowed list.", typeof(TIn).Name);
            }
        }

        public TOut ConvertToViewModel<TIn, TOut>(TIn sourceInstance) where TIn : class where TOut : class
        {
            switch (typeof(TIn).Name)
            {
                case nameof(User) when typeof(TOut).Name == nameof(SettingsUserViewModel):
                    User user = sourceInstance as User;
                    return new SettingsUserViewModel()
                    {
                        Login = user.Login,
                        Password = user.Password,
                        ConfirmPassword = user.Password,
                        Email = user.Email,
                        Firstname = user.Firstname,
                        Lastname = user.Lastname,
                        Patronymic = user.Patronymic
                    } as TOut;

                case nameof(User) when typeof(TOut).Name == nameof(EditUserViewModel):
                    User editeduser = sourceInstance as User;
                    return new EditUserViewModel()
                    {
                        Id = editeduser.Id,
                        Login = editeduser.Login,
                        Email = editeduser.Email,
                        RoleId = editeduser.Role.Id,
                        Firstname = editeduser.Firstname,
                        Lastname = editeduser.Lastname,
                        Patronymic = editeduser.Patronymic
                    } as TOut;

                default:
                    throw new ArgumentException("The argument type is not in the allowed list.", typeof(TIn).Name);
            }
        }
    }
}