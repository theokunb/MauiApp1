using MauiApp1.MVVM.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiApp1.CustomControls;

public partial class ImageContainer : ContentView
{
	public ImageContainer()
	{
		InitializeComponent();
	}


    public static readonly BindableProperty ImagesProperty = BindableProperty.Create(nameof(Images), typeof(ObservableCollection<UserImage>), typeof(ImageContainer), null, BindingMode.TwoWay,coerceValue:ImagePropertyCoerceValue);


    public static readonly BindableProperty RemoveCommandProperty = BindableProperty.Create(nameof(RemoveCommand), typeof(ICommand), typeof(ImageContainer), null);
    public static readonly BindableProperty AddCommandProperty = BindableProperty.Create(nameof(AddCommand), typeof(ICommand), typeof(ImageContainer), null);



    public ObservableCollection<UserImage> Images
    {
		get => GetValue(ImagesProperty) as ObservableCollection<UserImage>;
        set => SetValue(ImagesProperty, Images);
    }
    public ICommand RemoveCommand
    {
        get => GetValue(RemoveCommandProperty) as ICommand;
        set => SetValue(RemoveCommandProperty, value);
    }
    public ICommand AddCommand
    {
        get => GetValue(AddCommandProperty) as ICommand;
        set => SetValue(AddCommandProperty, value);
    }


    private static object ImagePropertyCoerceValue(BindableObject bindable, object value)
    {
        var collection = value as ObservableCollection<UserImage>;
        if (collection == null)
            return null;
        for (int i = 0; i < collection.Count; i++)
        {
            if (string.IsNullOrEmpty(collection[i].Title))
            {
                for (int j = i; j < collection.Count; j++)
                {
                    if (!string.IsNullOrEmpty(collection[j].Title))
                    {
                        var tmp = collection[i];
                        collection[i] = collection[j];
                        collection[j] = tmp;
                    }
                }
            }
        }
        return value;
    }
}