using SmartGenealogy.Contracts;

using System.Collections.ObjectModel;

namespace SmartGenealogy.Models;

public class LazyLoadableList : ObservableCollection<ILazyLoadable>
{
}