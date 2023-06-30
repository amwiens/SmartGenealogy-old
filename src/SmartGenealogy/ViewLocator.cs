using Avalonia.Controls;
using Avalonia.Controls.Templates;

using SmartGenealogy.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGenealogy;

public class ViewLocator : IDataTemplate
{
    public bool SupportsRecycling => false;

    public Control? Build(object data)
    {
        var name = data.GetType().FullName!.Replace("ViewModel", "View");
        var type = Type.GetType(name);

        if (type != null)
        {
            return (Control)Activator.CreateInstance(type)!;
        }
        else
        {
            return new TextBlock { Text = "Not Found: " + name };
        }
    }

    public bool Match(object data)
    {
        return data is ViewModelBase;
    }

    //Control? ITemplate<object?, Control?>.Build(object? param)
    //{
    //    throw new NotImplementedException();
    //}
}