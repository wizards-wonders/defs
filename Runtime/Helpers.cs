/// <summary>
/// Project: wizards & wonders
/// Company: Pixelakes
/// Script:  Helpers.cs
/// Created: 6/9/2022 11:11:00 AM
/// Author:  AaronBuffie
/// </summary>
/// 
namespace Pixelakes.Wrath{

    public class Helpers {

        public static string EnumToString<T>(T e)   => System.Enum.GetName(typeof(T), e);
        public static string EnumToString<T>(int e) => System.Enum.GetName(typeof(T), e);
        public static T StringToEnum<T>(string s)   => (T)System.Enum.Parse(typeof(T), s);

    }
}