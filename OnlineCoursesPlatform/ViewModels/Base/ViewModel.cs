using GalaSoft.MvvmLight;
using OnlineCoursesPlatform.Infrastructure.EF;
using OnlineCoursesPlatform.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesPlatform.ViewModels.Base
{
    public class ViewModel : ObservableObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public bool Set<T>(ref T field, T value, [CallerMemberName]string? propertyName = null)
        {
            if(Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private ApplicationContext _db = null!;
        public ApplicationContext db
        {
            get => _db;
            set => Set(ref _db, value);
        }
        
    }
}
