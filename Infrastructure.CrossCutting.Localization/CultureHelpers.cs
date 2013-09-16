using System.Globalization;
using System.Threading;

namespace Infrastructure.CrossCutting.Localization
{
    public static class CultureHelpers
    {
        public static void SetCulture(string aCultureAbb)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(aCultureAbb);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(aCultureAbb);
        }
    }
}
