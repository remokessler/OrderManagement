using OrderManagement.Backend.DataModels;
using OrderManagement.Backend.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace OrderManagement.Client.Models
{
    internal class ActivePage<T> : IActivePage
    {
        public IRepository<T> Repository { get; }
        public ObservableCollection<T> ObservableCollection { get; set; }
        public Type Type => typeof(T);

        public ActivePage(IRepository<T> repository)
        {
            Repository = repository;
            ObservableCollection = new ObservableCollection<T>();
            Repository.Get()?.ToList()?.ForEach(ObservableCollection.Add);
        }

        public ActivePage(IRepository<T> repository, bool isTree)
        {
            Repository = repository;
            ObservableCollection = new ObservableCollection<T>();
        }
    }
}
