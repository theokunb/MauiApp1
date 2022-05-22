using MauiApp1.MVVM.Models;
using System.Windows.Input;

namespace MauiApp1.CustomControls;

public partial class ImageContainer : ContentView
{
	public ImageContainer()
	{
		InitializeComponent();
	}


    public static readonly BindableProperty ImagesProperty = BindableProperty.Create(nameof(Images), typeof(IList<UserImage>), typeof(ImageContainer), null, propertyChanged: ImagesPropertyChanged);
    public static readonly BindableProperty RemoveCommandProperty = BindableProperty.Create(nameof(RemoveCommand), typeof(ICommand), typeof(ImageContainer), null);




    public IList<UserImage> Images
    {
		get => GetValue(ImagesProperty) as IList<UserImage>;
		set => SetValue(ImagesProperty, Images);
    }
    public ICommand RemoveCommand
    {
        get => GetValue(RemoveCommandProperty) as ICommand;
        set => SetValue(RemoveCommandProperty, value);
    }



    private static void ImagesPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (ImageContainer)bindable;
        control.collection.ItemsSource = newValue as IList<UserImage>;
    }
}