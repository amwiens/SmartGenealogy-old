namespace SmartGenealogy.Models;

public class FontIconGroupModel : List<FontIconModel>
{
    public string GroupName { get; set; }
    public List<FontIconModel> IconList { get; set; }

    public FontIconGroupModel(string groupName, List<FontIconModel> iconList)
        : base(iconList)
    {
        GroupName = groupName;
        IconList = iconList;
    }

    public override string ToString()
    {
        return GroupName;
    }
}