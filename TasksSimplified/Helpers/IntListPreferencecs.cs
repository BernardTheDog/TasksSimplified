using Android.Content;
using Android.Preferences;
using Android.Util;

namespace TasksSimplified.Helpers
{
    public class IntListPreference : ListPreference
    {
        public IntListPreference(Context context)
            : base(context)
        {
        }

        public IntListPreference(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {

        }


        protected override string GetPersistedString(string defaultReturnValue)
        {

            return GetPersistedInt(0).ToString();
        }

        protected override bool PersistString(string value)
        {
            int persistValue;
            int.TryParse(value, out persistValue);

            return PersistInt(persistValue);
        }
    }
}