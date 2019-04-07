using System;
namespace SmartSkinCare.BusinessLogic
{
    public static class TypeOfSkinExtensions
    {
        public static string ToFriendlyString(this TypeOfSkin type)
        {
            switch (type)
            {
                case TypeOfSkin.Dry:
                    return "Dry";

                case TypeOfSkin.Combinated:
                    return "Combinated";

                case TypeOfSkin.Fat:
                    return "Fat";

                default:
                    return "Normal";
            }
        }
    }

    public enum TypeOfSkin
    {
        Dry,
        Normal,
        Combinated,
        Fat
    }
}
