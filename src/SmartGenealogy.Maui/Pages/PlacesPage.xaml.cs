namespace SmartGenealogy.Maui.Pages;

public partial class PlacesPage : ContentPage
{
	private PlacesViewModel viewModel => BindingContext as PlacesViewModel;

	public PlacesPage(PlacesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

		var mapControl = new Mapsui.UI.Maui.MapControl();
		mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
		Content = mapControl;
	}
}