namespace SmartGenealogy.ViewModels;

public partial class AboutPageViewModel : BaseViewModel
{
    public ObservableCollection<TestimonialModel> items;

    public AboutPageViewModel()
    {
        LoadTestimonials();
    }

    private void LoadTestimonials()
    {
        items = new ObservableCollection<TestimonialModel>
        {
            new TestimonialModel
            {
                Avatar = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/avatars/user1.png",
                UserName = "Alice Russell",
                Professional = "Senior Manager",
                Rating = 5.0,
                Comment = "Donec euismod nulla et sem lobortis ultrices. Cras id imperdiet metus. Sed congue luctus arcu.",
                ImageUrl = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/brands/microsoft_logo.png"
            },
            new TestimonialModel
            {
                Avatar = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/avatars/user2.png",
                UserName = "David Son",
                Professional = "Director",
                Rating = 4.5,
                Comment = "Spread all the pieces of paper onto a table, a desk, a bed, or even the floor.",
                ImageUrl = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/brands/xamarin-forms-logo.png"
            },
            new TestimonialModel
            {
                Avatar = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/avatars/user3.png",
                UserName = "Cecily Trujillo",
                Professional = "Founder & CTO",
                Rating = 5.0,
                Comment = "Donec euismod nulla et sem lobortis ultrices. Cras id imperdiet metus. Sed congue luctus arcu.",
                ImageUrl = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/brands/microsoft_logo.png"
            },
            new TestimonialModel
            {
                Avatar = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/avatars/user4.png",
                UserName = "Antoni Whitney",
                Professional = "Found & CEO",
                Rating = 4.5,
                Comment = "Spread all the pieces of paper onto a table, a desk, a bed, or even the floor.",
                ImageUrl = "https://raw.githubusercontent.com/tlssoftware/raw-material/master/maui-kit/brands/xamarin-forms-logo.png"
            }
        };

        TestimonialItems = new ObservableCollection<TestimonialModel>(items);
    }

    [ObservableProperty]
    private ObservableCollection<TestimonialModel> _testimonialItems;
}