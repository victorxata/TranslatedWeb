using System.ComponentModel;
using Resources;

namespace Infrastructure.CrossCutting.Localization
{
    public class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        private readonly string _resourceName;

        public LocalizedDisplayNameAttribute(string resourceName)
        {
            _resourceName = resourceName;
        }

        public override string DisplayName
        {
            get { return Global.ResourceManager.GetString(_resourceName); }
        }
    }
}