using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Shared.Extensions
{
    public static class CollectionExtensions
    {
        public static ObservableCollection<T> RegisterCollectionChanged<T>(this ObservableCollection<T> collection,
            NotifyCollectionChangedEventHandler handler)
        {
            collection.CollectionChanged += handler;
            return collection;
        }
    }
}